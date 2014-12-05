using System;
using System.Collections.Generic;
using System.Text;
using OWC11 = Microsoft.Office.Interop.Owc11;
using System.Data;
using System.Reflection;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
namespace MyUtility
{
    /// <summary>
    /// Ghi du lieu ra file Excell
    /// </summary>
    public class MyExport
    {
         public void ExportToExcel(string Filename, System.Web.UI.Page page, System.Data.DataTable DT, string[] colNames)
        {
            try
            {
                System.Web.HttpResponse res = page.Response;
                res.ContentType = "application/vnd.ms-excel";
                res.AppendHeader("content-disposition", "attachment; filename=" + Filename);
                res.Charset = "";
                int num_rows = DT.Rows.Count;
                //MaxRowsPerSheet must be the maximum number of rows plus 1
                int MaxRowsPerSheet = 64001;
                int rowIndex = MaxRowsPerSheet;
                int colIndex = 1;
                int sheetIndex = 0;


                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                OWC11.Spreadsheet oExcel = new OWC11.Spreadsheet();
                OWC11.Workbook WB = oExcel.ActiveWorkbook;
                OWC11.Worksheet sheet = null;
                OWC11._Range range = null;
                while (WB.Worksheets.Count > 1)
                    ((OWC11.Worksheet)WB.Worksheets["Sheet" + WB.Worksheets.Count]).Delete();
                foreach (DataRow row in DT.Rows)
                {
                    if (rowIndex == MaxRowsPerSheet)
                    {
                        rowIndex = 1;
                        colIndex = 1;
                        sheetIndex++;
                        if (sheet != null)
                            sheet = (OWC11.Worksheet)WB.Worksheets.Add(Missing.Value, sheet, Missing.Value, Missing.Value);
                        else
                            sheet = oExcel.ActiveSheet;
                        if (colNames == null)
                        {
                            foreach (DataColumn col in DT.Columns)
                            {
                                sheet.Cells[rowIndex, colIndex++] = col.ColumnName.ToString();
                            }
                        }
                        else
                        {
                            foreach (string str in colNames)
                            {
                                sheet.Cells[rowIndex, colIndex++] = str.ToString();
                            }
                        }
                        rowIndex++;
                        sheet.Name = "Sheet" + (sheetIndex);
                    }
                    colIndex = 1;
                    foreach (object item in row.ItemArray)
                    {
                        sheet.Cells[rowIndex, colIndex] = item.ToString();
                        range = (OWC11._Range)sheet.Cells[rowIndex, colIndex];
                        if (item.ToString().Length > 11 && range.get_NumberFormat().ToString() != "#")
                        {
                            bool IsPhoneNumber = true;
                            string strItem = item.ToString();
                            for (int i = 0; i < strItem.Length; i++)
                            {
                                if (!Char.IsDigit(strItem, i))
                                {
                                    IsPhoneNumber = false;
                                    break;
                                }
                            }
                            if (IsPhoneNumber)
                                range.EntireColumn.set_NumberFormat("#");
                        }
                        colIndex++;
                    }
                    rowIndex++;
                }
                for (int i = 1; i <= WB.Worksheets.Count; i++)
                {
                    sheet = (OWC11.Worksheet)WB.Worksheets["Sheet" + i];
                    int num_cols = DT.Columns.Count;
                    for (int j = 1; j <= num_cols; j++)
                    {
                        range = (OWC11.Range)sheet.Cells[1, j];
                        range = range.EntireColumn;
                        range.AutoFit();
                        range.set_HorizontalAlignment(OWC11.XlHAlign.xlHAlignRight);
                    }
                }
                ((OWC11.Worksheet)oExcel.Worksheets["Sheet1"]).Activate();
                string filename = page.Server.MapPath("/") + page.Session.SessionID;
                if (DT.Rows.Count < MaxRowsPerSheet)
                {
                    oExcel.Export(filename + ".xls", OWC11.SheetExportActionEnum.ssExportActionNone, OWC11.SheetExportFormat.ssExportAsAppropriate);
                }
                else
                {
                    oExcel.Export(filename + ".xml", OWC11.SheetExportActionEnum.ssExportActionNone, OWC11.SheetExportFormat.ssExportAsAppropriate);
                    ReturnExcelFile(filename);
                    System.IO.File.Delete(filename + ".xml");
                }
                oExcel = null;
                System.IO.FileStream input = new System.IO.FileStream(filename + ".xls", System.IO.FileMode.Open);
                System.IO.Stream output = res.OutputStream;
                int len = (int)input.Length;
                byte[] buffer = new byte[len];
                input.Read(buffer, 0, len);
                output.Write(buffer, 0, len);
                input.Close();
                output.Close();
                System.IO.File.Delete(filename + ".xls");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  void ReturnExcelFile(string filename)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook ExcelWB = ExcelApp.Workbooks.OpenXML(filename + ".xml", Missing.Value, Microsoft.Office.Interop.Excel.XlXmlLoadOption.xlXmlLoadOpenXml);
                ExcelWB.SaveAs(filename + ".xls", Excel.XlFileFormat.xlWorkbookNormal, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                ExcelWB.Close(Missing.Value, Missing.Value, Missing.Value);
                ExcelApp.Workbooks.Close();
                ExcelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelWB);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelApp);
                ExcelWB = null;
                ExcelApp = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
