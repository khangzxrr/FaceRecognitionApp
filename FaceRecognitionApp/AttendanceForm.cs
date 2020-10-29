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
    public partial class AttendanceForm : Form
    {
        SoBaoDanhDTO soBaoDanhDTO;
        public AttendanceForm(PhongThiDTO phongThi, string excelPath)
        {
            InitializeComponent();

            soBaoDanhDTO = new SoBaoDanhDTO();

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            phongLabel.Text = $"Phòng {phongThi.phong}";
            var sbdButtonsMap = soBaoDanhDTO.GenerateSBDTable(this, excelPath, phongThi);

            new Thread(() => RecognierDAO.Recognizing(sbdButtonsMap)).Start();
        }

        private void AttendentForm_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// if closing this form, kill the python app to close recognition system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClosing(object sender, FormClosingEventArgs e)
        {
            foreach(Process process in Process.GetProcessesByName("python"))
            {
                process.Kill();
            }
        }
    }
}
