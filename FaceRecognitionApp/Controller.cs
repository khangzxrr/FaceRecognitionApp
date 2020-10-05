using FaceRecognitionApp.DAO;
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
        SinhVienModel sinhvienModel;
        SinhVienDAO sinhvienDAO;
        public Controller()
        {
            sinhvienDAO = new SinhVienDAO();
            sinhvienModel = new SinhVienModel();

        }

        public void ReadDataFromFile(string excelPath)
        {
            try
            {
                sinhvienModel.sinhviens = sinhvienDAO.readAllSinhVienFromFile(excelPath);
                MessageBox.Show($"Loaded {sinhvienModel.sinhviens.Count} sinh vien!");
            }catch(Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
            
        }
    }
}
