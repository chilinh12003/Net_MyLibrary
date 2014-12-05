using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CreateConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string Passowrd = "CHIlInH123";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_EnCode_Click(object sender, EventArgs e)
        {
            try
            {
                tbx_Output.Text = MyUtility.MySecurity.AESEncrypt_Simple(tbx_Input.Text, Passowrd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_DeCode_Click(object sender, EventArgs e)
        {
            try
            {
                tbx_Output.Text = MyUtility.MySecurity.AESDecrypt_Simple(tbx_Input.Text, Passowrd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Encode_TripleDES_Click(object sender, EventArgs e)
        {
            try
            {

                tbx_Output.Text = MyUtility.MySecurity.TripleDES_En(tbx_Input.Text, Passowrd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Decode_TripleDES_Click(object sender, EventArgs e)
        {
            try
            {
                tbx_Output.Text = MyUtility.MySecurity.TripleDES_De(tbx_Input.Text, Passowrd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbx_Output_TextChanged(object sender, EventArgs e)
        {
            tbx_Output.SelectAll();
        }

        private void btn_CreateLicense_Click(object sender, EventArgs e)
        {
            CreateLicense frm_License = new CreateLicense();
            frm_License.ShowDialog();
        }
    }
}
