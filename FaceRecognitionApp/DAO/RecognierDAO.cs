using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognitionApp
{
    class RecognierDAO
    {
        private delegate void SafeCallDelegate(string text);
        public static void Recognizing(Dictionary<string, Button> sbdButton)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.WorkingDirectory = $@"{Directory.GetCurrentDirectory()}\ai\src";
            start.FileName = @"C:\Program Files\Python36\python.exe";
            start.Arguments = string.Format("{0}", "recognizer_video.py");
            start.UseShellExecute = false;
            start.CreateNoWindow = true;

            start.RedirectStandardOutput = true;
            Process process = Process.Start(start);
            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();

                Console.WriteLine(line);
                if (line.Contains("Recognized:"))
                {
                    string svID = line.Split(' ')[1];

                    Button button;
                    if (sbdButton.TryGetValue(svID, out button))
                    {

                        if (button.InvokeRequired)
                        {
                            button.BeginInvoke(new Action(() =>
                            {
                                button.BackColor = Color.Green;
                                button.ForeColor = Color.White;
                            }));
                        }
                        else
                        {
                            button.BackColor = Color.Green;
                            button.ForeColor = Color.White;
                        }
                            
                    }
                }
            }

            process.Close();
        }
    }
}
