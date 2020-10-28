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
using System.Diagnostics;
using System.Threading;

namespace FaceRecognitionApp
{
    public partial class SelectedRoom : Form
    {

        public SelectedRoom(PhongThiDTO phongThi, string excelPath)
        {
            InitializeComponent();

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            phongLabel.Text = $"Phòng {phongThi.phong}";
            SoBaoDanhDTO.GenerateSBDTable(this, excelPath, phongThi);


            
            
        }

        
    }
}
