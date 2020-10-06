using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionApp.DTO
{
    public class SinhVienDTO
    {
        double stt { get; set; }
        string sbd { get; set; }
        string hoten { get; set; }
        string ngaysinh { get; set; }
        bool checkin { get; set;}

        /// <summary>
        /// create new sinh vien object
        /// </summary>
        /// <param name="stt"></param>
        /// <param name="sbd"></param>
        /// <param name="ten"></param>
        /// <param name="ngaysinh"></param>
        public SinhVienDTO(double stt, string sbd, string hoten, string ngaysinh)
        {
            this.stt = stt;
            this.sbd = sbd;
            this.hoten = hoten;
            this.ngaysinh = ngaysinh;
        }

        public override string ToString()
        {
            return $"{stt} {sbd} {hoten} {ngaysinh}";
        }
    }
}
