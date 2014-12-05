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
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        HttpContext mContext;
        public void ProcessRequest(HttpContext context)
        {
            mContext = context;
            try
            {
               
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
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
