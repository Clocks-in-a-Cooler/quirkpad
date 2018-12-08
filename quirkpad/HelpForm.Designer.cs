/*
 * Created by SharpDevelop.
 * User: cacan_000
 * Date: 2018/11/23
 * Time: PM 5:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace quirkpad
{
    partial class HelpForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label AboutLabel;
        private System.Windows.Forms.LinkLabel FCTBLink;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.AboutLabel = new System.Windows.Forms.Label();
            this.FCTBLink = new System.Windows.Forms.LinkLabel();
            this.pathLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AboutLabel
            // 
            this.AboutLabel.Location = new System.Drawing.Point(12, 9);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(208, 89);
            this.AboutLabel.TabIndex = 0;
            this.AboutLabel.Text = "Quirkpad v0.6\r\nby Clocks-in-a-Cooler\r\n\r\nThis app is built with Pavel Torgashov\'s " +
    "FastColoredTextBox.";
            // 
            // FCTBLink
            // 
            this.FCTBLink.Location = new System.Drawing.Point(12, 62);
            this.FCTBLink.Name = "FCTBLink";
            this.FCTBLink.Size = new System.Drawing.Size(129, 18);
            this.FCTBLink.TabIndex = 1;
            this.FCTBLink.TabStop = true;
            this.FCTBLink.Text = "Fast Coloured Text Box.";
            this.FCTBLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FCTBLinkLinkClicked);
            // 
            // pathLabel
            // 
            this.pathLabel.Location = new System.Drawing.Point(13, 102);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(295, 23);
            this.pathLabel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(227, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 67);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 140);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.FCTBLink);
            this.Controls.Add(this.AboutLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpForm";
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
