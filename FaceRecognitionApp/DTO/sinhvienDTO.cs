using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionApp.DTO
{
    public class SinhVienDTO
    {
        string mssv { get; set; }
        string hovatendem { get; set; }
        string ten { get; set; }
        bool trained = false;

        public SinhVienDTO(string mssv, string hovatendem, string ten, bool trained)
        {
            this.mssv = mssv;
            this.hovatendem = hovatendem;
            this.ten = ten;
            this.trained = trained;
        }
    }
}
