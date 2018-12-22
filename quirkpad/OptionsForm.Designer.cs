/*
 * Created by SharpDevelop.
 * User: cacan_000
 * Date: 2018/11/23
 * Time: PM 6:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace quirkpad
{
    partial class OptionsForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button chooseFont;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label fontLabel2;
        private System.Windows.Forms.Label keywordLabel;
        private System.Windows.Forms.RichTextBox keywordsBox;
        private System.Windows.Forms.Label warningLabel;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.chooseFont = new System.Windows.Forms.Button();
            this.fontLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.fontLabel2 = new System.Windows.Forms.Label();
            this.keywordLabel = new System.Windows.Forms.Label();
            this.keywordsBox = new System.Windows.Forms.RichTextBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chooseFont
            // 
            this.chooseFont.Location = new System.Drawing.Point(197, 12);
            this.chooseFont.Name = "chooseFont";
            this.chooseFont.Size = new System.Drawing.Size(75, 23);
            this.chooseFont.TabIndex = 0;
            this.chooseFont.Text = "Choose...";
            this.chooseFont.UseVisualStyleBackColor = true;
            this.chooseFont.Click += new System.EventHandler(this.ChooseFontClick);
            // 
            // fontLabel
            // 
            this.fontLabel.Location = new System.Drawing.Point(12, 9);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(57, 23);
            this.fontLabel.TabIndex = 1;
            this.fontLabel.Text = "Font:";
            this.fontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(197, 214);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // fontLabel2
            // 
            this.fontLabel2.Location = new System.Drawing.Point(75, 9);
            this.fontLabel2.Name = "fontLabel2";
            this.fontLabel2.Size = new System.Drawing.Size(100, 23);
            this.fontLabel2.TabIndex = 3;
            this.fontLabel2.Text = "label1";
            this.fontLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // keywordLabel
            // 
            this.keywordLabel.Location = new System.Drawing.Point(12, 32);
            this.keywordLabel.Name = "keywordLabel";
            this.keywordLabel.Size = new System.Drawing.Size(100, 23);
            this.keywordLabel.TabIndex = 5;
            this.keywordLabel.Text = "Keywords";
            this.keywordLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // keywordsBox
            // 
            this.keywordsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.keywordsBox.Location = new System.Drawing.Point(12, 58);
            this.keywordsBox.Name = "keywordsBox";
            this.keywordsBox.Size = new System.Drawing.Size(260, 116);
            this.keywordsBox.TabIndex = 6;
            this.keywordsBox.Text = "";
            this.keywordsBox.WordWrap = false;
            // 
            // warningLabel
            // 
            this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLabel.Location = new System.Drawing.Point(13, 181);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(259, 30);
            this.warningLabel.TabIndex = 7;
            this.warningLabel.Text = "* Changes will take effect after restarting Quirkpad. *";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 249);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.keywordsBox);
            this.Controls.Add(this.keywordLabel);
            this.Controls.Add(this.fontLabel2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.chooseFont);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.Text = "Quirkpad Options";
            this.ResumeLayout(false);

        }
    }
}
