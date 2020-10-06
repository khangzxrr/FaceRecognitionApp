using FaceRecognitionApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using FaceRecognitionApp.Util;

namespace FaceRecognitionApp.DAO
{
    class KyThiDAO
    {

        public string GetKyThiName(string excelPath)
        {
            var excelApp = new Excel.Application();
            var excelWorkBook = excelApp.Workbooks.Open(excelPath);
            var excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

            var range = excelWorkSheet.UsedRange;
            var rw = range.Rows.Count;
            var cl = range.Columns.Count;


            List<PhongThiDTO> monThiList = new List<PhongThiDTO>();

            for (int i = 1; i < rw; i++)
            {

                string kythiName = (string)ExcelUltil.ReadValueAt(range, i, 1);
                //4 ~ column D, looping though row by row at column D to find out "mon thi"


                if (kythiName != null && kythiName.ToLower().Contains("kỳ thi")) //find mon thi cell
                {
                    return kythiName;               
                } //end if check mon thi name

            }


            excelWorkBook.Close();
            excelApp.Quit();

            return null;
        }

        /// <summary>
        /// finding mon thi and looping read sinh vien 
        /// </summary>
        /// <param name="excelPath"></param>
        /// <returns></returns>
        public List<PhongThiDTO> readMonThiAndSinhviens(string excelPath)
        {
            var excelApp = new Excel.Application();
            var excelWorkBook = excelApp.Workbooks.Open(excelPath);
            var excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

            var range = excelWorkSheet.UsedRange;
            var rw = range.Rows.Count;
            var cl = range.Columns.Count;


            List<PhongThiDTO> monThiList = new List<PhongThiDTO>();

            for (int i = 1; i < rw; i++)
            {

                string monthiName = (string)ExcelUltil.ReadValueAt(range, i, 4);
                //4 ~ column D, looping though row by row at column D to find out "mon thi"


                if (monthiName != null && monthiName.Contains("Môn thi")) //find mon thi cell
                {
                    var splitedMonThiName = monthiName.Trim().Split(' ');

                    var phongThiInfo = (string)ExcelUltil.ReadValueAt(range, i - 1, 4);
                    var phongThiSplited = phongThiInfo.Trim().Split(' ');

                    Console.WriteLine(splitedMonThiName[2]);

                    PhongThiDTO monThi = new PhongThiDTO(splitedMonThiName[2], phongThiSplited.Last());

                    int currentRow = i + 4;
                    //i now at "mon thi" cell + 4 ~ "mon thi" cell step down 4 cell, that is sinh vien list row start [first sinh vien]

                    //====================== GET sinh vien LOOP ===============
                    do
                    {
                        try
                        {
                            var sttObj = ExcelUltil.ReadValueAt(range, currentRow, 1);

                            //read first stt as init if that is null => exit
                            if (sttObj == null)
                            {
                                break;
                            }

                            string sbd = (string)ExcelUltil.ReadValueAt(range, currentRow, 2); //row 2 is sbd
                            string hovaten = (string)ExcelUltil.ReadValueAt(range, currentRow, 3); //row 3 is ho va ten
                            string ngaysinh = (string)ExcelUltil.ReadValueAt(range, currentRow, 4); //row 4 is ngay sinh

                            var sinhvien = new SinhVienDTO((double)sttObj, sbd, hovaten, ngaysinh);
                            monThi.sinhviens.Add(sinhvien); //add sinh vien to monthi

                            Console.WriteLine(sinhvien);

                            currentRow++;

                        }
                        catch (Exception e) //stt will throw nullexception if cannot read
                        {
                            Console.WriteLine("Finish reading list sinh vien");
                            break;
                        }

                    } while (true);
                    //====================== GET sinh vien LOOP ===============

                    monThiList.Add(monThi); //add new monthi to monthi list
                } //end if check mon thi name

            }


            excelWorkBook.Close();
            excelApp.Quit();

            return monThiList;
        }


    }
}
