﻿using FaceRecognitionDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognitionApp
{
    public partial class Form1 : Form
    {
        Controller controller;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void nhapdanhsachBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "excel file (*.xlsx)|*.xlsx";
                openFileDialog.RestoreDirectory = true;

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    controller.ReadDataFromFile(filePath);
                }
            }
        }


    }
}
