using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Web.Mobile;
using WURFL;
using WURFL.Config;
using MyUtility;
namespace MyBase.MyWap
{
    /// <summary>
    /// Lớp để danh cho các trang wap kế thừa (Lớp base của trang wap)
    /// </summary>
    public class MyWapBase : IHttpHandler, IRequiresSessionState
    {
        MyLog mLog = new MyLog(typeof(MyWapBase));

        public const String WurflDataFilePath = "~/App_Data/wurfl.zip";
        public const String WurflPatchFilePath = "~/App_Data/web_browsers_patch.xml";
        public const string WurflManagerCacheKey = "WurflKey";
        public IWURFLManager WurflManager
        {
            get
            {
                try
                {
                    if (HttpContext.Current.Cache[WurflManagerCacheKey] != null)
                    {
                        return (IWURFLManager)HttpContext.Current.Cache[WurflManagerCacheKey];
                    }
                    var wurflDataFile = HttpContext.Current.Server.MapPath(WurflDataFilePath);
                    //var wurflPatchFile = HttpContext.Current.Server.MapPath(WurflPatchFilePath);
                    var configurer = new InMemoryConfigurer()
                             .MainFile(wurflDataFile);

                    IWURFLManager manager = WURFLManagerBuilder.Build(configurer);

                    HttpContext.Current.Cache[WurflManagerCacheKey] = manager;

                    return manager;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
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

        /// <summary>
        /// Cho phép load device ngày khi app start
        /// </summary>
        public bool IsLoadDeviceOnStart
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(MyUtility.MyConfig.GetKeyInConfigFile("IsLoadDeviceOnStart")))
                    {
                        return true;
                    }
                    else
                    {
                        return bool.Parse(MyUtility.MyConfig.GetKeyInConfigFile("IsLoadDeviceOnStart"));
                    }
                }
                catch
                {
                    return true;
                }
            }
        }

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
        public string _ContentType = "text/html";
        /// <summary>
        /// Định dạng text VD: text/plain, text/html, text/xml
        /// </summary>
        public string ContentType
        {
            get { return _ContentType; }
            set { _ContentType = value; }
        }

        public string IP
        {
            get
            {
                return MyCurrent.GetRequestIP;
            }
        }
        public string UserAgent
        {
            get
            {
                return Request.UserAgent;
            }
        }

        public string MSISDN
        {
            get
            {
                if (Session["MSISDN"] != null)
                {
                    return Session["MSISDN"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set { Session["MSISDN"] = value; }
        }

        public string SessionID
        {
            get
            {
                if (Session["SessionID"] != null)
                {
                    return Session["SessionID"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set { Session["SessionID"] = value; }
        }

        public string DeviceID = string.Empty;

        public string ModelName = string.Empty;

        public string BranchName = string.Empty;

        public string OS = string.Empty;
        public int ScreenWidth = 0;
        public int ScreenHeight = 0;
        public IDevice DeviceInfo
        {
            get;
            set;
        }
        public string PreviusURL
        {
            get
            {
                if (Request.UrlReferrer != null)
                    return Request.UrlReferrer.ToString();

                return string.Empty;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                mLog = new MyLog(this.GetType());
                MyContext = context;


                if (IsLoadDeviceOnStart)
                { 
                    //Lấy thông tin thiết bị
                    GetDevideInfo();
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
        /// Lấy độ phân giải màn hình điện thoại
        /// </summary>
        public void GetDevideInfo()
        {
            try
            {
                DeviceInfo = WurflManager.GetDeviceForRequest(UserAgent);
                DeviceID = DeviceInfo.Id;
                ModelName = DeviceInfo.GetCapability("model_name");
                BranchName = DeviceInfo.GetCapability("brand_name");
                OS = DeviceInfo.GetCapability("device_os");
                int.TryParse(DeviceInfo.GetCapability("resolution_width"), out ScreenWidth);
                int.TryParse(DeviceInfo.GetCapability("resolution_height"), out ScreenHeight);
            }
            catch (Exception ex)
            {
                mLog.Error(ex);
            }
        }
        /// <summary>
        /// Kiểm tra thiết bị
        /// </summary>
        /// <param name="mDevice"></param>
        /// <returns></returns>
       public bool CheckDevice(MyConfig.DeviceType mDevice)
        {
            if (DeviceInfo == null)
            {
                DeviceInfo = WurflManager.GetDeviceForRequest(UserAgent);
            }

            if (DeviceInfo.GetVirtualCapability(mDevice.ToString()).Equals("true", StringComparison.CurrentCultureIgnoreCase))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Write log khi khách hàng bắt đầu vào trang
        /// </summary>
        public void WriteLog()
        {
            try
            {
                if (AllowLogVisit)
                {
                    string strFormat = "Width:{0} || Heigth:{1} || IP:{2} || MSISDN:{3} || MySessionID:{4} || Link{5} || ModelName:{6} || UserAgent:{7} || OS:{8} || PreviusURL:{9}";
                    string strContent = string.Format(strFormat, ScreenWidth.ToString(), ScreenHeight.ToString(), IP, MSISDN, SessionID, Request.Url.ToString(), BranchName + " " + ModelName, UserAgent, OS, PreviusURL);
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
