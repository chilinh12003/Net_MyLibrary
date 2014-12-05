namespace CreateConnection
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
            this.tbx_Input = new System.Windows.Forms.TextBox();
            this.btn_EnCode = new System.Windows.Forms.Button();
            this.btn_DeCode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Encode_TripleDES = new System.Windows.Forms.Button();
            this.btn_Decode_TripleDES = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbx_Output = new System.Windows.Forms.TextBox();
            this.btn_CreateLicense = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbx_Input
            // 
            this.tbx_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_Input.Location = new System.Drawing.Point(3, 16);
            this.tbx_Input.Multiline = true;
            this.tbx_Input.Name = "tbx_Input";
            this.tbx_Input.Size = new System.Drawing.Size(747, 59);
            this.tbx_Input.TabIndex = 1;
            // 
            // btn_EnCode
            // 
            this.btn_EnCode.Location = new System.Drawing.Point(113, 19);
            this.btn_EnCode.Name = "btn_EnCode";
            this.btn_EnCode.Size = new System.Drawing.Size(75, 23);
            this.btn_EnCode.TabIndex = 2;
            this.btn_EnCode.Text = "Mã hóa AES";
            this.btn_EnCode.UseVisualStyleBackColor = true;
            this.btn_EnCode.Click += new System.EventHandler(this.btn_EnCode_Click);
            // 
            // btn_DeCode
            // 
            this.btn_DeCode.Location = new System.Drawing.Point(237, 19);
            this.btn_DeCode.Name = "btn_DeCode";
            this.btn_DeCode.Size = new System.Drawing.Size(75, 23);
            this.btn_DeCode.TabIndex = 2;
            this.btn_DeCode.Text = "Giải mã AES";
            this.btn_DeCode.UseVisualStyleBackColor = true;
            this.btn_DeCode.Click += new System.EventHandler(this.btn_DeCode_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbx_Input);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 78);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giá trị đầu vào";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Encode_TripleDES);
            this.groupBox2.Controls.Add(this.btn_EnCode);
            this.groupBox2.Controls.Add(this.btn_Decode_TripleDES);
            this.groupBox2.Controls.Add(this.btn_CreateLicense);
            this.groupBox2.Controls.Add(this.btn_DeCode);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(753, 52);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btn_Encode_TripleDES
            // 
            this.btn_Encode_TripleDES.Location = new System.Drawing.Point(375, 19);
            this.btn_Encode_TripleDES.Name = "btn_Encode_TripleDES";
            this.btn_Encode_TripleDES.Size = new System.Drawing.Size(117, 23);
            this.btn_Encode_TripleDES.TabIndex = 2;
            this.btn_Encode_TripleDES.Text = "Mã hóa TripleDES";
            this.btn_Encode_TripleDES.UseVisualStyleBackColor = true;
            this.btn_Encode_TripleDES.Click += new System.EventHandler(this.btn_Encode_TripleDES_Click);
            // 
            // btn_Decode_TripleDES
            // 
            this.btn_Decode_TripleDES.Location = new System.Drawing.Point(518, 19);
            this.btn_Decode_TripleDES.Name = "btn_Decode_TripleDES";
            this.btn_Decode_TripleDES.Size = new System.Drawing.Size(121, 23);
            this.btn_Decode_TripleDES.TabIndex = 2;
            this.btn_Decode_TripleDES.Text = "Giải mã TripleDES";
            this.btn_Decode_TripleDES.UseVisualStyleBackColor = true;
            this.btn_Decode_TripleDES.Click += new System.EventHandler(this.btn_Decode_TripleDES_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbx_Output);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(753, 148);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Giá trị đầu ra";
            // 
            // tbx_Output
            // 
            this.tbx_Output.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbx_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_Output.Location = new System.Drawing.Point(3, 16);
            this.tbx_Output.Multiline = true;
            this.tbx_Output.Name = "tbx_Output";
            this.tbx_Output.ReadOnly = true;
            this.tbx_Output.Size = new System.Drawing.Size(747, 129);
            this.tbx_Output.TabIndex = 2;
            this.tbx_Output.TextChanged += new System.EventHandler(this.tbx_Output_TextChanged);
            // 
            // btn_CreateLicense
            // 
            this.btn_CreateLicense.Location = new System.Drawing.Point(666, 19);
            this.btn_CreateLicense.Name = "btn_CreateLicense";
            this.btn_CreateLicense.Size = new System.Drawing.Size(75, 23);
            this.btn_CreateLicense.TabIndex = 2;
            this.btn_CreateLicense.Text = "Tạo License";
            this.btn_CreateLicense.UseVisualStyleBackColor = true;
            this.btn_CreateLicense.Click += new System.EventHandler(this.btn_CreateLicense_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 278);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Encode_Decode_ConnectionString";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_Input;
        private System.Windows.Forms.Button btn_EnCode;
        private System.Windows.Forms.Button btn_DeCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbx_Output;
        private System.Windows.Forms.Button btn_Encode_TripleDES;
        private System.Windows.Forms.Button btn_Decode_TripleDES;
        private System.Windows.Forms.Button btn_CreateLicense;
    }
}

