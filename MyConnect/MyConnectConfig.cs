using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
namespace MyConnect
{
    public class MyConnectConfig
    {
        static string PasswordEnCode = "CHIlInH123";

        public static string GetConfigConnectionString()
        {
            //Kiểm tra License
            if (!MyUtility.MyCheck.CheckLicense())
                throw new Exception("Errors in the process connection!");

            string strConnect = string.Empty;
            if (ConfigurationManager.ConnectionStrings["strConnection"] != null)
                strConnect = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
            else
                strConnect = System.Configuration.ConfigurationManager.AppSettings["strConnection"];

            strConnect = MyUtility.MySecurity.AESDecrypt_Simple(strConnect, PasswordEnCode);

            return strConnect;
        }

        public static string GetConfigConnectionString(string KeyOnConfig)
        {
            //Kiểm tra License
            if (!MyUtility.MyCheck.CheckLicense())
                throw new Exception("Errors in the process connection!");

            string strConnect = string.Empty;
            if (ConfigurationManager.ConnectionStrings[KeyOnConfig] != null)
                strConnect = ConfigurationManager.ConnectionStrings[KeyOnConfig].ConnectionString;
            else
                strConnect = System.Configuration.ConfigurationManager.AppSettings[KeyOnConfig];

            strConnect = MyUtility.MySecurity.AESDecrypt_Simple(strConnect, PasswordEnCode);

            return strConnect;
        }

        public static string GetConfigConnectionString(string ConnectionString, bool IsContent)
        {
            string strConnect = string.Empty;

            if (IsContent)
            {
                strConnect = ConnectionString;
            }
            else
            {
                if (ConfigurationManager.ConnectionStrings[ConnectionString] != null)
                    strConnect = ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString;
                else
                    strConnect = System.Configuration.ConfigurationManager.AppSettings[ConnectionString];
            }
            strConnect = MyUtility.MySecurity.AESDecrypt_Simple(strConnect, PasswordEnCode);

            return strConnect;
        }
    }
}
