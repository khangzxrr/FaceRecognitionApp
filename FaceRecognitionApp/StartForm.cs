using FaceRecognitionApp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognitionApp
{
    public partial class StartForm : Form
    {
        Controller controller;
        public StartForm()
        {

            InitializeComponent();
            controller = new Controller();
            KillExcelApp();
        }

        /// <summary>
        /// This method use to kill every excel processes before execute anything relate to excel
        /// which can use to reduce unused excel hidden process after terminated this program
        /// </summary>
        private void KillExcelApp()
        {
            foreach (Process process in Process.GetProcessesByName("EXCEL"))
            {
                process.Kill();
            }
        }

        /// <summary>
        /// load mon thi, sinh vien, ten ky thi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nhapdanhsachBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "excel file (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    int monThiCount = controller.ImportDSDT(filePath);

                    //get ky thi name from excel file
                    kythiField.Text = controller.GetKyThiName(filePath);

                    //clear all mon thi items before continue
                    monThiComboBox.Items.Clear();
                    
                    //loop every phong thi
                    foreach(var phongThi in controller.phongThiDTO)
                    {
                        bool exist = false; //mon thi isnt exist

                        //loop to find if mon thi is exist in combo box
                        foreach(PhongThiDTO phongThiInComboBox in monThiComboBox.Items) 
                        {
                            if (phongThiInComboBox.tenMon.ToLower()  == phongThi.tenMon.ToLower())
                            {
                                exist = true;
                                break;
                            }
                        }

                        if (!exist) monThiComboBox.Items.Add(phongThi);
                    }

                    sophongField.Text = controller.phongThiDTO.Count.ToString();

                    importDSTSStatus.Text = $"Đã load tất cả sinh viên và {monThiCount} môn thi";
                }
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            bool sang = sangRadio.Checked ? true : false;

            controller.CreateNewKyThi(kythiField.Text, khoangayField.Value, sang, monThiComboBox.SelectedItem.ToString());

            //////// TODO: add mon to ky thi

            RoomPickerForm roomPickerForm = new RoomPickerForm(controller);
            roomPickerForm.Show();
        }

        private void sbdButton_clicked(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "excel file (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    controller.sbdExcelPath = openFileDialog.FileName;
                }
            }

            MessageBox.Show("Success loaded SBD excel file");
        }

    }
}
