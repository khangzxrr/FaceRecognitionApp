using FaceRecognitionApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace FaceRecognitionApp.DAO
{
    class SinhVienDAO
    {
        public SinhVienDTO CreateNewSinhvien(string mssv, string hovatendem, string ten, bool trained)
        {
            return new SinhVienDTO(mssv, hovatendem, ten, trained);
        }

        public List<SinhVienDTO> readAllSinhVienFromFile(string excelPath)
        {
            var excelApp = new Excel.Application();
            var excelWorkBook = excelApp.Workbooks.Open(excelPath);
            var excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

            var range = excelWorkSheet.UsedRange;
            var rw = range.Rows.Count;
            var cl = range.Columns.Count;

            List<SinhVienDTO> sinhviens = new List<SinhVienDTO>();
            for(int i = 2; i <= rw; i++)
            {
                var mssv = (string)(range.Cells[i, 1] as Excel.Range).Value2;
                var hovatendem = (string)(range.Cells[i, 2] as Excel.Range).Value2;
                var ten = (string)(range.Cells[i, 3] as Excel.Range).Value2;

                sinhviens.Add(CreateNewSinhvien(mssv, hovatendem, ten, false));
            }

            excelWorkBook.Close();
            excelApp.Quit();

            return sinhviens;
        }
    }
}
