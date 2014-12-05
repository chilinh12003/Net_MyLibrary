using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
namespace WapTest
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    public class d : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(context.Session.SessionID);

            MyUtility.MyLogfile.WriteLogData("Data", "test");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
