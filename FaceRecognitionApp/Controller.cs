using FaceRecognitionApp.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionApp
{
    class Controller
    {
        public Controller()
        {
            sinhvienDAO.readAllSinhVienFromFile(@"C:\Users\skyho\Desktop\import.xlsx");
        }
    }
}
