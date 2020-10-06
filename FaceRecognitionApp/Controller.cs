using FaceRecognitionApp.DAO;
using FaceRecognitionApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognitionApp
{
    public class Controller
    {
        public string sbdExcelPath { get; set; } //sbd path

        KyThiDAO kyThiDAO = new KyThiDAO();

        public KyThiDTO kyThiDTO;
        public List<PhongThiDTO> phongThiDTO;
        public Controller()
        {
            

        }


        /// <summary>
        /// tao object ky thi moi
        /// </summary>
        /// <param name="ten"></param>
        /// <param name="ngay"></param>
        /// <param name="buoi"></param>
        /// <param name="sophong"></param>
        public void CreateNewKyThi(string ten, DateTime ngay, bool buoi, string monThi)
        {
            kyThiDTO = new KyThiDTO(ten, ngay, buoi);
            
            foreach(var phongThi in phongThiDTO)
            {
                if (phongThi.tenMon.ToLower() == monThi.ToLower())
                {
                    kyThiDTO.phongThiList.Add(phongThi);
                }
            }


        }


        public string GetKyThiName(string excelPath)
        {
            return kyThiDAO.GetKyThiName(excelPath);
        }

        /// <summary>
        /// import danh sach thi sinh vao kyThiDAO gom mon thi va ben trong mon thi la danh sach thi sinh
        /// </summary>
        /// <param name="excelPath"></param>
        public int ImportDSDT(string excelPath)
        {
            try
            {
                
                phongThiDTO = kyThiDAO.readMonThiAndSinhviens(excelPath);
                //tempolary store mon thi in monthis list variable
                return phongThiDTO.Count;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }

            return 0;
            
        }
    }
}
