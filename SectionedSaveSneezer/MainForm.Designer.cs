using System.Windows.Forms;

namespace SectionedSaveSneezer
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.StatusTextBox = new System.Windows.Forms.RichTextBox();
            this.RegenerateButton = new System.Windows.Forms.Button();
            this.CreateEndingSaves = new System.Windows.Forms.CheckBox();
            this.GameWindowWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GameWindowHeight = new System.Windows.Forms.NumericUpDown();
            this.Fullscreen = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BGMVolume = new System.Windows.Forms.NumericUpDown();
            this.SFXVolume = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.GraphicsQualityValue = new System.Windows.Forms.ComboBox();
            this.lable5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameWindowWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameWindowHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BGMVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SFXVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.BackColor = System.Drawing.Color.Snow;
            this.StatusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.StatusTextBox.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StatusTextBox.Location = new System.Drawing.Point(13, 15);
            this.StatusTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.ReadOnly = true;
            this.StatusTextBox.Size = new System.Drawing.Size(272, 271);
            this.StatusTextBox.TabIndex = 2;
            this.StatusTextBox.Text = "初期化処理中…";
            // 
            // RegenerateButton
            // 
            this.RegenerateButton.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RegenerateButton.Location = new System.Drawing.Point(350, 259);
            this.RegenerateButton.Margin = new System.Windows.Forms.Padding(4);
            this.RegenerateButton.Name = "RegenerateButton";
            this.RegenerateButton.Size = new System.Drawing.Size(105, 27);
            this.RegenerateButton.TabIndex = 3;
            this.RegenerateButton.Text = "再生成";
            this.RegenerateButton.UseVisualStyleBackColor = true;
            this.RegenerateButton.Click += new System.EventHandler(this.RegenerateButton_Click);
            // 
            // CreateEndingSaves
            // 
            this.CreateEndingSaves.AutoSize = true;
            this.CreateEndingSaves.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CreateEndingSaves.Location = new System.Drawing.Point(293, 232);
            this.CreateEndingSaves.Margin = new System.Windows.Forms.Padding(4);
            this.CreateEndingSaves.Name = "CreateEndingSaves";
            this.CreateEndingSaves.Size = new System.Drawing.Size(131, 19);
            this.CreateEndingSaves.TabIndex = 4;
            this.CreateEndingSaves.Text = "Create Ending Saves";
            this.CreateEndingSaves.UseVisualStyleBackColor = true;
            // 
            // GameWindowWidth
            // 
            this.GameWindowWidth.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GameWindowWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.GameWindowWidth.Location = new System.Drawing.Point(351, 13);
            this.GameWindowWidth.Margin = new System.Windows.Forms.Padding(4);
            this.GameWindowWidth.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.GameWindowWidth.Minimum = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.GameWindowWidth.Name = "GameWindowWidth";
            this.GameWindowWidth.Size = new System.Drawing.Size(104, 23);
            this.GameWindowWidth.TabIndex = 5;
            this.GameWindowWidth.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(293, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Width";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(293, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Height";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameWindowHeight
            // 
            this.GameWindowHeight.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GameWindowHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.GameWindowHeight.Location = new System.Drawing.Point(351, 44);
            this.GameWindowHeight.Margin = new System.Windows.Forms.Padding(4);
            this.GameWindowHeight.Maximum = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.GameWindowHeight.Minimum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.GameWindowHeight.Name = "GameWindowHeight";
            this.GameWindowHeight.Size = new System.Drawing.Size(104, 23);
            this.GameWindowHeight.TabIndex = 8;
            this.GameWindowHeight.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            // 
            // Fullscreen
            // 
            this.Fullscreen.AutoSize = true;
            this.Fullscreen.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Fullscreen.Location = new System.Drawing.Point(293, 104);
            this.Fullscreen.Margin = new System.Windows.Forms.Padding(4);
            this.Fullscreen.Name = "Fullscreen";
            this.Fullscreen.Size = new System.Drawing.Size(78, 19);
            this.Fullscreen.TabIndex = 9;
            this.Fullscreen.Text = "Fullscreen";
            this.Fullscreen.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(293, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "BGM";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BGMVolume
            // 
            this.BGMVolume.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BGMVolume.Location = new System.Drawing.Point(351, 131);
            this.BGMVolume.Margin = new System.Windows.Forms.Padding(4);
            this.BGMVolume.Name = "BGMVolume";
            this.BGMVolume.Size = new System.Drawing.Size(103, 23);
            this.BGMVolume.TabIndex = 11;
            this.BGMVolume.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // SFXVolume
            // 
            this.SFXVolume.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SFXVolume.Location = new System.Drawing.Point(351, 162);
            this.SFXVolume.Margin = new System.Windows.Forms.Padding(4);
            this.SFXVolume.Name = "SFXVolume";
            this.SFXVolume.Size = new System.Drawing.Size(104, 23);
            this.SFXVolume.TabIndex = 12;
            this.SFXVolume.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(293, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "SFX";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GraphicsQualityValue
            // 
            this.GraphicsQualityValue.FormattingEnabled = true;
            this.GraphicsQualityValue.Location = new System.Drawing.Point(351, 74);
            this.GraphicsQualityValue.Name = "GraphicsQualityValue";
            this.GraphicsQualityValue.Size = new System.Drawing.Size(104, 23);
            this.GraphicsQualityValue.TabIndex = 14;
            // 
            // lable5
            // 
            this.lable5.AutoSize = true;
            this.lable5.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lable5.Location = new System.Drawing.Point(293, 77);
            this.lable5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lable5.Name = "lable5";
            this.lable5.Size = new System.Drawing.Size(46, 15);
            this.lable5.TabIndex = 15;
            this.lable5.Text = "Quarity";
            this.lable5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(467, 299);
            this.Controls.Add(this.lable5);
            this.Controls.Add(this.GraphicsQualityValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SFXVolume);
            this.Controls.Add(this.BGMVolume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Fullscreen);
            this.Controls.Add(this.GameWindowHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GameWindowWidth);
            this.Controls.Add(this.CreateEndingSaves);
            this.Controls.Add(this.RegenerateButton);
            this.Controls.Add(this.StatusTextBox);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GameWindowWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameWindowHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BGMVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SFXVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RichTextBox StatusTextBox;
        private Button RegenerateButton;
    private CheckBox CreateEndingSaves;
        private NumericUpDown GameWindowWidth;
        private Label label1;
        private Label label2;
        private NumericUpDown GameWindowHeight;
        private CheckBox Fullscreen;
        private Label label3;
        private NumericUpDown BGMVolume;
        private NumericUpDown SFXVolume;
        private Label label4;
        private ComboBox GraphicsQualityValue;
        private Label lable5;
    }
}

