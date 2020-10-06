﻿using FaceRecognitionApp.DTO;
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
    public partial class RoomPickerForm : Form
    {
        Controller controller;
        public RoomPickerForm(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
            SetData(controller.kyThiDTO);
        }


        private void GenerateRoomsBtn(List<PhongThiDTO> phongThiList)
        {
            int preX = phong1Btn.Location.X;
            int preY = phong1Btn.Location.Y;
            int width = phong1Btn.Width;
            int height = phong1Btn.Height;

            int padding = 15;

            int elementOnRowCount = 1;
            for(int i = 2; i <= phongThiList.Count; i++)
            {
                

                Button newRoomBtn = new Button();
                newRoomBtn.Location = new Point( preX + width + padding, preY);
                newRoomBtn.Width = width;
                newRoomBtn.Height = height;
                newRoomBtn.Font = phong1Btn.Font;

                newRoomBtn.Text = $"Phòng {phongThiList[i].phong}";

                this.Controls.Add(newRoomBtn);

                preX = preX + width + padding;

                elementOnRowCount++;
                if(elementOnRowCount == 3)
                {
                    preY = preY + height + padding;
                    preX = phong1Btn.Location.X - width - padding;
                    elementOnRowCount = 0;
                }

                newRoomBtn.MouseClick += OnRoomBtnClicked;
            }
        }

        private void OnRoomBtnClicked(object sender, MouseEventArgs e)
        {
            Console.WriteLine(((Button)sender).Text);
        }

        private void SetData(KyThiDTO kythi)
        {
            
            kythiLabel.Text = $"Kỳ Thi: {kythi.ten}";
            khoangayLabel.Text = $"Khóa ngày: {kythi.khoaNgay}";
            monthiLabel.Text = $"Môn Thi: {kythi.phongThiList.First().tenMon}";

            string buoi = kythi.buoi ? "Sáng" : "Chiều";
            buoiThiLabel.Text = $"Buổi Thi: {buoi}";

            tongphongLabel.Text = $"Tổng phòng: {kythi.phongThiList.Count}";

            GenerateRoomsBtn(kythi.phongThiList);

            phong1Btn.MouseClick += OnRoomBtnClicked;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
