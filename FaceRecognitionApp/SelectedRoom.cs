using FaceRecognitionApp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognitionApp
{
    public partial class SelectedRoom : Form
    {

        public SelectedRoom(PhongThiDTO phongThi, string excelPath)
        {
            InitializeComponent();
            SoBaoDanhDTO.GenerateTable(this, excelPath, phongThi);

        }
    }
}
