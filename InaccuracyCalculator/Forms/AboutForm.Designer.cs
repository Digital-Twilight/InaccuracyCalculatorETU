namespace InaccuracyCalculator
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.MainLabel = new System.Windows.Forms.Label();
            this.ProgramIcon = new System.Windows.Forms.PictureBox();
            this.AdditionalInformation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainLabel.Location = new System.Drawing.Point(146, 12);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(658, 32);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Администрация СПбГЭТУ «ЛЭТИ» не имеет никакого отношения к данной программе.\r\nПро" +
    "грамма создана с целью помочь студентам в ходе выполнения лабораторных работ по " +
    "физике.";
            // 
            // ProgramIcon
            // 
            this.ProgramIcon.Image = global::InaccuracyCalculator.Properties.Resources.picture;
            this.ProgramIcon.Location = new System.Drawing.Point(12, 12);
            this.ProgramIcon.Name = "ProgramIcon";
            this.ProgramIcon.Size = new System.Drawing.Size(128, 128);
            this.ProgramIcon.TabIndex = 1;
            this.ProgramIcon.TabStop = false;
            // 
            // AdditionalInformation
            // 
            this.AdditionalInformation.AutoSize = true;
            this.AdditionalInformation.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.AdditionalInformation.Location = new System.Drawing.Point(12, 143);
            this.AdditionalInformation.Name = "AdditionalInformation";
            this.AdditionalInformation.Size = new System.Drawing.Size(309, 26);
            this.AdditionalInformation.TabIndex = 2;
            this.AdditionalInformation.Text = "По всем вопросам обращаться в Telegram @Digital_Twilight\r\nMade By Phantom";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 178);
            this.Controls.Add(this.AdditionalInformation);
            this.Controls.Add(this.ProgramIcon);
            this.Controls.Add(this.MainLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.Text = "О программе";
            ((System.ComponentModel.ISupportInitialize)(this.ProgramIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.PictureBox ProgramIcon;
        private System.Windows.Forms.Label AdditionalInformation;
    }
}