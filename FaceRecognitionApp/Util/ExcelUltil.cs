using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionApp.Util
{
    class ExcelUltil
    {
        public static Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        public static object ReadValueAt(Microsoft.Office.Interop.Excel.Range range, object row, object column)
        {
            return (range.Cells[row, column] as Microsoft.Office.Interop.Excel.Range).Value2; 
        }
    }
}
