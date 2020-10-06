using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionApp.DTO
{
    public class KyThiDTO
    {
        public string ten { get; set; }
        public DateTime khoaNgay { get; set; }
        public List<PhongThiDTO> phongThiList { get; set; }
        public bool buoi { get; set; }

        /// <summary>
        /// create new ky thi which monThis will be set later, buoi thi [true is Sang, false is toi]
        /// </summary>
        /// <param name="ten"></param>
        /// <param name="khoaNgay"></param>
        /// <param name="buoi"></param> 
        public KyThiDTO(string ten, DateTime khoaNgay, bool buoi)
        {
            this.ten = ten;
            this.khoaNgay = khoaNgay;
            this.buoi = buoi;
            phongThiList = new List<PhongThiDTO>();
        }
    }
}
