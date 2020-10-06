using FaceRecognitionApp.DAO;
using FaceRecognitionApp.DTO;
using FaceRecognitionApp.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognitionApp
{
    class Controller
    {
        KyThiDAO kyThiDAO = new KyThiDAO();

        public KyThiDTO kyThiDTO;
        public Controller()
        {
            

        }


        public void CreateNewKyThi(string ten, DateTime ngay, bool buoi, int sophong)
        {
            kyThiDTO = new KyThiDTO(ten, ngay, buoi, sophong);
        }

        public void ReadDataFromFile(string excelPath)
        {
            try
            {
                kyThiDAO.readMonThiAndSinhviens(excelPath);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
            
        }
    }
}
