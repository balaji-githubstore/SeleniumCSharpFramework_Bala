using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Trianz.DataUtlis
{
    class ExcelUtlis
    {
        //add Microsoft.Office.Interop.Excel and system.data dll to reference
        public static DataTable ConvertSheetToDataTable(string excelLocation, string sheetName)
        {
            Excel.Application app = null;
            Excel.Workbook book = null;
            DataTable dt = new DataTable();
            try
            {
                app = new Excel.Application();
                book = app.Workbooks.Open(excelLocation);
                Excel.Worksheet sheet = book.Sheets[sheetName];
                Excel.Range range = sheet.UsedRange;
                int rowCount = range.Rows.Count;
                int colCount = range.Columns.Count;
                //fill the column header
                for (int i = 1; i <= colCount; i++)
                {
                    string Header = range.Cells[1, i].value;
                    dt.Columns.Add(Header);
                }

                //fill the rows
                for (int i = 2; i <= rowCount; i++)
                {
                    DataRow row = dt.NewRow();

                    for (int j = 1; j <= colCount; j++)
                    {
                        string cell = range.Cells[i, j].value;
                        row[j - 1] = cell;
                    }
                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                book.Close();
                app.Quit();
            }
            return dt;
        }


        public static object[] ConvertSheetToObject(string excelLocation, string sheetName)
        {
            DataTable dt = ExcelUtlis.ConvertSheetToDataTable(excelLocation,sheetName);

            int rowCount = dt.Rows.Count;
            int colCount = dt.Columns.Count;

            object[] main = new object[rowCount];

            for (int i = 0; i < rowCount; i++)
            {
                object[] temp = new object[colCount];

                for (int j = 0; j < colCount; j++)
                {
                    temp[j] = dt.Rows[i][j];
                }
                main[i] = temp;
            }

            return main;
            
        }
    }
}
