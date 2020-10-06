using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionApp.DTO
{
    public class PhongThiDTO
    {
        public string tenMon { get; set; }
        public string phong { get; set; }
        public List<SinhVienDTO> sinhviens {get;set;}


        /// <summary>
        /// create new MonThiDTO object using name and phong thi
        /// </summary>
        /// <param name="tenMon"></param>
        ///  <param name="phong"></param>
        public PhongThiDTO(string tenMon, string phong)
        {
            this.tenMon = tenMon;
            this.phong = phong;
            sinhviens = new List<SinhVienDTO>();
        }

        public override string ToString()
        {
            return tenMon;
        }
    }
}
