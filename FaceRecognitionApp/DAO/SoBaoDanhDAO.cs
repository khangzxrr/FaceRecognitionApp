using FaceRecognitionApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace FaceRecognitionApp.DTO
{
    public class SoBaoDanhDTO
    {


        internal static void GenerateTable(SelectedRoom selectedRoom, string sbdExcelPath, PhongThiDTO phongThi)
        {
            var excelApp = new Excel.Application();
            var excelWorkBook = excelApp.Workbooks.Open(sbdExcelPath);
            var excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets["InSBD"];

            var range = excelWorkSheet.UsedRange;
            var rw = range.Rows.Count;
            var cl = range.Columns.Count;


            var columnLimit = 7;
            var rowLimit = 14;


            string[,] SBD = new string[phongThi.sinhviens.Count, phongThi.sinhviens.Count];
            for (int currentRow = 2; currentRow < rowLimit; currentRow++)
            {

                var curRowObj = ExcelUltil.ReadValueAt(range, currentRow, 1);
                if (curRowObj == null) continue;

                for (int currentColumn = 1; currentColumn < columnLimit; currentColumn++)
                {
                    var curColumnObj = ExcelUltil.ReadValueAt(range, currentRow, currentColumn);
                    if (curColumnObj == null) continue;
                    try
                    {
                        SBD[currentRow, currentColumn] = (string)curColumnObj;
                        Console.WriteLine(SBD[currentRow, currentColumn]);
                    }catch(Exception e)
                    {
                        continue;
                    }
                    

                }
            }


            //TODO load to form

            excelWorkBook.Close();
            excelApp.Quit();
        }
    }
}
