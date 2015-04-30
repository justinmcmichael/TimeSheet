namespace TimeSheet
{
    partial class MainEntryForm
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
            this.submitRecord = new System.Windows.Forms.Button();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.projectChooser = new System.Windows.Forms.ComboBox();
            this.DataEntry = new System.Windows.Forms.GroupBox();
            this.hoursEntry = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.activityChooser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.issuesList = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chooseExcelFile = new System.Windows.Forms.Button();
            this.excelFileLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.isSRED = new System.Windows.Forms.RadioButton();
            this.isIRAP = new System.Windows.Forms.RadioButton();
            this.DataEntry.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // submitRecord
            // 
            this.submitRecord.Location = new System.Drawing.Point(826, 169);
            this.submitRecord.Name = "submitRecord";
            this.submitRecord.Size = new System.Drawing.Size(75, 23);
            this.submitRecord.TabIndex = 9;
            this.submitRecord.Text = "Submit";
            this.submitRecord.UseVisualStyleBackColor = true;
            this.submitRecord.Click += new System.EventHandler(this.submitRecord_Click);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(6, 82);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 4;
            this.datePicker.Value = new System.DateTime(2015, 4, 2, 10, 56, 53, 0);
            // 
            // projectChooser
            // 
            this.projectChooser.FormattingEnabled = true;
            this.projectChooser.Location = new System.Drawing.Point(212, 81);
            this.projectChooser.Name = "projectChooser";
            this.projectChooser.Size = new System.Drawing.Size(295, 21);
            this.projectChooser.TabIndex = 5;
            this.projectChooser.TabStop = false;
            // 
            // DataEntry
            // 
            this.DataEntry.Controls.Add(this.isIRAP);
            this.DataEntry.Controls.Add(this.isSRED);
            this.DataEntry.Controls.Add(this.hoursLabel);
            this.DataEntry.Controls.Add(this.hoursEntry);
            this.DataEntry.Controls.Add(this.label6);
            this.DataEntry.Controls.Add(this.activityChooser);
            this.DataEntry.Controls.Add(this.label3);
            this.DataEntry.Controls.Add(this.label2);
            this.DataEntry.Controls.Add(this.label1);
            this.DataEntry.Controls.Add(this.issuesList);
            this.DataEntry.Controls.Add(this.datePicker);
            this.DataEntry.Controls.Add(this.submitRecord);
            this.DataEntry.Controls.Add(this.projectChooser);
            this.DataEntry.Location = new System.Drawing.Point(12, 109);
            this.DataEntry.Name = "DataEntry";
            this.DataEntry.Size = new System.Drawing.Size(909, 195);
            this.DataEntry.TabIndex = 3;
            this.DataEntry.TabStop = false;
            this.DataEntry.Text = "IRAP/SR&ED Data Entry";
            // 
            // hoursEntry
            // 
            this.hoursEntry.Location = new System.Drawing.Point(704, 81);
            this.hoursEntry.Name = "hoursEntry";
            this.hoursEntry.Size = new System.Drawing.Size(100, 20);
            this.hoursEntry.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Activity";
            // 
            // activityChooser
            // 
            this.activityChooser.FormattingEnabled = true;
            this.activityChooser.Location = new System.Drawing.Point(513, 81);
            this.activityChooser.Name = "activityChooser";
            this.activityChooser.Size = new System.Drawing.Size(184, 21);
            this.activityChooser.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Github Issues (space separarted)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Project";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Date and Time";
            // 
            // issuesList
            // 
            this.issuesList.Location = new System.Drawing.Point(6, 169);
            this.issuesList.Name = "issuesList";
            this.issuesList.Size = new System.Drawing.Size(813, 20);
            this.issuesList.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chooseExcelFile);
            this.groupBox1.Controls.Add(this.excelFileLocation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.userName);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 90);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Timesheel Excel File Location";
            // 
            // chooseExcelFile
            // 
            this.chooseExcelFile.Location = new System.Drawing.Point(820, 44);
            this.chooseExcelFile.Name = "chooseExcelFile";
            this.chooseExcelFile.Size = new System.Drawing.Size(75, 23);
            this.chooseExcelFile.TabIndex = 2;
            this.chooseExcelFile.Text = "Browse";
            this.chooseExcelFile.UseVisualStyleBackColor = true;
            this.chooseExcelFile.Click += new System.EventHandler(this.chooseExcelFile_Click);
            // 
            // excelFileLocation
            // 
            this.excelFileLocation.AcceptsReturn = true;
            this.excelFileLocation.AllowDrop = true;
            this.excelFileLocation.Location = new System.Drawing.Point(209, 46);
            this.excelFileLocation.Name = "excelFileLocation";
            this.excelFileLocation.Size = new System.Drawing.Size(605, 20);
            this.excelFileLocation.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Your Name (first_last)";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(6, 46);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(194, 20);
            this.userName.TabIndex = 0;
            // 
            // hoursLabel
            // 
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Location = new System.Drawing.Point(704, 62);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(35, 13);
            this.hoursLabel.TabIndex = 10;
            this.hoursLabel.Text = "Hours";
            // 
            // isSRED
            // 
            this.isSRED.AutoSize = true;
            this.isSRED.Location = new System.Drawing.Point(215, 108);
            this.isSRED.Name = "isSRED";
            this.isSRED.Size = new System.Drawing.Size(55, 17);
            this.isSRED.TabIndex = 11;
            this.isSRED.TabStop = true;
            this.isSRED.Text = "SRED";
            this.isSRED.UseVisualStyleBackColor = true;
            // 
            // isIRAP
            // 
            this.isIRAP.AutoSize = true;
            this.isIRAP.Checked = true;
            this.isIRAP.Location = new System.Drawing.Point(277, 109);
            this.isIRAP.Name = "isIRAP";
            this.isIRAP.Size = new System.Drawing.Size(50, 17);
            this.isIRAP.TabIndex = 12;
            this.isIRAP.TabStop = true;
            this.isIRAP.Text = "IRAP";
            this.isIRAP.UseVisualStyleBackColor = true;
            this.isIRAP.CheckedChanged += new System.EventHandler(this.isIRAP_CheckedChanged);
            // 
            // MainEntryForm
            // 
            this.AcceptButton = this.submitRecord;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 328);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DataEntry);
            this.Name = "MainEntryForm";
            this.Text = "EZSheet";
            this.DataEntry.ResumeLayout(false);
            this.DataEntry.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button submitRecord;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ComboBox projectChooser;
        private System.Windows.Forms.GroupBox DataEntry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox issuesList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button chooseExcelFile;
        private System.Windows.Forms.TextBox excelFileLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox activityChooser;
        private System.Windows.Forms.TextBox hoursEntry;
        private System.Windows.Forms.Label hoursLabel;
        private System.Windows.Forms.RadioButton isIRAP;
        private System.Windows.Forms.RadioButton isSRED;
    }
}

