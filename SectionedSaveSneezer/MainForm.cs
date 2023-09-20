using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SectionedSaveSneezer
{
    public partial class MainForm : Form
    {
        private const string MESSAGE_PARSE_SAVES
            = "元々あったセーブデータを一時的に退避させ、練習用セーブデータを展開しました";
        private const string MESSAGE_YOU_CAN_RESTORE_SAVES
            = "このウィンドウを閉じると元々あったセーブデータが復帰します。";
        private const string MESSAGE_REGENERATE_SAVE
            = "練習用セーブデータを再生成しました。";
        private const string MESSAGE_CREATE_CONFIG_FILE
            = "コンフィグ用ファイルを作成しました。確認し、必要に応じて編集し終えたら OK を押してください。";

        private readonly DataTable DataTable      = new DataTable();
        private const string DATA_TABLE_VALUE_KEY = "Value";
        private const string DATA_TABLE_TEXT_KEY  = "Text";

        private const string GIBBON_PROCESS_NAME = "Gibbon";

        private readonly string HomeDir;
        private readonly string GibbonDir;
        private readonly string TempEvacuationDir;
        private readonly string ConfigPath;
        private string MetaKeyLocaldPath;

        private readonly string initialTicks;

        private Config ConfigInstance;

        public MainForm()
        {
            initialTicks = DateTime.Now.Ticks.ToString();

            HomeDir           = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            GibbonDir         = HomeDir + @"\AppData\LocalLow\Broken Rules\Gibbon";
            TempEvacuationDir = $@"{GibbonDir}\{initialTicks}";
            ConfigPath        = $@"{GibbonDir}\config.yml";

            DataColumn column = new DataColumn();
            column.ColumnName = DATA_TABLE_TEXT_KEY;
            column.DataType   = typeof(string);
            DataTable.Columns.Add(column);

            column            = new DataColumn();
            column.ColumnName = DATA_TABLE_VALUE_KEY;
            column.DataType   = typeof(GraphicsQuality);
            DataTable.Columns.Add(column);

            DataRow row               = DataTable.NewRow();
            row[DATA_TABLE_TEXT_KEY]  = "高";
            row[DATA_TABLE_VALUE_KEY] = GraphicsQuality.High;
            DataTable.Rows.Add(row);

            row                       = DataTable.NewRow();
            row[DATA_TABLE_TEXT_KEY]  = "中";
            row[DATA_TABLE_VALUE_KEY] = GraphicsQuality.Middle;
            DataTable.Rows.Add(row);

            row                       = DataTable.NewRow();
            row[DATA_TABLE_TEXT_KEY]  = "低";
            row[DATA_TABLE_VALUE_KEY] = GraphicsQuality.Low;
            DataTable.Rows.Add(row);

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GraphicsQualityValue.DataSource    = DataTable;
            GraphicsQualityValue.DisplayMember = DATA_TABLE_TEXT_KEY;
            GraphicsQualityValue.ValueMember   = DATA_TABLE_VALUE_KEY;
            
            try
            {
                // Get (or Create) config file
                // ----------------------------------------------------------------
                CreateTemplateConfigFile();


                // Move existing save files into sub dir
                // ----------------------------------------------------------------
                ArchiveSaves();


                // Spread manipulated saves
                // ----------------------------------------------------------------
                CreateSaves();


                StatusTextBox.Text =
                    GetDateTimeStamp() +
                    "\n" +
                    MESSAGE_PARSE_SAVES +
                    "\n\n" +
                    MESSAGE_YOU_CAN_RESTORE_SAVES;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var processes = Process.GetProcessesByName(GIBBON_PROCESS_NAME);
            try
            {
                var gibbon_process = processes.First();

                var responce = MessageBox.Show(
                    "ゲームの起動中にこのウィンドウを閉じると、従来のセーブデータが" +
                    "破損する恐れがあります。それでも閉じますか？",
                    "警告",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (responce == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception)
            {
                // pass
            }


            // Delete & Restore saves
            // ----------------------------------------------------------------
            DeleteSaves();
            RestoreSaves();
        }

        private void RegenerateButton_Click(object sender, EventArgs e)
        {
            SaveConfigsToSaveFile();

            DeleteSaves();
            CreateSaves();

            StatusTextBox.Text =
                GetDateTimeStamp() +
                "\n" +
                MESSAGE_REGENERATE_SAVE +
                "\n\n" +
                MESSAGE_YOU_CAN_RESTORE_SAVES;
        }

        private void CreateTemplateConfigFile()
        {
            ConfigInstance = Config.Load(ConfigPath);

            if (ConfigInstance == null)
            {
                ConfigInstance = new Config();
                ConfigInstance.SaveAsYaml(ConfigPath);

                string text = MESSAGE_CREATE_CONFIG_FILE +
                    $"\n場所: {ConfigPath}";

                MessageBox.Show(
                    text,
                    "重要",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ConfigInstance = Config.Load(ConfigPath);
            }

            ReflectConfigsToGUI();
        }

        private void ReflectConfigsToGUI()
        {
            GameWindowWidth.Value  = ConfigInstance.GraphicsData.CurResolution.X;
            GameWindowHeight.Value = ConfigInstance.GraphicsData.CurResolution.Y;

            GraphicsQualityValue.SelectedValue = ConfigInstance.GraphicsData.GraphicsQuality;

            Fullscreen.Checked = ConfigInstance.GraphicsData.Fullscreen;

            BGMVolume.Value = (int)(ConfigInstance.AudioData.MusicVol * 100);
            SFXVolume.Value = (int)(ConfigInstance.AudioData.SfxVol   * 100);

            CreateEndingSaves.Checked = ConfigInstance.CreateEndingSaves;
        }

        private void SaveConfigsToSaveFile()
        {
            ConfigInstance.GraphicsData.CurResolution.X = (int)GameWindowWidth.Value ;
            ConfigInstance.GraphicsData.CurResolution.Y = (int)GameWindowHeight.Value;

            ConfigInstance.GraphicsData.GraphicsQuality = (GraphicsQuality)GraphicsQualityValue.SelectedValue;

            ConfigInstance.GraphicsData.Fullscreen = Fullscreen.Checked;

            ConfigInstance.AudioData.MusicVol = (double)(BGMVolume.Value / 100);
            ConfigInstance.AudioData.SfxVol   = (double)(SFXVolume.Value / 100);

            ConfigInstance.CreateEndingSaves = CreateEndingSaves.Checked;

            ConfigInstance.SaveAsYaml(ConfigPath);
        }

        private void CreateSaves()
        {
            var date_time = new DateTime(36, 1, 1);

            var profiles = new ProfileList();
            var ending_save = CreateEndingSaves.Checked;

            Guid guid = new Guid();

            for (int i = 0; i < 39; i++)
            {
                guid = Guid.NewGuid();

                var save_data = new SaveData(i, ending_save);
                var profile   = new Profile(guid, date_time.Ticks, date_time.Ticks);
                profiles.Add(profile);

                string save_data_path   = $@"{GibbonDir}\{guid}.synced.txt";
                string config_data_path = $@"{GibbonDir}\{guid}.local.txt";

                save_data.CreateFileWith(save_data_path);
                ConfigInstance.CreateFileWith(config_data_path);

                date_time = date_time.AddDays(1);
            }

            MetaKeyLocaldPath = $@"{GibbonDir}\META_KEY.synced.txt";
            profiles.CreateFileWith(MetaKeyLocaldPath);

            var meta_config = new MetaConfig(guid);

            MetaKeyLocaldPath = $@"{GibbonDir}\META_KEY.local.txt";
            meta_config.CreateFileWith(MetaKeyLocaldPath);
        }

        private void DeleteSaves()
        {
            string[] all_txt_files = Directory.GetFiles(GibbonDir, "*.txt");
            foreach (var txt_file in all_txt_files)
            {
                File.Delete(txt_file);
            }
        }

        private void ArchiveSaves()
        {
            Directory.CreateDirectory(TempEvacuationDir);
            string[] all_txt_files = Directory.GetFiles(GibbonDir, "*.txt");

            foreach (string txt_file in all_txt_files)
            {
                string file_name = Path.GetFileName(txt_file);

                string src = $@"{GibbonDir}\{file_name}";
                string dst = $@"{TempEvacuationDir}\{file_name}";

                File.Move(src, dst);
            }
        }

        private void RestoreSaves()
        {
            string[] all_txt_files = Directory.GetFiles(TempEvacuationDir, "*.txt");
            foreach (string txt_file in all_txt_files)
            {
                string file_name = Path.GetFileName(txt_file);

                string src = $@"{TempEvacuationDir}\{file_name}";
                string dst = $@"{GibbonDir}\{file_name}";

                File.Move(src, dst);
            }

            if (Directory.Exists(TempEvacuationDir))
            {
                Directory.Delete(TempEvacuationDir);
            }
        }

        private string GetDateTimeStamp()
        {
            return "[" + DateTime.Now.ToString() + "]";
        }
    }
}
