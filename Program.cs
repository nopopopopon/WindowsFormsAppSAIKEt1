using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppSAIKEt1
{
    static class Program
    {
        // ���̃A�v���P�[�V�����̃G���g���[�|�C���g�͂���
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // SAIKE�ǋL��������

            //myApplication winAppBase = new myApplication();
            //winAppBase.Run(args);
            if (0 < args.Length)
            {
                MessageBox.Show(args[0] + "�ł��B");
            }
            //Mutex��
            string mutexName = "SAIKEApplicationSUJI";
            //Mutex�I�u�W�F�N�g���쐬����
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, mutexName);

            bool hasHandle = false;
            try 
            { 
                try
                {
                    //�~���[�e�b�N�X�̏��L����v������
                    hasHandle = mutex.WaitOne(0, false);
                }
            //.NET Framework 2.0�ȍ~�̏ꍇ
                catch (System.Threading.AbandonedMutexException)
                {
                    //�ʂ̃A�v���P�[�V�������~���[�e�b�N�X��������Ȃ��ŏI��������
                    hasHandle = true;
                }
                
                //�~���[�e�b�N�X�𓾂�ꂽ�����ׂ�
                if (hasHandle == false)
                {
                    //�����Ȃ������ꍇ�́A���łɋN�����Ă���Ɣ��f
                    string  files1 ="" ;
                    string[] files = System.Environment.GetCommandLineArgs();
                    if (0 < files.Length)
                    {
                        files1 = files[0];
                    }
                    //string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop);
                   
                    MessageBox.Show(files1 + "���d�N���͂ł��܂���B");
                    return;
                }

                //1��ڂ̋N���Ȃ̂ł͂��߂���Main���\�b�h�ɂ������R�[�h�����s
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
             }
            finally
            {
                if (hasHandle)
                {
                    //�~���[�e�b�N�X���������
                    mutex.ReleaseMutex();
                }
                mutex.Close();
            }
            

            // SAIKE�ǋL�����܂�

            /*
            Application.SetHighDpiMode(HighDpiMode.SystemAware);  
            Application.EnableVisualStyles();�@�@// XP�ȍ~�̃X�^�C���ɂ���
            Application.SetCompatibleTextRenderingDefault(false);  // GDI�ŕ`�悷��w��(�f�t�H���g)
            Application.Run(new Form1());
            */
        }
    }
}
