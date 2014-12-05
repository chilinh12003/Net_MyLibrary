using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyUtility;
namespace CreateConnection
{
    public partial class CreateLicense : Form
    {
        public CreateLicense()
        {
            InitializeComponent();
        }

        private void btn_CreateLicense_Click(object sender, EventArgs e)
        {
            string host = tbx_Domain.Text + "$" + tbx_IP.Text + "$" + tbx_Year.Text + "$" + tbx_Month.Text + "$" + tbx_Day.Text;
            tbx_License.Text = MySecurity.TripleDES_En(host, "CHIlInH123");
        }
    }
}
