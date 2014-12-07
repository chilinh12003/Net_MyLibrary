using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using MyUtility;
namespace MyBase.MyWeb
{
    /// <summary>
    /// 
    /// </summary>
    public class MyASPXBase : Page
    {
        public MyLog mLog = new MyLog(typeof(MyASPXBase));

        /// <summary>
        /// Mã của trang, dung để phần quyền cho trang
        /// </summary>
        public string PageCode
        {
            get
            {
                if (ViewState["PageCode"] != null)
                {
                    return ViewState["PageCode"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set { ViewState["UserName"] = value; }
        }

        public int UserID
        {
            get
            {
                if (Session["UserID"] != null)
                {
                    return (int)Session["UserID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                Session["UserID"] = value;
            }
        }

        public string UserName
        {
            get
            {
                if (Session["UserName"] != null)
                {
                    return Session["UserName"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set { Session["UserName"] = value; }
        }

        public bool AllowLogVisit
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(MyUtility.MyConfig.GetKeyInConfigFile("AllowLogVisit")))
                    {
                        return true;
                    }
                    else
                    {
                        return bool.Parse(MyUtility.MyConfig.GetKeyInConfigFile("AllowLogVisit"));
                    }
                }
                catch
                {
                    return true;
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            WriteLog();
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        
        public void WriteLog()
        {
            try
            {
                if (AllowLogVisit)
                {
                    string strFormat = "Request--->IP:{0} || UserName:{1} || UserID:{2} || Link{3} || UserAgent:{4}";
                    string strContent = string.Format(strFormat, MyUtility.MyCurrent.GetRequestIP, UserName, UserID, Request.Url.ToString(), Request.UserAgent);
                    mLog.Info(strContent);
                }
            }
            catch (Exception ex)
            {
                mLog.Error(ex);
            }
        }
    }
}
