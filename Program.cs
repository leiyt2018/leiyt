using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using coreOfJLUCheckIn;
using mail;

namespace CheckApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        // ʹ�������Ĵ򿨺����������������������Ҫ�ı����
        // ����򿨳ɹ�����0
        public static int Check(int hour, int minute, string user, string passwd,
            int grade, string cls, int zone, int apart, string room)
        {
            //MessageBox.Show("ִ�д�");
            return JluCheckIn.checkIn(room,user,passwd);
        }

        // ʹ���������ʼ������������������������Ҫ�ı����
        // ϰ���ϼ��˷���״ֵ̬��Ŀǰ��û��ʹ��
        public static int SendMail(string user, string passwd, string server, string mailto, string message)
        {
            //MessageBox.Show(message);
            return Send.SendMassage(server, user, passwd, mailto,message);
        }

    }
}
