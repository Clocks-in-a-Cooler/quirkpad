﻿/*
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
        private System.Windows.Forms.RadioButton allRadioButton;
        private System.Windows.Forms.RadioButton visibleRadioButton;
        private System.Windows.Forms.RadioButton changedRadioButton;
        private System.Windows.Forms.GroupBox highlightGroupBox;
        private System.Windows.Forms.Label highlightRangeLabel;
        private System.Windows.Forms.GroupBox themeGroupBox;
        private System.Windows.Forms.RadioButton darkThemeRadioButton;
        private System.Windows.Forms.RadioButton lightThemeRadioButton;
        
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
            this.allRadioButton = new System.Windows.Forms.RadioButton();
            this.visibleRadioButton = new System.Windows.Forms.RadioButton();
            this.changedRadioButton = new System.Windows.Forms.RadioButton();
            this.highlightGroupBox = new System.Windows.Forms.GroupBox();
            this.highlightRangeLabel = new System.Windows.Forms.Label();
            this.themeGroupBox = new System.Windows.Forms.GroupBox();
            this.darkThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.lightThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.highlightGroupBox.SuspendLayout();
            this.themeGroupBox.SuspendLayout();
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
            this.okButton.Location = new System.Drawing.Point(197, 237);
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
            // allRadioButton
            // 
            this.allRadioButton.Location = new System.Drawing.Point(6, 19);
            this.allRadioButton.Name = "allRadioButton";
            this.allRadioButton.Size = new System.Drawing.Size(104, 24);
            this.allRadioButton.TabIndex = 9;
            this.allRadioButton.TabStop = true;
            this.allRadioButton.Text = "All";
            this.allRadioButton.UseVisualStyleBackColor = true;
            this.allRadioButton.CheckedChanged += new System.EventHandler(this.AllRadioButtonCheckedChanged);
            // 
            // visibleRadioButton
            // 
            this.visibleRadioButton.Location = new System.Drawing.Point(6, 43);
            this.visibleRadioButton.Name = "visibleRadioButton";
            this.visibleRadioButton.Size = new System.Drawing.Size(104, 21);
            this.visibleRadioButton.TabIndex = 11;
            this.visibleRadioButton.TabStop = true;
            this.visibleRadioButton.Text = "Visible";
            this.visibleRadioButton.UseVisualStyleBackColor = true;
            this.visibleRadioButton.CheckedChanged += new System.EventHandler(this.VisibleRadioButtonCheckedChanged);
            // 
            // changedRadioButton
            // 
            this.changedRadioButton.Location = new System.Drawing.Point(6, 66);
            this.changedRadioButton.Name = "changedRadioButton";
            this.changedRadioButton.Size = new System.Drawing.Size(104, 24);
            this.changedRadioButton.TabIndex = 12;
            this.changedRadioButton.TabStop = true;
            this.changedRadioButton.Text = "Changed";
            this.changedRadioButton.UseVisualStyleBackColor = true;
            this.changedRadioButton.CheckedChanged += new System.EventHandler(this.ChangedRadioButtonCheckedChanged);
            // 
            // highlightGroupBox
            // 
            this.highlightGroupBox.Controls.Add(this.highlightRangeLabel);
            this.highlightGroupBox.Controls.Add(this.allRadioButton);
            this.highlightGroupBox.Controls.Add(this.changedRadioButton);
            this.highlightGroupBox.Controls.Add(this.visibleRadioButton);
            this.highlightGroupBox.Location = new System.Drawing.Point(12, 41);
            this.highlightGroupBox.Name = "highlightGroupBox";
            this.highlightGroupBox.Size = new System.Drawing.Size(260, 97);
            this.highlightGroupBox.TabIndex = 13;
            this.highlightGroupBox.TabStop = false;
            this.highlightGroupBox.Text = "Highlighting Range";
            // 
            // highlightRangeLabel
            // 
            this.highlightRangeLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.highlightRangeLabel.Location = new System.Drawing.Point(116, 16);
            this.highlightRangeLabel.Name = "highlightRangeLabel";
            this.highlightRangeLabel.Size = new System.Drawing.Size(137, 71);
            this.highlightRangeLabel.TabIndex = 13;
            // 
            // themeGroupBox
            // 
            this.themeGroupBox.Controls.Add(this.darkThemeRadioButton);
            this.themeGroupBox.Controls.Add(this.lightThemeRadioButton);
            this.themeGroupBox.Location = new System.Drawing.Point(12, 145);
            this.themeGroupBox.Name = "themeGroupBox";
            this.themeGroupBox.Size = new System.Drawing.Size(260, 85);
            this.themeGroupBox.TabIndex = 14;
            this.themeGroupBox.TabStop = false;
            this.themeGroupBox.Text = "Editor Theme";
            // 
            // darkThemeRadioButton
            // 
            this.darkThemeRadioButton.Location = new System.Drawing.Point(7, 50);
            this.darkThemeRadioButton.Name = "darkThemeRadioButton";
            this.darkThemeRadioButton.Size = new System.Drawing.Size(104, 24);
            this.darkThemeRadioButton.TabIndex = 1;
            this.darkThemeRadioButton.TabStop = true;
            this.darkThemeRadioButton.Text = "Dark";
            this.darkThemeRadioButton.UseVisualStyleBackColor = true;
            this.darkThemeRadioButton.CheckedChanged += new System.EventHandler(this.DarkThemeRadioButtonCheckedChanged);
            // 
            // lightThemeRadioButton
            // 
            this.lightThemeRadioButton.Location = new System.Drawing.Point(7, 20);
            this.lightThemeRadioButton.Name = "lightThemeRadioButton";
            this.lightThemeRadioButton.Size = new System.Drawing.Size(104, 24);
            this.lightThemeRadioButton.TabIndex = 0;
            this.lightThemeRadioButton.TabStop = true;
            this.lightThemeRadioButton.Text = "Light";
            this.lightThemeRadioButton.UseVisualStyleBackColor = true;
            this.lightThemeRadioButton.CheckedChanged += new System.EventHandler(this.LightThemeRadioButtonCheckedChanged);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 272);
            this.Controls.Add(this.themeGroupBox);
            this.Controls.Add(this.highlightGroupBox);
            this.Controls.Add(this.fontLabel2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.chooseFont);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.Text = "Quirkpad Options";
            this.highlightGroupBox.ResumeLayout(false);
            this.themeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
