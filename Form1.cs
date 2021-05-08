using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// using Microsoft.VisualBasic.ApplicationServices;  // add .NET5を入れて　Microsoft.VisualBasic.Forms.dllを参照しないと出ない

namespace WindowsFormsAppSAIKEt1
{
    /*
    // 多重起動のときに呼ばれるやつ定義
    class myApplication : Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    {
        public myApplication()  : base()
        {
            this.EnableVisualStyles = true;
            this.IsSingleInstance = true;
            this.MainForm = new Form1();//スタートアップフォームを設定
            this.StartupNextInstance += new StartupNextInstanceEventHandler(myApplication_StartupNextInstance);
        }
        void myApplication_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            //ここに二重起動されたときの処理を書く
            //e.CommandLineでコマンドライン引数を取得出来る
            MessageBox.Show("{0}を開くことができません");
        }
    }
    */

    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.AllowDrop = true;  // Drop許可に必要

            // ファイルがダブルクリックされたとき
            string[] files = System.Environment.GetCommandLineArgs();
            var files1 = files.Skip(1);
            foreach (var filePath in files1)
            {
                if (System.IO.File.Exists(filePath))
                {
                    try
                    {
                        pictureBox1.ImageLocation = filePath;

                        break;
                    }
                    catch
                    {
                        MessageBox.Show(String.Format("{0}をダブルクリックで開くことができません", filePath), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }


        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop);
            
            if (System.IO.File.Exists(fileName[0]) == true)
            {
                pictureBox1.ImageLocation = fileName[0];
                // Form1.ActiveForm.Text = fileName[0];
            }
            else
            {
                // ファイルがないなら何もしない
                MessageBox.Show("ファイルがない");            }

            this.Show();
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;　　//　dragされてきたのがファイルなら受ける
            else
                e.Effect = DragDropEffects.None;

        }
    }

   
}
