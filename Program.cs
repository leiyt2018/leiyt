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

        // 使用真正的打卡函数代替这个函数，尽量不要改变参数
        // 如果打卡成功返回0
        public static int Check(int hour, int minute, string user, string passwd,
            int grade, string cls, int zone, int apart, string room)
        {
            //MessageBox.Show("执行打卡");
            return JluCheckIn.checkIn(room,user,passwd);
        }

        // 使用真正的邮件函数代替这个函数，尽量不要改变参数
        // 习惯上加了返回状态值，目前并没有使用
        public static int SendMail(string user, string passwd, string server, string mailto, string message)
        {
            //MessageBox.Show(message);
            return Send.SendMassage(server, user, passwd, mailto,message);
        }

    }
}
