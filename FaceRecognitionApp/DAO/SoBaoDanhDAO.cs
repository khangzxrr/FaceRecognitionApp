using FaceRecognitionApp.Util;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FaceRecognitionApp.DTO
{
    public class SoBaoDanhDTO
    {



        public String[,] GenerateSBDArray(string sbdExcelPath, PhongThiDTO phongThi, out int width, out int height)
        {
            
            var excelWorkBook = ExcelUltil.excelApp.Workbooks.Open(sbdExcelPath);
            var excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets["InSBD"];

            var range = excelWorkSheet.UsedRange;
            var rw = range.Rows.Count;
            var cl = range.Columns.Count;

            //======== FIND ROOM POSITION IN EXCEL FILE ====
            Console.WriteLine(ExcelUltil.ReadValueAt(range, 1, 2));
            Range roomNameIndex = range.Find(phongThi.phong, Missing.Value, XlFindLookIn.xlValues, XlLookAt.xlWhole, Missing.Value, XlSearchDirection.xlNext, false, false, Missing.Value);
            Console.WriteLine(roomNameIndex.Column + " : " + roomNameIndex.Row);

            



            //===========================================

            var columnLimit = roomNameIndex.Column + 5;
            var rowLimit = roomNameIndex.Row + 13;

            width = columnLimit;
            height = rowLimit;

            int SBDLength = phongThi.sinhviens.Count;
            string[,] SBD = new string[rowLimit, columnLimit];
            for (int currentRow = roomNameIndex.Row + 2; currentRow < rowLimit; currentRow++)
            {

                var curRowObj = ExcelUltil.ReadValueAt(range, currentRow, 1);
                if (curRowObj == null) continue;

                for (int currentColumn = 1; currentColumn < columnLimit; currentColumn++)
                {
                    var curColumnObj = ExcelUltil.ReadValueAt(range, currentRow, currentColumn);
                    if (curColumnObj == null) continue;
                    try
                    {
                        SBD[currentRow, currentColumn] = (string)curColumnObj;
                    }
                    catch (Exception e)
                    {
                        continue;
                    }


                }
            }




            //TODO load to form

            excelWorkBook.Close();

            return SBD;
        }

        

        public Dictionary<string, System.Windows.Forms.Button> GenerateSBDTable(AttendanceForm selectedRoom, string sbdExcelPath, PhongThiDTO phongThi)
        {

            int width, height;
            var sbd = GenerateSBDArray(sbdExcelPath, phongThi, out width, out height);

            int paddingRow = 0; //indicator where actually row started (not null)
            for(int i = 0; i < height; i++)
            {
                if (sbd[i, 1] != null)
                {
                    paddingRow = i;
                    break;
                }
            }

            Dictionary<string, System.Windows.Forms.Button> sbdButtons = new Dictionary<string, System.Windows.Forms.Button>();


            int posX = 0; //pos X is column
            int posY = 30; //pos Y is row
            int btnWidth = 75;
            int btnHeight = 30;
            for(int currentRow = paddingRow; currentRow < height; currentRow++)
            {
                for(int currentColumn = 1; currentColumn < width; currentColumn++)
                {
                    if (sbd[currentRow,currentColumn] != null)
                    {
                        Console.Write(sbd[currentRow, currentColumn]);
                        var formBtn = new System.Windows.Forms.Button();
                        formBtn.Click += AttendanceButtonAction;
                        formBtn.Size = new Size(btnWidth, btnHeight);
                        formBtn.Text = sbd[currentRow, currentColumn];
                        formBtn.Location = new System.Drawing.Point(posX, posY); //x is column, y is row!!!

                        sbdButtons.Add(formBtn.Text, formBtn); //add to dictionary

                        selectedRoom.Controls.Add(formBtn);
                        posX += btnWidth + 15;
                    }
                    else
                    {
                        Console.Write(" ");
                        posX += 50;
                    }

                    if ((currentColumn + 2 >= sbd.GetLength(1)) || sbd[currentRow, currentColumn+1] == null && sbd[currentRow,currentColumn+2] == null) //if 2 next cell is null => end line
                    {
                        break;
                    }
                }

                
                posY += 30;
                posX = 0;

                if((currentRow+2 >= sbd.GetLength(0)) || (sbd[currentRow+1,1] == null && sbd[currentRow+2,1] == null)) //if 2 next cell row is null => end all loop
                {
                    break;
                }
            }


            return sbdButtons;
        }

        private void AttendanceButtonAction(object sender, EventArgs e)
        {
            var button = (System.Windows.Forms.Button)sender;

            if (button.BackColor == Color.Green)
            {
                button.BackColor = Color.Transparent;
                button.ForeColor = Color.Black;
            }
            else
            {
                button.BackColor = Color.Green;
                button.ForeColor = Color.White;
            }
        }
    }
}
