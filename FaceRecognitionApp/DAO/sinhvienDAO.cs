using FaceRecognitionApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace FaceRecognitionApp.DAO
{
    class sinhvienDAO
    {
        public static sinhvienDTO CreateNewSinhvien(string mssv, string hovatendem, string ten, bool trained)
        {
            return new sinhvienDTO(mssv, hovatendem, ten, trained);
        }

        public static List<sinhvienDTO> readAllSinhVienFromFile(string excelPath)
        {
            var excelApp = new Excel.Application();
            var excelWorkBook = excelApp.Workbooks.Open(excelPath);
            var excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

            var range = excelWorkSheet.UsedRange;
            var rw = range.Rows.Count;
            var cl = range.Columns.Count;

            for(int i = 1; i <= rw; i++)
            {
                for(int j = 1; j <= cl; j++)
                {
                    var str = (string)(range.Cells[i, j] as Excel.Range).Value2;
                    Console.WriteLine(str);
                }
            }

            return null;
        }
    }
}
