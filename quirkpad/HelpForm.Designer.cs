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
        private System.Windows.Forms.LinkLabel MITLicenseLink;
        private System.Windows.Forms.LinkLabel LGPLLink;
        private System.Windows.Forms.LinkLabel SnippetCompilerLink;
        private System.Windows.Forms.Label LineLabel;
        
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
            this.MITLicenseLink = new System.Windows.Forms.LinkLabel();
            this.LGPLLink = new System.Windows.Forms.LinkLabel();
            this.SnippetCompilerLink = new System.Windows.Forms.LinkLabel();
            this.LineLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AboutLabel
            // 
            this.AboutLabel.Location = new System.Drawing.Point(13, 9);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(208, 158);
            this.AboutLabel.TabIndex = 0;
            this.AboutLabel.Text = resources.GetString("AboutLabel.Text");
            // 
            // FCTBLink
            // 
            this.FCTBLink.Location = new System.Drawing.Point(13, 99);
            this.FCTBLink.Name = "FCTBLink";
            this.FCTBLink.Size = new System.Drawing.Size(110, 15);
            this.FCTBLink.TabIndex = 1;
            this.FCTBLink.TabStop = true;
            this.FCTBLink.Text = "FastColouredTextBox,";
            this.FCTBLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FCTBLinkLinkClicked);
            // 
            // pathLabel
            // 
            this.pathLabel.Location = new System.Drawing.Point(12, 184);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(280, 25);
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
            // MITLicenseLink
            // 
            this.MITLicenseLink.Location = new System.Drawing.Point(13, 62);
            this.MITLicenseLink.Name = "MITLicenseLink";
            this.MITLicenseLink.Size = new System.Drawing.Size(66, 18);
            this.MITLicenseLink.TabIndex = 4;
            this.MITLicenseLink.TabStop = true;
            this.MITLicenseLink.Text = "MIT license.";
            this.MITLicenseLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MITLicenseLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MITLicenseLinkLinkClicked);
            // 
            // LGPLLink
            // 
            this.LGPLLink.Location = new System.Drawing.Point(60, 113);
            this.LGPLLink.Name = "LGPLLink";
            this.LGPLLink.Size = new System.Drawing.Size(80, 18);
            this.LGPLLink.TabIndex = 5;
            this.LGPLLink.TabStop = true;
            this.LGPLLink.Text = "LGPL License.";
            this.LGPLLink.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LGPLLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LGPLLinkLinkClicked);
            // 
            // SnippetCompilerLink
            // 
            this.SnippetCompilerLink.Location = new System.Drawing.Point(131, 134);
            this.SnippetCompilerLink.Name = "SnippetCompilerLink";
            this.SnippetCompilerLink.Size = new System.Drawing.Size(90, 23);
            this.SnippetCompilerLink.TabIndex = 6;
            this.SnippetCompilerLink.TabStop = true;
            this.SnippetCompilerLink.Text = "Snippet Compiler.";
            this.SnippetCompilerLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SnippetCompilerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SnippetCompilerLinkLinkClicked);
            // 
            // LineLabel
            // 
            this.LineLabel.Location = new System.Drawing.Point(13, 158);
            this.LineLabel.Name = "LineLabel";
            this.LineLabel.Size = new System.Drawing.Size(279, 23);
            this.LineLabel.TabIndex = 7;
            this.LineLabel.Text = "______________________________________________________";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 220);
            this.Controls.Add(this.LineLabel);
            this.Controls.Add(this.SnippetCompilerLink);
            this.Controls.Add(this.LGPLLink);
            this.Controls.Add(this.MITLicenseLink);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.FCTBLink);
            this.Controls.Add(this.AboutLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpForm";
            this.Text = "About Quirkpad";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
