/*
 * Created by SharpDevelop.
 * User: cacan_000
 * Date: 2018/12/24
 * Time: PM 8:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace quirkpad
{
    partial class InfoForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TabControl helpTab;
        private System.Windows.Forms.TabPage basicTabPage;
        private System.Windows.Forms.TabPage advancedTabPage;
        private System.Windows.Forms.TabPage moreTabPage;
        private System.Windows.Forms.Label githubLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label issuesLabel;
        private System.Windows.Forms.LinkLabel githubLink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.titleLabel = new System.Windows.Forms.Label();
            this.helpTab = new System.Windows.Forms.TabControl();
            this.basicTabPage = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.advancedTabPage = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.moreTabPage = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.issuesLabel = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.githubLabel = new System.Windows.Forms.Label();
            this.helpTab.SuspendLayout();
            this.basicTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.advancedTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.moreTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(13, 13);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(373, 23);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Quickly learn to use Quirkpad.";
            // 
            // helpTab
            // 
            this.helpTab.Controls.Add(this.basicTabPage);
            this.helpTab.Controls.Add(this.advancedTabPage);
            this.helpTab.Controls.Add(this.moreTabPage);
            this.helpTab.Location = new System.Drawing.Point(13, 40);
            this.helpTab.Name = "helpTab";
            this.helpTab.SelectedIndex = 0;
            this.helpTab.Size = new System.Drawing.Size(373, 273);
            this.helpTab.TabIndex = 1;
            // 
            // basicTabPage
            // 
            this.basicTabPage.Controls.Add(this.pictureBox1);
            this.basicTabPage.Location = new System.Drawing.Point(4, 22);
            this.basicTabPage.Name = "basicTabPage";
            this.basicTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.basicTabPage.Size = new System.Drawing.Size(365, 247);
            this.basicTabPage.TabIndex = 0;
            this.basicTabPage.Text = "The Basics";
            this.basicTabPage.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(353, 235);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // advancedTabPage
            // 
            this.advancedTabPage.Controls.Add(this.pictureBox3);
            this.advancedTabPage.Controls.Add(this.pictureBox2);
            this.advancedTabPage.Location = new System.Drawing.Point(4, 22);
            this.advancedTabPage.Name = "advancedTabPage";
            this.advancedTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.advancedTabPage.Size = new System.Drawing.Size(365, 247);
            this.advancedTabPage.TabIndex = 1;
            this.advancedTabPage.Text = "Advanced";
            this.advancedTabPage.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(187, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(172, 234);
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(7, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(174, 234);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // moreTabPage
            // 
            this.moreTabPage.Controls.Add(this.linkLabel1);
            this.moreTabPage.Controls.Add(this.issuesLabel);
            this.moreTabPage.Controls.Add(this.githubLink);
            this.moreTabPage.Controls.Add(this.githubLabel);
            this.moreTabPage.Location = new System.Drawing.Point(4, 22);
            this.moreTabPage.Name = "moreTabPage";
            this.moreTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.moreTabPage.Size = new System.Drawing.Size(365, 247);
            this.moreTabPage.TabIndex = 2;
            this.moreTabPage.Text = "More";
            this.moreTabPage.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(46, 33);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(313, 23);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/clocks-in-a-cooler/quirkpad/issues";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
            // 
            // issuesLabel
            // 
            this.issuesLabel.Location = new System.Drawing.Point(7, 34);
            this.issuesLabel.Name = "issuesLabel";
            this.issuesLabel.Size = new System.Drawing.Size(100, 23);
            this.issuesLabel.TabIndex = 2;
            this.issuesLabel.Text = "Issues:";
            this.issuesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // githubLink
            // 
            this.githubLink.Location = new System.Drawing.Point(46, 7);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(313, 23);
            this.githubLink.TabIndex = 1;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "https://www.github.com/clocks-in-a-cooler/quirkpad";
            this.githubLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GithubLinkLinkClicked);
            // 
            // githubLabel
            // 
            this.githubLabel.Location = new System.Drawing.Point(7, 7);
            this.githubLabel.Name = "githubLabel";
            this.githubLabel.Size = new System.Drawing.Size(352, 23);
            this.githubLabel.TabIndex = 0;
            this.githubLabel.Text = "Github:";
            this.githubLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 325);
            this.Controls.Add(this.helpTab);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfoForm";
            this.Text = "Quirkpad Help";
            this.helpTab.ResumeLayout(false);
            this.basicTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.advancedTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.moreTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
