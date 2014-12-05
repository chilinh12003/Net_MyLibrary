using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyUtility;
namespace WinTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate("http://203.113.138.199/sp/logout.do");
            }
            catch (Exception ex)
            {
                #region Xử lý lỗi
               // MyLogfile.WriteLogError(MyLogfile.CreateStackTrace(ex).ToString(), ex, true, "Có lỗi xảy ra trong quá trình xóa dữ liệu!", "Chilinh");
                #endregion
            }
        }
        public void Login()
        {
            HtmlElementCollection theElementCollection = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement curElement in theElementCollection)
            {
                string controlName = curElement.GetAttribute("name").ToString();
                if (controlName == "generalCPID")
                {
                    curElement.SetAttribute("Value", "601633");
                }
                if (controlName == "generalCPPwd")
                {
                    curElement.SetAttribute("Value", "260186");
                }
            }

            HtmlElementCollection theWElementCollection = webBrowser1.Document.GetElementsByTagName("a");
            foreach (HtmlElement curElement in theWElementCollection)
            {
                if (curElement.GetAttribute("href").Equals("javascript:checkForm();"))
                {
                    curElement.InvokeMember("click");
                }
            }
        }
        int PageIndex = 2;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (webBrowser1.Url.ToString().Contains("http://203.113.138.199/sp/logout.do"))
                {
                    Login();
                    return;
                }
                if (webBrowser1.Url.ToString().Contains("http://203.113.138.199/sp/bulletinflag.do"))
                {
                    webBrowser1.Navigate("http://203.113.138.199/sp/downloadtimesstatistics.do?qryType=self&uploadType=1&approveType=2&orderBy=9&orderType=2");
                    //Đã đăng nhập thành công
                    //webBrowser1.Navigate("http://203.113.138.199/sp/downloadtimesstatistics.do?qryType=self&uploadType=1&approveType=2&orderBy=9&orderType=2&page=1");
                }

                if (webBrowser1.Url.ToString().Contains("http://203.113.138.199/sp/downloadtimesstatistics.do?qryType=self"))
                {
                    HtmlElementCollection theElementCollection = webBrowser1.Document.GetElementsByTagName("table");
                    foreach (HtmlElement curElement in theElementCollection)
                    {

                        HtmlElementCollection list_tr = curElement.GetElementsByTagName("tr");
                        if (list_tr.Count > 0 && list_tr[0].InnerText != null && list_tr[0].InnerText.Equals("RBT statistics report>>Rank of RBT download times"))
                        {
                            foreach (HtmlElement el_tr in list_tr)
                            {
                                if (el_tr.TagName.Equals("tr", StringComparison.InvariantCultureIgnoreCase) && el_tr.Children.Count == 3)
                                {
                                    if(el_tr.Children[0].InnerText.Equals("RBT code",StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        continue;
                                    }

                                    string RingbackCode = el_tr.Children[0].InnerText;
                                    string RingbackName = el_tr.Children[1].InnerText;
                                    string DownCount = el_tr.Children[2].InnerText;
                                    MyLogfile.WriteLogData(DateTime.Now.ToString("ddMMyyyy"), false, false, "_data", "Code=" + RingbackCode + "||Name=" + RingbackName + "||DownCount=" + DownCount);
                                    
                                }
                            }
                        }
                        if (list_tr.Count == 2 && list_tr[1].InnerText != null && list_tr[1].InnerText.Equals("No record", StringComparison.InvariantCultureIgnoreCase))
                        {
                            //kết thúc quá trình lấy dữ liệu.
                            this.Close();
                        }
                    }
                    
                    webBrowser1.Navigate("http://203.113.138.199/sp/downloadtimesstatistics.do?qryType=self&uploadType=1&approveType=2&orderBy=9&orderType=2&page=" + PageIndex.ToString());
                    PageIndex++;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
    }
}
