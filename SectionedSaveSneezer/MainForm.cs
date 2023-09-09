using System;
using System.IO;
using System.Windows.Forms;

namespace SectionedSaveSneezer
{
    public partial class MainForm : Form
    {
        private readonly string homeDir;
        private readonly string gibbonDir;
        private readonly string tempEvacuationDir;
        private readonly string configPath;

        private readonly string initialTicks;

        public MainForm()
        {
            initialTicks = DateTime.Now.Ticks.ToString();

            homeDir           = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            gibbonDir         = homeDir + @"\AppData\LocalLow\Broken Rules\Gibbon";
            tempEvacuationDir = $@"{gibbonDir}\{initialTicks}";
            configPath        = $@"{gibbonDir}\config.yml";

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // var save_params = new List<SaveParam>() {
            //     new(0, 0, 0)
            // };

            try
            {
                // Get (or Create) config file
                // ----------------------------------------------------------------

                Config config = Config.Load(configPath);

                if (config == null)
                {
                    config = new Config();
                    config.CreateFileWith(configPath);

                    string text = "コンフィグ用ファイルを作成しました。" +
                        "確認し、必要に応じて編集し終えたら Enter キーを押してください。" +
                        $"\n場所: {configPath}";

                    MessageBox.Show(
                        text, 
                        "重要",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }


                // Move existing save files into sub dir
                // ----------------------------------------------------------------

                Directory.CreateDirectory(tempEvacuationDir);
                string[] all_txt_files = Directory.GetFiles(gibbonDir, "*.txt");

                foreach (string txt_file in all_txt_files)
                {
                    string file_name = Path.GetFileName(txt_file);

                    string src = $@"{gibbonDir}\{file_name}";
                    string dst = $@"{tempEvacuationDir}\{file_name}";

                    File.Move(src, dst);
                }


                // Spread manipulated saves
                // ----------------------------------------------------------------

                var dateTime = new DateTime(36, 1, 1);

                var profiles = new ProfileList();

                for (int i = 0; i < 39; i++)
                {
                    Guid guid = Guid.NewGuid();
                    var saveData = new SaveData(i);

                    var profile = new Profile(guid, dateTime.Ticks, dateTime.Ticks);
                    profiles.Add(profile);

                    string save_data_path   = $@"{gibbonDir}\{guid}.synced.txt";
                    string config_data_path = $@"{gibbonDir}\{guid}.local.txt";

                    saveData.CreateFileWith(save_data_path);
                    config.CreateFileWith(config_data_path);

                    dateTime = dateTime.AddDays(1);
                }

                string meta_key_synced_path = $@"{gibbonDir}\META_KEY.synced.txt";
                profiles.CreateFileWith(meta_key_synced_path);

                StatusTextBox.Text = "元々あったセーブデータを一時的に退避させ、" +
                        "練習用セーブデータを展開しました。\n\n" +
                        "このウィンドウを閉じると元々あったセーブデータが復帰します。";
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
            // Delete & Restore saves
            // ----------------------------------------------------------------
            DeleteSaves();
            RestoreSaves();
        }

        private void DeleteSaves()
        {
            string[] all_txt_files = Directory.GetFiles(gibbonDir, "*.txt");
            foreach (var txt_file in all_txt_files)
            {
                File.Delete(txt_file);
            }
        }

        private void RestoreSaves()
        {
            string[] all_txt_files = Directory.GetFiles(tempEvacuationDir, "*.txt");
            foreach (string txt_file in all_txt_files)
            {
                string file_name = Path.GetFileName(txt_file);

                string src = $@"{tempEvacuationDir}\{file_name}";
                string dst = $@"{gibbonDir}\{file_name}";

                File.Move(src, dst);
            }

            if (Directory.Exists(tempEvacuationDir))
            {
                Directory.Delete(tempEvacuationDir);
            }
        }
    }
}
