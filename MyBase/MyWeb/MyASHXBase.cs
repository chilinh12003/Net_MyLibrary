using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

using MyUtility;

namespace MyBase.MyWeb
{
    /// <summary>
    /// Là lớp base để cho các trang web (ashx) kế thừa
    /// </summary>
    public class MyASHXBase : IHttpHandler, IRequiresSessionState
    {
        public MyLog mLog = new MyLog(typeof(MyASHXBase));
        public HttpContext MyContext
        {
            get;
            set;
        }

        public HttpSessionState Session
        {
            get
            {
                return MyContext.Session;
            }
        }

        public HttpRequest Request
        {
            get
            {
                return MyContext.Request;
            }
        }

        public HttpResponse Response
        {
            get { return MyContext.Response; }
        }

        public HttpServerUtility Server
        {
            get { return MyContext.Server; }
        }

        public string ContentType = "text/html";


        /// <summary>
        /// Mã của trang, dung để phần quyền cho trang
        /// </summary>
        public string PageCode
        {
            get
            {
                return this.GetType().FullName;
            }
        }

        /// <summary>
        /// UserID của User khi đã đăng nhập
        /// </summary>
        public int UserID
        {
            get;
            set;
        }

        /// <summary>
        /// Tên đăng nhập của User (khi đã đăng nhập)
        /// </summary>
        public string UserName
        {

            get;
            set;
        }

        /// <summary>
        /// Cho phép log mọi truy cập của User đến trang này
        /// </summary>
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

        #region Check DDos
        /// <summary>
        /// Cho phép website kiểm tra DDos hay không
        /// </summary>
        public bool AllowCheckDDos
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(MyUtility.MyConfig.GetKeyInConfigFile("AllowCheckDDos")))
                    {
                        return true;
                    }
                    else
                    {
                        return bool.Parse(MyUtility.MyConfig.GetKeyInConfigFile("AllowCheckDDos"));
                    }
                }
                catch
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Thời gian request trước đó
        /// </summary>
        public DateTime BeforeTimeRequest
        {
            get;
            set;
        }

        /// <summary>
        /// Khoản cách cho phép giữa 2 lần request trên 1 SessionID, và được tính bằng giây, mặc định là 5s
        /// </summary>
        public int DistanceRequest
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(MyUtility.MyConfig.GetKeyInConfigFile("DistanceRequest")))
                    {
                        return 5;
                    }
                    else
                    {
                        return int.Parse(MyUtility.MyConfig.GetKeyInConfigFile("DistanceRequest"));
                    }
                }
                catch
                {
                    return 5;
                }
            }
        }

        /// <summary>
        /// Kiểm tra xem người dùng có đang DDos hê website hay không
        /// </summary>
        /// <returns></returns>
        protected bool CheckDDos()
        {
            try
            {
                return false;
            }
            catch (Exception ex)
            {
                mLog.Error( ex);
                return false;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                BeforeTimeRequest = DateTime.Now;
                MyContext = context;

                //Nếu cho phép kiểm tra DDos
                if (AllowCheckDDos)
                {
                    if (CheckDDos())
                    {
                        return;
                    }
                }
                WriteHTML();
                MyContext.Response.ContentType = ContentType;

                //Write log
                WriteLog();
            }
            catch (Exception ex)
            {
                mLog.Error(ex);
            }
        }

        /// <summary>
        /// Wirte text
        /// </summary>
        /// <param name="strContent"></param>
        public void Write(string strContent)
        {
            Response.Write(strContent);
        }

        /// <summary>
        /// Hàm để các lớp kế thừa lớp này override
        /// </summary>
        public virtual void WriteHTML()
        {
            MyContext.Response.Write("");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Ghi log truy cập của người dùng
        /// </summary>
        public void WriteLog()
        {
            try
            {
                if (AllowLogVisit)
                {
                    string strFormat = "Request ---> IP:{0} || UserName:{1} || UserID:{2} || Link{3} || UserAgent:{4}";
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
