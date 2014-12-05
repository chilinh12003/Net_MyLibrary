namespace CreateConnection
{
    partial class CreateLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_Domain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_IP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_License = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_Month = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_Day = new System.Windows.Forms.TextBox();
            this.btn_CreateLicense = new System.Windows.Forms.Button();
            this.tbx_Year = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Domain";
            // 
            // tbx_Domain
            // 
            this.tbx_Domain.Location = new System.Drawing.Point(68, 9);
            this.tbx_Domain.Name = "tbx_Domain";
            this.tbx_Domain.Size = new System.Drawing.Size(151, 20);
            this.tbx_Domain.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "IP";
            // 
            // tbx_IP
            // 
            this.tbx_IP.Location = new System.Drawing.Point(288, 9);
            this.tbx_IP.Name = "tbx_IP";
            this.tbx_IP.Size = new System.Drawing.Size(115, 20);
            this.tbx_IP.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Year";
            // 
            // tbx_License
            // 
            this.tbx_License.Location = new System.Drawing.Point(20, 142);
            this.tbx_License.Multiline = true;
            this.tbx_License.Name = "tbx_License";
            this.tbx_License.Size = new System.Drawing.Size(383, 90);
            this.tbx_License.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Month";
            // 
            // tbx_Month
            // 
            this.tbx_Month.Location = new System.Drawing.Point(194, 48);
            this.tbx_Month.Name = "tbx_Month";
            this.tbx_Month.Size = new System.Drawing.Size(67, 20);
            this.tbx_Month.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Day";
            // 
            // tbx_Day
            // 
            this.tbx_Day.Location = new System.Drawing.Point(336, 48);
            this.tbx_Day.Name = "tbx_Day";
            this.tbx_Day.Size = new System.Drawing.Size(67, 20);
            this.tbx_Day.TabIndex = 4;
            // 
            // btn_CreateLicense
            // 
            this.btn_CreateLicense.Location = new System.Drawing.Point(174, 97);
            this.btn_CreateLicense.Name = "btn_CreateLicense";
            this.btn_CreateLicense.Size = new System.Drawing.Size(75, 23);
            this.btn_CreateLicense.TabIndex = 5;
            this.btn_CreateLicense.Text = "Tạo License";
            this.btn_CreateLicense.UseVisualStyleBackColor = true;
            this.btn_CreateLicense.Click += new System.EventHandler(this.btn_CreateLicense_Click);
            // 
            // tbx_Year
            // 
            this.tbx_Year.Location = new System.Drawing.Point(68, 48);
            this.tbx_Year.Name = "tbx_Year";
            this.tbx_Year.Size = new System.Drawing.Size(67, 20);
            this.tbx_Year.TabIndex = 2;
            // 
            // CreateLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 244);
            this.Controls.Add(this.btn_CreateLicense);
            this.Controls.Add(this.tbx_Day);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbx_Year);
            this.Controls.Add(this.tbx_Month);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbx_License);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_IP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_Domain);
            this.Controls.Add(this.label1);
            this.Name = "CreateLicense";
            this.Text = "CreateLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_Domain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_IP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_License;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_Month;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_Day;
        private System.Windows.Forms.Button btn_CreateLicense;
        private System.Windows.Forms.TextBox tbx_Year;
    }
}