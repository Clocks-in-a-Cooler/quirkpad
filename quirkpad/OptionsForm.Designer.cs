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
            this.SuspendLayout();
            // 
            // chooseFont
            // 
            this.chooseFont.Location = new System.Drawing.Point(197, 40);
            this.chooseFont.Name = "chooseFont";
            this.chooseFont.Size = new System.Drawing.Size(75, 23);
            this.chooseFont.TabIndex = 0;
            this.chooseFont.Text = "Choose...";
            this.chooseFont.UseVisualStyleBackColor = true;
            this.chooseFont.Click += new System.EventHandler(this.ChooseFontClick);
            // 
            // fontLabel
            // 
            this.fontLabel.Location = new System.Drawing.Point(12, 40);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(57, 23);
            this.fontLabel.TabIndex = 1;
            this.fontLabel.Text = "Font:";
            this.fontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(197, 181);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // fontLabel2
            // 
            this.fontLabel2.Location = new System.Drawing.Point(75, 40);
            this.fontLabel2.Name = "fontLabel2";
            this.fontLabel2.Size = new System.Drawing.Size(100, 23);
            this.fontLabel2.TabIndex = 3;
            this.fontLabel2.Text = "label1";
            this.fontLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 216);
            this.Controls.Add(this.fontLabel2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.chooseFont);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.Text = "Quirkpad Options";
            this.ResumeLayout(false);

        }
    }
}
