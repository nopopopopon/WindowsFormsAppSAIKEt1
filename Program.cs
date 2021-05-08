using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppSAIKEt1
{
    static class Program
    {
        // このアプリケーションのエントリーポイントはここ
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // SAIKE追記ここから

            //myApplication winAppBase = new myApplication();
            //winAppBase.Run(args);
            if (0 < args.Length)
            {
                MessageBox.Show(args[0] + "でし。");
            }
            //Mutex名
            string mutexName = "SAIKEApplicationSUJI";
            //Mutexオブジェクトを作成する
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, mutexName);

            bool hasHandle = false;
            try 
            { 
                try
                {
                    //ミューテックスの所有権を要求する
                    hasHandle = mutex.WaitOne(0, false);
                }
            //.NET Framework 2.0以降の場合
                catch (System.Threading.AbandonedMutexException)
                {
                    //別のアプリケーションがミューテックスを解放しないで終了した時
                    hasHandle = true;
                }
                
                //ミューテックスを得られたか調べる
                if (hasHandle == false)
                {
                    //得られなかった場合は、すでに起動していると判断
                    string  files1 ="" ;
                    string[] files = System.Environment.GetCommandLineArgs();
                    if (0 < files.Length)
                    {
                        files1 = files[0];
                    }
                    //string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop);
                   
                    MessageBox.Show(files1 + "多重起動はできません。");
                    return;
                }

                //1回目の起動なのではじめからMainメソッドにあったコードを実行
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
             }
            finally
            {
                if (hasHandle)
                {
                    //ミューテックスを解放する
                    mutex.ReleaseMutex();
                }
                mutex.Close();
            }
            

            // SAIKE追記ここまで

            /*
            Application.SetHighDpiMode(HighDpiMode.SystemAware);  
            Application.EnableVisualStyles();　　// XP以降のスタイルにする
            Application.SetCompatibleTextRenderingDefault(false);  // GDIで描画する指定(デフォルト)
            Application.Run(new Form1());
            */
        }
    }
}
