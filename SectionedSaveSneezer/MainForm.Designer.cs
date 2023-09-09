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
            this.SuspendLayout();
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.BackColor = System.Drawing.Color.Snow;
            this.StatusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusTextBox.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StatusTextBox.Location = new System.Drawing.Point(17, 12);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.ReadOnly = true;
            this.StatusTextBox.Size = new System.Drawing.Size(254, 165);
            this.StatusTextBox.TabIndex = 2;
            this.StatusTextBox.Text = "初期化処理中…";
            // 
            // RegenerateButton
            // 
            this.RegenerateButton.Font = new System.Drawing.Font("Noto Sans JP", 9F);
            this.RegenerateButton.Location = new System.Drawing.Point(180, 183);
            this.RegenerateButton.Name = "RegenerateButton";
            this.RegenerateButton.Size = new System.Drawing.Size(90, 30);
            this.RegenerateButton.TabIndex = 3;
            this.RegenerateButton.Text = "再生成";
            this.RegenerateButton.UseVisualStyleBackColor = true;
            this.RegenerateButton.Click += new System.EventHandler(this.RegenerateButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(283, 225);
            this.Controls.Add(this.RegenerateButton);
            this.Controls.Add(this.StatusTextBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private RichTextBox StatusTextBox;
        private Button RegenerateButton;
    }
}

