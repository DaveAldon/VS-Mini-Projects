namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.runBtn = new System.Windows.Forms.Button();
            this.lblRecordsProc = new System.Windows.Forms.Label();
            this.lblErrorsProc = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblErrors = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(22, 55);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(121, 23);
            this.runBtn.TabIndex = 0;
            this.runBtn.Text = "Run!";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click_1);
            // 
            // lblRecordsProc
            // 
            this.lblRecordsProc.AutoSize = true;
            this.lblRecordsProc.Location = new System.Drawing.Point(19, 92);
            this.lblRecordsProc.Name = "lblRecordsProc";
            this.lblRecordsProc.Size = new System.Drawing.Size(100, 13);
            this.lblRecordsProc.TabIndex = 1;
            this.lblRecordsProc.Text = "Records Processed";
            // 
            // lblErrorsProc
            // 
            this.lblErrorsProc.AutoSize = true;
            this.lblErrorsProc.Location = new System.Drawing.Point(32, 115);
            this.lblErrorsProc.Name = "lblErrorsProc";
            this.lblErrorsProc.Size = new System.Drawing.Size(87, 13);
            this.lblErrorsProc.TabIndex = 2;
            this.lblErrorsProc.Text = "Errors Processed";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRecords.Location = new System.Drawing.Point(125, 92);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(18, 15);
            this.lblRecords.TabIndex = 3;
            this.lblRecords.Text = "   ";
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblErrors.Location = new System.Drawing.Point(125, 115);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(18, 15);
            this.lblErrors.TabIndex = 4;
            this.lblErrors.Text = "   ";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(5, 19);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(157, 13);
            this.lblAuthor.TabIndex = 5;
            this.lblAuthor.Text = "Homework 1 by David Crawford";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(166, 155);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.lblErrorsProc);
            this.Controls.Add(this.lblRecordsProc);
            this.Controls.Add(this.runBtn);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Label lblRecordsProc;
        private System.Windows.Forms.Label lblErrorsProc;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.Label lblAuthor;
    }
}

