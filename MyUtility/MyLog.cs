using System;
using System.Collections.Generic;
using System.Text;
using log4net;
namespace MyUtility
{
    public class MyLog
    {
        public log4net.ILog Log;
        public MyLog(Type ClassName)
        {
            Log = log4net.LogManager.GetLogger(ClassName);
            
        }
        public void Debug(string Message)
        {
            Log.Debug(Message);
        }
        public void Info(string Message)
        {
            Log.Info(Message);
        }
        public void Warn(string Message)
        {
            Log.Warn(Message);
        }

        public void Error(Exception Ex)
        {
            Log.Error(Ex);
        }
        public void Error(string Message, Exception Ex)
        {
            Log.Error(Message, Ex);
        }
        public void Error(string Message, bool ShowMessage, Exception Ex)
        {
            if (ShowMessage)
            {
                MyMessage.ShowError(Message);
            }
            Log.Error(Message, Ex);
        }
        public void Fatal(Exception Ex)
        {
            Log.Fatal(Ex);
        }
        public void Fatal(string Message, Exception Ex)
        {
            Log.Fatal(Message, Ex);
        }
    }
}
