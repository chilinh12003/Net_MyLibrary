using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MyUtility;
using MyConnect.MySQL;

namespace WebTest
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                tbx_Text.Value = getLicense();
            }
            catch (Exception ex)
            {
                MyLogfile.WriteLogError(ex, true, "Có lỗi xảy ra trong quá trình xóa dữ liệu!", "Chilinh");
            }
        }

        protected void btn_Button_Click(object sender, EventArgs e)
        {
            MyUtility.UploadFile.MyUploadImage mImg=new MyUtility.UploadFile.MyUploadImage("News_");
            mImg.SaveAsPath = MyConfig.GetKeyInConfigFile("SaveAsPath");
            mImg.CreateThumbnail(MyConfig.GetKeyInConfigFile("News_UI_Path") + "\\18.jpg", true, "1345", true);
            return ;
        }
        protected void btn_Button_2_Click(object sender, EventArgs e)
        {
        }

        public string getLicense()
        {
            //string host = MyCurrent.GetDomainName() + "$" + MyCurrent.GetHostIP() + "$" + "2010" + "$" + "12" + "$" + "28";
            string host = MyCurrent.GetDomainName() + "$" + "210.211.99.38" + "$" + "2012" + "$" + "2" + "$" + "28";
            return MySecurity.TripleDES_En(host, "CHIlInH");
        }
    }

 
}
