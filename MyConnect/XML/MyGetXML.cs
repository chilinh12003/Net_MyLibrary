using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace MyConnect.XML
{
    /// <summary>
    /// Lấy dữ liệu từ XML
    /// </summary>
    public class MyGetXML
    {
        /// <summary>
        /// Lấy dữ liệu từ 1 file XML
        /// </summary>
        /// <param name="FileName">Đường dẫn tuyệt đối tới File XML</param>
        /// <returns></returns>
        public static DataSet GetXMLData(string FileName)
        {
            try
            {
                System.Xml.XmlTextReader mReader = new System.Xml.XmlTextReader(FileName);
                DataSet mDataSet = new DataSet();

                mDataSet.ReadXml(mReader);
                mReader.Close();
                return mDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy dữ liệu từ 1 chuỗi XML truyền vào
        /// </summary>
        /// <param name="XMLContent"></param>
        /// <returns></returns>
        public static DataSet GetDataSetFromXMLString(string XMLContent)
        {
            try
            {
                System.IO.StringReader mReader = new System.IO.StringReader(XMLContent);
                DataSet mSet = new DataSet();
                mSet.ReadXml(mReader);
                return mSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
