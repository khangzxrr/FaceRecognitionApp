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

        
    }
}
