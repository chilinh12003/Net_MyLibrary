using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace WinTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //GetContent();
        }
        static bool MyCertHandler(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors error)
        {
            // Ignore errors
            return true;
        }

        static void GetContent()
        {
            string URL = "https://203.113.138.199:81/sp/login.do";
            //"httppath":"http://203.113.138.199:80/sp/bulletinflag.do"
            //"generalCPID":""
            //"generalCPPwd":""

            System.Net.WebResponse response = null;
            System.IO.StreamReader reader = null;
            try
            {
                string str_Result = string.Empty;
                ServicePointManager.ServerCertificateValidationCallback = MyCertHandler;

                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
                request.Headers.Add("httppath", "http://203.113.138.199:80/sp/bulletinflag.do");
                request.Headers.Add("generalCPID", "601633");
                request.Headers.Add("generalCPPwd", "260186");
                request.KeepAlive = true;
                request.Method = "POST";
                request.Timeout = 36000;
                
                response = request.GetResponse();
                reader = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);

                str_Result = reader.ReadToEnd();

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                if (response != null)
                    response.Close();
            }
        }

    }
}
