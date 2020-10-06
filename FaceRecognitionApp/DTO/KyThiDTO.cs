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
        public List<MonThiDTO> monThis { get; set; }
        public bool buoi { get; set; }
        public int tongsophong { get; set; }


        public KyThiDTO(string ten, DateTime khoaNgay, bool buoi, int tongsophong)
        {
            this.ten = ten;
            this.khoaNgay = khoaNgay;
            this.buoi = buoi;
            this.tongsophong = tongsophong;
        }
    }
}
