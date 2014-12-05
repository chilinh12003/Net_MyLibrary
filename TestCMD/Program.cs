using System;
using System.Collections.Generic;
using System.Text;
using MyUtility;
namespace TestCMD
{
    class Program
    {
        static MyLog mLog= new MyLog(typeof(Program));

        static void Main(string[] args)
        {
            try
            {
                mLog.Debug("Entering application.");
                Bar bar = new Bar();
                bar.DoIt();
            }
            catch(Exception ex)
            {
                mLog.Error(ex);
            }
        }

    }

    public class Bar
    {

        static MyLog mLog = new MyLog(typeof(Bar));
        public void DoIt()
        {
            try
            {
                int i = 0;
                int s = 45 / i;
            }
            catch(Exception ex)
            {
                mLog.Error(ex);
                throw ex;
            }
        }
    }
}
