/*
 * 这个源文件的内容是窗口和各部件的事件响应函数，决定窗口的交互行为。
 */

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

namespace CheckApp
{
    public partial class MainForm : Form
    {
        // 动态生成文本内容
        private string[] grades;
        private string[] zones;
        private string[][] aparts;
        private string[] hours;
        private string[] mins;
        private string configFileName;  // 配置文件的名称
        private string delimiter;       // 配置文件使用的分隔符
        private bool launched;
        // 最终确定的参数
        private string user;
        private string passwd;
        private int grade;
        private string cls;
        private int zone;
        private int apart;
        private string room;
        private string mailUser;
        private string mailPasswd;
        private string mailServer;
        private string mailTo;
        // 任务列表
        private List<HourMin> checkTasks;
        // 重试次数
        int restTries;

        public MainForm()
        {
            InitializeComponent();

            // 初始化各种属性
            grades = new string[] { "2017", "2018", "2019", "2020" };
            zones = new string[] { "中心校区", "南岭校区", "新民校区", "南湖校区", "和平校区", "朝阳校区", "前卫北区" };
            aparts = new string[][]
            {
                new string[] { "北苑1公寓", "北苑2公寓", "南苑1公寓", "南苑2公寓",
                    "南苑3公寓", "南苑4公寓", "南苑5公寓A区", "南苑5公寓B区", "南苑5公寓C区",
                    "南苑6公寓", "南苑7公寓", "南苑8公寓", "南苑9公寓", "大学城1公寓", "大学城2公寓",
                    "大学城3公寓", "文苑1公寓", "文苑2公寓", "文苑3公寓", "文苑4公寓", "文苑5公寓",
                    "文苑6公寓", "文苑7公寓", "文苑8公寓", "文苑9公寓", "校外居住" },
                new string[] { "南岭1公寓", "南岭2公寓", "南岭3公寓", "南岭4公寓", "南岭5公寓",
                    "南岭6公寓", "南岭7公寓", "南岭8公寓", "南岭9公寓", "南岭10公寓", "南岭11公寓",
                    "南岭12公寓A区", "南岭12公寓B区", "南岭12公寓C区", "南岭13公寓", "南岭14公寓", "校外居住" },
                new string[] { "新民1公寓", "新民2公寓", "新民3公寓", "新民4公寓", "新民5公寓", "新民6公寓",
                    "新民7公寓", "新民8公寓", "新民9公寓", "新民10公寓", "新民11公寓", "校外居住" },
                new string[] { "南湖1公寓", "南湖2公寓", "南湖3公寓", "南湖4公寓", "南湖5公寓", "南湖6公寓", "校外居住" },
                new string[] { "和平1公寓", "和平2公寓", "和平3公寓", "和平4公寓", "和平5公寓", "和平6公寓", "和平7公寓", "和平8公寓", "校外居住" },
                new string[] { "朝阳1公寓", "朝阳2公寓", "朝阳3公寓", "朝阳4公寓", "朝阳5公寓", "朝阳6公寓", "朝阳7公寓", "校外居住" },
                new string[] { "北区1公寓", "北区2公寓", "北区3公寓", "北区4公寓", "北区5公寓", "北区6公寓", "北区7公寓", "北区8公寓", "校外居住" }
            };
            hours = new string[24];
            mins = new string[60];
            for (int iter = 0; iter < 24; iter++)
            {
                hours[iter] = iter.ToString().PadLeft(2, '0');
            }
            for (int iter = 0; iter < 60; iter++)
            {
                mins[iter] = iter.ToString().PadLeft(2, '0');
            }

            comboBoxGrade.DataSource = grades.Clone();
            comboBoxZone.DataSource = zones.Clone();
            comboBoxHour1.DataSource = hours.Clone();
            comboBoxHour2.DataSource = hours.Clone();
            comboBoxHour3.DataSource = hours.Clone();
            comboBoxMin1.DataSource = mins.Clone();
            comboBoxMin2.DataSource = mins.Clone();
            comboBoxMin3.DataSource = mins.Clone();
            timerTime_Tick(new object(), new EventArgs());

            configFileName = "checkapp.conf";
            delimiter = ">,.';?$~^<";
            launched = false;
        }

        // 根据选择的校区自动确定公寓楼列表
        private void comboBoxZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxApart.DataSource = aparts[comboBoxZone.SelectedIndex].Clone();
        }

        private void buttonAdd1_Click(object sender, EventArgs e)
        {
            buttonDel1.Visible = true;
            comboBoxHour2.Visible = true;
            labelHour2.Visible = true;
            comboBoxMin2.Visible = true;
            labelMin2.Visible = true;
            buttonAdd2.Visible = true;
            buttonAdd1.Visible = false;
            groupTask.Size = new Size(groupTask.Size.Width, groupTask.Size.Height + 50);
        }

        private void buttonAdd2_Click(object sender, EventArgs e)
        {
            buttonDel2.Visible = true;
            comboBoxHour3.Visible = true;
            labelHour3.Visible = true;
            comboBoxMin3.Visible = true;
            labelMin3.Visible = true;
            buttonAdd2.Visible = false;
            groupTask.Size = new Size(groupTask.Size.Width, groupTask.Size.Height + 50);
        }

        private void buttonDel2_Click(object sender, EventArgs e)
        {
            buttonDel2.Visible = false;
            comboBoxHour3.Visible = false;
            labelHour3.Visible = false;
            comboBoxMin3.Visible = false;
            labelMin3.Visible = false;
            buttonAdd2.Visible = true;
            comboBoxHour3.SelectedIndex = 0;
            comboBoxMin3.SelectedIndex = 0;
            groupTask.Size = new Size(groupTask.Size.Width, groupTask.Size.Height - 50);
        }

        private void buttonDel1_Click(object sender, EventArgs e)
        {
            if (buttonDel2.Visible)
            {
                comboBoxHour2.SelectedIndex = comboBoxHour3.SelectedIndex;
                comboBoxMin2.SelectedIndex = comboBoxMin3.SelectedIndex;
                buttonDel2_Click(new object(), new EventArgs());
            }
            else
            {
                buttonDel1.Visible = false;
                comboBoxHour2.Visible = false;
                labelHour2.Visible = false;
                comboBoxMin2.Visible = false;
                labelMin2.Visible = false;
                buttonAdd2.Visible = false;
                buttonAdd1.Visible = true;
                comboBoxHour2.SelectedIndex = 0;
                comboBoxMin2.SelectedIndex = 0;
                groupTask.Size = new Size(groupTask.Size.Width, groupTask.Size.Height - 50);
            }
        }

        // 显示当前时间
        private void timerTime_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void checkBoxMail_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMail.Checked)
            {
                groupMail.Enabled = true;
            }
            else
            {
                groupMail.Enabled = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 读取配置文件
            if (File.Exists(configFileName))
            {
                try
                {
                    var config = new StreamReader(configFileName);
                    var data = new Dictionary<string, string>();
                    for (string line; (line = config.ReadLine()) != null;)
                    {
                        var pare = line.Split(delimiter);
                        data.Add(pare[0], pare[1]);
                    }
                    var groups = new GroupBox[] { groupLogin, groupInfo, groupMail };
                    foreach (var theGroup in groups)
                    {
                        foreach (var item in theGroup.Controls)
                        {
                            if (item is TextBox)
                            {
                                ((TextBox)item).Text = data[((TextBox)item).Name];
                            }
                            else if (item is ComboBox)
                            {
                                ((ComboBox)item).SelectedItem = data[((ComboBox)item).Name];
                            }
                        }
                    }
                    checkBoxSave.Checked = Convert.ToBoolean(data[checkBoxSave.Name]);
                    checkBoxMail.Checked = Convert.ToBoolean(data[checkBoxMail.Name]);
                    comboBoxHour1.SelectedItem = data[comboBoxHour1.Name];
                    comboBoxMin1.SelectedItem = data[comboBoxMin1.Name];
                    if (data.ContainsKey(comboBoxHour2.Name))
                    {
                        comboBoxHour2.SelectedItem = data[comboBoxHour2.Name];
                        comboBoxMin2.SelectedItem = data[comboBoxMin2.Name];
                        buttonAdd1_Click(new object(), new EventArgs());
                    }
                    if (data.ContainsKey(comboBoxHour3.Name))
                    {
                        comboBoxHour3.SelectedItem = data[comboBoxHour3.Name];
                        comboBoxMin3.SelectedItem = data[comboBoxMin3.Name];
                        buttonAdd2_Click(new object(), new EventArgs());
                    }
                    config.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("无法读取配置文件", "文件错误");
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 保存配置文件
            if (checkBoxSave.Checked)
            {
                try
                {
                    var config = new StreamWriter(configFileName);
                    var groups = new GroupBox[] { groupLogin, groupInfo, groupMail };
                    foreach (var theGroup in groups)
                    {
                        foreach (var item in theGroup.Controls)
                        {
                            if (item is TextBox)
                            {
                                config.WriteLine(((TextBox)item).Name + delimiter + ((TextBox)item).Text);
                            }
                            else if (item is ComboBox)
                            {
                                config.WriteLine(((ComboBox)item).Name + delimiter + ((ComboBox)item).SelectedItem);
                            }
                        }
                    }
                    config.WriteLine(checkBoxSave.Name + delimiter + checkBoxSave.Checked);
                    config.WriteLine(checkBoxMail.Name + delimiter + checkBoxMail.Checked);
                    config.WriteLine(comboBoxHour1.Name + delimiter + comboBoxHour1.SelectedItem);
                    config.WriteLine(comboBoxMin1.Name + delimiter + comboBoxMin1.SelectedItem);
                    if (buttonDel1.Visible)
                    {
                        config.WriteLine(comboBoxHour2.Name + delimiter + comboBoxHour2.SelectedItem);
                        config.WriteLine(comboBoxMin2.Name + delimiter + comboBoxMin2.SelectedItem);
                    }
                    if (buttonDel2.Visible)
                    {
                        config.WriteLine(comboBoxHour3.Name + delimiter + comboBoxHour3.SelectedItem);
                        config.WriteLine(comboBoxMin3.Name + delimiter + comboBoxMin3.SelectedItem);
                    }
                    config.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("无法保存配置文件", "文件错误");
                }
            }
        }

        // 检查信息是否完整
        private bool checkInfo()
        {
            if (textBoxUser.Text.Length * textBoxPasswd.Text.Length
               * textBoxClass.Text.Length * textBoxRoom.Text.Length == 0)
            {
                return false;
            }
            if (checkBoxMail.Checked)
            {
                if (textBoxMailUser.Text.Length * textBoxMailPasswd.Text.Length
                    * textBoxMailServer.Text.Length * textBoxMailTo.Text.Length == 0)
                {
                    return false;
                }
            }
            if ((comboBoxGrade.SelectedIndex | comboBoxZone.SelectedIndex | comboBoxApart.SelectedIndex
                | comboBoxHour1.SelectedIndex | comboBoxHour2.SelectedIndex) == -1)
            {
                return false;
            }
            return true;
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            if (launched)
            {
                // 停止计时器，启用哥部件
                launched = false;
                buttonLaunch.Text = "启动";
                foreach (var item in Controls)
                {
                    if (((Control)item).Name.Equals(buttonLaunch.Name)) { }
                    else if (((Control)item).Name.Equals(groupTime.Name)) { }
                    else if (((Control)item).Name.Equals(groupMail.Name))
                    {
                        checkBoxMail_CheckedChanged(new object(), new EventArgs());
                    }
                    else
                    {
                        ((Control)item).Enabled = true;
                    }
                }

                timerCheck.Stop();
                if (timerRetry.Enabled)
                {
                    timerRetry.Stop();
                }
            }
            else
            {
                // 检查信息
                if (!checkInfo())
                {
                    MessageBox.Show("请填写完整信息", "信息不完整");
                    return;
                }
                launched = true;
                buttonLaunch.Text = "停止";
                // 禁用各部件
                foreach (var item in Controls)
                {
                    if (((Control)item).Name.Equals(buttonLaunch.Name)) { }
                    else if (((Control)item).Name.Equals(groupTime.Name)) { }
                    else
                    {
                        ((Control)item).Enabled = false;
                    }
                }

                // 初始化打卡参数，启动计时器
                iniParameter();
                timerCheck_Tick(new object(), new EventArgs());
                timerCheck.Start();
            }
        }

        // 初始化打卡参数
        private void iniParameter()
        {
            user = textBoxUser.Text;
            passwd = textBoxPasswd.Text;
            grade = comboBoxGrade.SelectedIndex;
            cls = textBoxClass.Text;
            zone = comboBoxZone.SelectedIndex;
            apart = comboBoxApart.SelectedIndex;
            room = textBoxRoom.Text;
            mailUser = textBoxMailUser.Text;
            mailPasswd = textBoxMailPasswd.Text;
            mailServer = textBoxMailServer.Text;
            mailTo = textBoxMailTo.Text;
            checkTasks = new List<HourMin>();
            checkTasks.Add(new HourMin(comboBoxHour1.SelectedIndex, comboBoxMin1.SelectedIndex));
            if (buttonDel1.Visible)
            {
                checkTasks.Add(new HourMin(comboBoxHour2.SelectedIndex, comboBoxMin2.SelectedIndex));
            }
            if (buttonDel2.Visible)
            {
                checkTasks.Add(new HourMin(comboBoxHour3.SelectedIndex, comboBoxMin3.SelectedIndex));
            }
        }

        private class HourMin
        {
            public int hor;
            public int mnt;

            public HourMin(int h, int m)
            {
                hor = h;
                mnt = m;
            }
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            int chour = DateTime.Now.Hour;
            int cmin = DateTime.Now.Minute;
            bool isTime = false;

            // 检查时间
            foreach (var item in checkTasks)
            {
                if (item.hor == chour && item.mnt == cmin)
                {
                    isTime = true;
                    break;
                }
            }
            // 打卡，并发送邮件
            if (isTime)
            {
                int ret = Program.Check(chour, cmin, user, passwd, grade, cls, zone, apart, room);
                if (ret == 0)
                {
                    if (checkBoxMail.Checked)
                    {
                        Program.SendMail(mailUser, mailPasswd, mailServer, mailTo, "打卡成功");
                    }
                }
                else
                {
                    restTries = 5;
                    timerRetry.Start();
                }
            }
        }

        // 重试
        private void timerRetry_Tick(object sender, EventArgs e)
        {
            restTries--;
            int chour = DateTime.Now.Hour;
            int cmin = DateTime.Now.Minute;

            int ret = Program.Check(chour, cmin, user, passwd, grade, cls, zone, apart, room);
            if (ret == 0)
            {
                timerRetry.Stop();
                if (checkBoxMail.Checked)
                {
                    Program.SendMail(mailUser, mailPasswd, mailServer, mailTo, DateTime.Now.ToShortTimeString() + " 打卡成功");
                }
            }
            else if(restTries <= 0)
            {
                timerRetry.Stop();
                if (checkBoxMail.Checked)
                {
                    Program.SendMail(mailUser, mailPasswd, mailServer, mailTo, DateTime.Now.ToShortTimeString() + " 打卡失败");
                }
            }
        }

        private void comboBoxApart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxGrade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupLogin_Enter(object sender, EventArgs e)
        {

        }
    }
}
