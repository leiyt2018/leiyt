/*
 * 这个源文件的内容是窗口以及各个部件的属性，如不了解禁止修改
 */


namespace CheckApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupLogin = new System.Windows.Forms.GroupBox();
            this.labelPasswd = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.textBoxPasswd = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.comboBoxApart = new System.Windows.Forms.ComboBox();
            this.comboBoxZone = new System.Windows.Forms.ComboBox();
            this.comboBoxGrade = new System.Windows.Forms.ComboBox();
            this.labelRoom = new System.Windows.Forms.Label();
            this.textBoxRoom = new System.Windows.Forms.TextBox();
            this.labelApart = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.textBoxClass = new System.Windows.Forms.TextBox();
            this.labelGrade = new System.Windows.Forms.Label();
            this.labelZone = new System.Windows.Forms.Label();
            this.groupTask = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelMin3 = new System.Windows.Forms.Label();
            this.labelMin2 = new System.Windows.Forms.Label();
            this.labelMin1 = new System.Windows.Forms.Label();
            this.labelHour3 = new System.Windows.Forms.Label();
            this.labelHour2 = new System.Windows.Forms.Label();
            this.labelHour1 = new System.Windows.Forms.Label();
            this.buttonDel2 = new System.Windows.Forms.Button();
            this.buttonDel1 = new System.Windows.Forms.Button();
            this.buttonAdd2 = new System.Windows.Forms.Button();
            this.buttonAdd1 = new System.Windows.Forms.Button();
            this.comboBoxMin3 = new System.Windows.Forms.ComboBox();
            this.comboBoxHour3 = new System.Windows.Forms.ComboBox();
            this.comboBoxMin2 = new System.Windows.Forms.ComboBox();
            this.comboBoxHour2 = new System.Windows.Forms.ComboBox();
            this.comboBoxMin1 = new System.Windows.Forms.ComboBox();
            this.comboBoxHour1 = new System.Windows.Forms.ComboBox();
            this.groupTime = new System.Windows.Forms.GroupBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.checkBoxMail = new System.Windows.Forms.CheckBox();
            this.groupMail = new System.Windows.Forms.GroupBox();
            this.labelMailTo = new System.Windows.Forms.Label();
            this.textBoxMailTo = new System.Windows.Forms.TextBox();
            this.labelMailServer = new System.Windows.Forms.Label();
            this.textBoxMailServer = new System.Windows.Forms.TextBox();
            this.labelMailPasswd = new System.Windows.Forms.Label();
            this.textBoxMailPasswd = new System.Windows.Forms.TextBox();
            this.labelMailUser = new System.Windows.Forms.Label();
            this.textBoxMailUser = new System.Windows.Forms.TextBox();
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.timerRetry = new System.Windows.Forms.Timer(this.components);
            this.groupLogin.SuspendLayout();
            this.groupInfo.SuspendLayout();
            this.groupTask.SuspendLayout();
            this.groupTime.SuspendLayout();
            this.groupMail.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLogin
            // 
            this.groupLogin.Controls.Add(this.labelPasswd);
            this.groupLogin.Controls.Add(this.labelUser);
            this.groupLogin.Controls.Add(this.textBoxPasswd);
            this.groupLogin.Controls.Add(this.textBoxUser);
            this.groupLogin.Location = new System.Drawing.Point(15, 16);
            this.groupLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupLogin.Name = "groupLogin";
            this.groupLogin.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupLogin.Size = new System.Drawing.Size(360, 127);
            this.groupLogin.TabIndex = 0;
            this.groupLogin.TabStop = false;
            this.groupLogin.Text = "登录区";
            // 
            // labelPasswd
            // 
            this.labelPasswd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPasswd.Location = new System.Drawing.Point(8, 81);
            this.labelPasswd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPasswd.Name = "labelPasswd";
            this.labelPasswd.Size = new System.Drawing.Size(77, 31);
            this.labelPasswd.TabIndex = 3;
            this.labelPasswd.Text = "密码:";
            this.labelPasswd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelUser
            // 
            this.labelUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUser.Location = new System.Drawing.Point(8, 43);
            this.labelUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(77, 31);
            this.labelUser.TabIndex = 2;
            this.labelUser.Text = "用户名:";
            this.labelUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPasswd
            // 
            this.textBoxPasswd.Location = new System.Drawing.Point(93, 81);
            this.textBoxPasswd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPasswd.Name = "textBoxPasswd";
            this.textBoxPasswd.Size = new System.Drawing.Size(256, 27);
            this.textBoxPasswd.TabIndex = 1;
            this.textBoxPasswd.UseSystemPasswordChar = true;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(93, 43);
            this.textBoxUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(256, 27);
            this.textBoxUser.TabIndex = 0;
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.comboBoxApart);
            this.groupInfo.Controls.Add(this.comboBoxZone);
            this.groupInfo.Controls.Add(this.comboBoxGrade);
            this.groupInfo.Controls.Add(this.labelRoom);
            this.groupInfo.Controls.Add(this.textBoxRoom);
            this.groupInfo.Controls.Add(this.labelApart);
            this.groupInfo.Controls.Add(this.labelClass);
            this.groupInfo.Controls.Add(this.textBoxClass);
            this.groupInfo.Controls.Add(this.labelGrade);
            this.groupInfo.Controls.Add(this.labelZone);
            this.groupInfo.Location = new System.Drawing.Point(15, 151);
            this.groupInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupInfo.Size = new System.Drawing.Size(360, 240);
            this.groupInfo.TabIndex = 1;
            this.groupInfo.TabStop = false;
            this.groupInfo.Text = "信息区";
            // 
            // comboBoxApart
            // 
            this.comboBoxApart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxApart.FormattingEnabled = true;
            this.comboBoxApart.Location = new System.Drawing.Point(93, 156);
            this.comboBoxApart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxApart.Name = "comboBoxApart";
            this.comboBoxApart.Size = new System.Drawing.Size(256, 28);
            this.comboBoxApart.TabIndex = 5;
            this.comboBoxApart.Tag = "abc";
            // 
            // comboBoxZone
            // 
            this.comboBoxZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZone.FormattingEnabled = true;
            this.comboBoxZone.Location = new System.Drawing.Point(93, 117);
            this.comboBoxZone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxZone.Name = "comboBoxZone";
            this.comboBoxZone.Size = new System.Drawing.Size(256, 28);
            this.comboBoxZone.TabIndex = 4;
            this.comboBoxZone.SelectedIndexChanged += new System.EventHandler(this.comboBoxZone_SelectedIndexChanged);
            // 
            // comboBoxGrade
            // 
            this.comboBoxGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrade.FormattingEnabled = true;
            this.comboBoxGrade.Location = new System.Drawing.Point(93, 40);
            this.comboBoxGrade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxGrade.Name = "comboBoxGrade";
            this.comboBoxGrade.Size = new System.Drawing.Size(256, 28);
            this.comboBoxGrade.TabIndex = 2;
            // 
            // labelRoom
            // 
            this.labelRoom.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRoom.Location = new System.Drawing.Point(8, 195);
            this.labelRoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRoom.Name = "labelRoom";
            this.labelRoom.Size = new System.Drawing.Size(77, 31);
            this.labelRoom.TabIndex = 12;
            this.labelRoom.Text = "寝室号:";
            this.labelRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxRoom
            // 
            this.textBoxRoom.Location = new System.Drawing.Point(93, 195);
            this.textBoxRoom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRoom.Name = "textBoxRoom";
            this.textBoxRoom.Size = new System.Drawing.Size(256, 27);
            this.textBoxRoom.TabIndex = 6;
            // 
            // labelApart
            // 
            this.labelApart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelApart.Location = new System.Drawing.Point(8, 156);
            this.labelApart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApart.Name = "labelApart";
            this.labelApart.Size = new System.Drawing.Size(77, 31);
            this.labelApart.TabIndex = 10;
            this.labelApart.Text = "公寓楼:";
            this.labelApart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelClass
            // 
            this.labelClass.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelClass.Location = new System.Drawing.Point(8, 79);
            this.labelClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(77, 31);
            this.labelClass.TabIndex = 8;
            this.labelClass.Text = "班级:";
            this.labelClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxClass
            // 
            this.textBoxClass.Location = new System.Drawing.Point(93, 79);
            this.textBoxClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxClass.Name = "textBoxClass";
            this.textBoxClass.Size = new System.Drawing.Size(256, 27);
            this.textBoxClass.TabIndex = 3;
            // 
            // labelGrade
            // 
            this.labelGrade.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGrade.Location = new System.Drawing.Point(8, 40);
            this.labelGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGrade.Name = "labelGrade";
            this.labelGrade.Size = new System.Drawing.Size(77, 31);
            this.labelGrade.TabIndex = 6;
            this.labelGrade.Text = "年级:";
            this.labelGrade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelZone
            // 
            this.labelZone.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelZone.Location = new System.Drawing.Point(8, 117);
            this.labelZone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelZone.Name = "labelZone";
            this.labelZone.Size = new System.Drawing.Size(77, 31);
            this.labelZone.TabIndex = 4;
            this.labelZone.Text = "校区:";
            this.labelZone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupTask
            // 
            this.groupTask.Controls.Add(this.label7);
            this.groupTask.Controls.Add(this.labelMin3);
            this.groupTask.Controls.Add(this.labelMin2);
            this.groupTask.Controls.Add(this.labelMin1);
            this.groupTask.Controls.Add(this.labelHour3);
            this.groupTask.Controls.Add(this.labelHour2);
            this.groupTask.Controls.Add(this.labelHour1);
            this.groupTask.Controls.Add(this.buttonDel2);
            this.groupTask.Controls.Add(this.buttonDel1);
            this.groupTask.Controls.Add(this.buttonAdd2);
            this.groupTask.Controls.Add(this.buttonAdd1);
            this.groupTask.Controls.Add(this.comboBoxMin3);
            this.groupTask.Controls.Add(this.comboBoxHour3);
            this.groupTask.Controls.Add(this.comboBoxMin2);
            this.groupTask.Controls.Add(this.comboBoxHour2);
            this.groupTask.Controls.Add(this.comboBoxMin1);
            this.groupTask.Controls.Add(this.comboBoxHour1);
            this.groupTask.Location = new System.Drawing.Point(15, 400);
            this.groupTask.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupTask.Name = "groupTask";
            this.groupTask.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupTask.Size = new System.Drawing.Size(360, 168);
            this.groupTask.TabIndex = 2;
            this.groupTask.TabStop = false;
            this.groupTask.Text = "任务区";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(51, 40);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(247, 44);
            this.label7.TabIndex = 16;
            this.label7.Text = "选择打卡时间";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMin3
            // 
            this.labelMin3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMin3.Location = new System.Drawing.Point(266, 237);
            this.labelMin3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMin3.Name = "labelMin3";
            this.labelMin3.Size = new System.Drawing.Size(26, 39);
            this.labelMin3.TabIndex = 15;
            this.labelMin3.Text = "分";
            this.labelMin3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMin3.Visible = false;
            // 
            // labelMin2
            // 
            this.labelMin2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMin2.Location = new System.Drawing.Point(266, 177);
            this.labelMin2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMin2.Name = "labelMin2";
            this.labelMin2.Size = new System.Drawing.Size(26, 39);
            this.labelMin2.TabIndex = 14;
            this.labelMin2.Text = "分";
            this.labelMin2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMin2.Visible = false;
            // 
            // labelMin1
            // 
            this.labelMin1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMin1.Location = new System.Drawing.Point(266, 116);
            this.labelMin1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMin1.Name = "labelMin1";
            this.labelMin1.Size = new System.Drawing.Size(26, 39);
            this.labelMin1.TabIndex = 13;
            this.labelMin1.Text = "分";
            this.labelMin1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHour3
            // 
            this.labelHour3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHour3.Location = new System.Drawing.Point(148, 239);
            this.labelHour3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHour3.Name = "labelHour3";
            this.labelHour3.Size = new System.Drawing.Size(26, 39);
            this.labelHour3.TabIndex = 12;
            this.labelHour3.Text = "时";
            this.labelHour3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelHour3.Visible = false;
            // 
            // labelHour2
            // 
            this.labelHour2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHour2.Location = new System.Drawing.Point(148, 177);
            this.labelHour2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHour2.Name = "labelHour2";
            this.labelHour2.Size = new System.Drawing.Size(26, 39);
            this.labelHour2.TabIndex = 11;
            this.labelHour2.Text = "时";
            this.labelHour2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelHour2.Visible = false;
            // 
            // labelHour1
            // 
            this.labelHour1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHour1.Location = new System.Drawing.Point(148, 116);
            this.labelHour1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHour1.Name = "labelHour1";
            this.labelHour1.Size = new System.Drawing.Size(26, 39);
            this.labelHour1.TabIndex = 10;
            this.labelHour1.Text = "时";
            this.labelHour1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDel2
            // 
            this.buttonDel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDel2.Location = new System.Drawing.Point(17, 237);
            this.buttonDel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDel2.Name = "buttonDel2";
            this.buttonDel2.Size = new System.Drawing.Size(39, 40);
            this.buttonDel2.TabIndex = 9;
            this.buttonDel2.Text = "-";
            this.buttonDel2.UseVisualStyleBackColor = true;
            this.buttonDel2.Visible = false;
            this.buttonDel2.Click += new System.EventHandler(this.buttonDel2_Click);
            // 
            // buttonDel1
            // 
            this.buttonDel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDel1.Location = new System.Drawing.Point(17, 175);
            this.buttonDel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDel1.Name = "buttonDel1";
            this.buttonDel1.Size = new System.Drawing.Size(39, 40);
            this.buttonDel1.TabIndex = 8;
            this.buttonDel1.Text = "-";
            this.buttonDel1.UseVisualStyleBackColor = true;
            this.buttonDel1.Visible = false;
            this.buttonDel1.Click += new System.EventHandler(this.buttonDel1_Click);
            // 
            // buttonAdd2
            // 
            this.buttonAdd2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd2.Location = new System.Drawing.Point(301, 175);
            this.buttonAdd2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdd2.Name = "buttonAdd2";
            this.buttonAdd2.Size = new System.Drawing.Size(39, 40);
            this.buttonAdd2.TabIndex = 7;
            this.buttonAdd2.Text = "+";
            this.buttonAdd2.UseVisualStyleBackColor = true;
            this.buttonAdd2.Visible = false;
            this.buttonAdd2.Click += new System.EventHandler(this.buttonAdd2_Click);
            // 
            // buttonAdd1
            // 
            this.buttonAdd1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd1.Location = new System.Drawing.Point(301, 113);
            this.buttonAdd1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdd1.Name = "buttonAdd1";
            this.buttonAdd1.Size = new System.Drawing.Size(39, 40);
            this.buttonAdd1.TabIndex = 6;
            this.buttonAdd1.Text = "+";
            this.buttonAdd1.UseVisualStyleBackColor = true;
            this.buttonAdd1.Click += new System.EventHandler(this.buttonAdd1_Click);
            // 
            // comboBoxMin3
            // 
            this.comboBoxMin3.DropDownHeight = 300;
            this.comboBoxMin3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMin3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxMin3.FormattingEnabled = true;
            this.comboBoxMin3.IntegralHeight = false;
            this.comboBoxMin3.Location = new System.Drawing.Point(181, 239);
            this.comboBoxMin3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxMin3.Name = "comboBoxMin3";
            this.comboBoxMin3.Size = new System.Drawing.Size(76, 36);
            this.comboBoxMin3.TabIndex = 5;
            this.comboBoxMin3.Visible = false;
            // 
            // comboBoxHour3
            // 
            this.comboBoxHour3.DropDownHeight = 300;
            this.comboBoxHour3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHour3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxHour3.FormattingEnabled = true;
            this.comboBoxHour3.IntegralHeight = false;
            this.comboBoxHour3.Location = new System.Drawing.Point(63, 240);
            this.comboBoxHour3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxHour3.Name = "comboBoxHour3";
            this.comboBoxHour3.Size = new System.Drawing.Size(76, 36);
            this.comboBoxHour3.TabIndex = 4;
            this.comboBoxHour3.Visible = false;
            // 
            // comboBoxMin2
            // 
            this.comboBoxMin2.DropDownHeight = 300;
            this.comboBoxMin2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMin2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxMin2.FormattingEnabled = true;
            this.comboBoxMin2.IntegralHeight = false;
            this.comboBoxMin2.Location = new System.Drawing.Point(181, 177);
            this.comboBoxMin2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxMin2.Name = "comboBoxMin2";
            this.comboBoxMin2.Size = new System.Drawing.Size(76, 36);
            this.comboBoxMin2.TabIndex = 3;
            this.comboBoxMin2.Visible = false;
            // 
            // comboBoxHour2
            // 
            this.comboBoxHour2.DropDownHeight = 300;
            this.comboBoxHour2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHour2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxHour2.FormattingEnabled = true;
            this.comboBoxHour2.IntegralHeight = false;
            this.comboBoxHour2.Location = new System.Drawing.Point(63, 177);
            this.comboBoxHour2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxHour2.Name = "comboBoxHour2";
            this.comboBoxHour2.Size = new System.Drawing.Size(76, 36);
            this.comboBoxHour2.TabIndex = 2;
            this.comboBoxHour2.Visible = false;
            // 
            // comboBoxMin1
            // 
            this.comboBoxMin1.DropDownHeight = 300;
            this.comboBoxMin1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMin1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxMin1.FormattingEnabled = true;
            this.comboBoxMin1.IntegralHeight = false;
            this.comboBoxMin1.Location = new System.Drawing.Point(181, 116);
            this.comboBoxMin1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxMin1.Name = "comboBoxMin1";
            this.comboBoxMin1.Size = new System.Drawing.Size(76, 36);
            this.comboBoxMin1.TabIndex = 1;
            // 
            // comboBoxHour1
            // 
            this.comboBoxHour1.DropDownHeight = 300;
            this.comboBoxHour1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHour1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxHour1.FormattingEnabled = true;
            this.comboBoxHour1.IntegralHeight = false;
            this.comboBoxHour1.Location = new System.Drawing.Point(63, 116);
            this.comboBoxHour1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxHour1.Name = "comboBoxHour1";
            this.comboBoxHour1.Size = new System.Drawing.Size(76, 36);
            this.comboBoxHour1.TabIndex = 0;
            // 
            // groupTime
            // 
            this.groupTime.Controls.Add(this.labelTime);
            this.groupTime.Location = new System.Drawing.Point(432, 16);
            this.groupTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupTime.Name = "groupTime";
            this.groupTime.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupTime.Size = new System.Drawing.Size(410, 127);
            this.groupTime.TabIndex = 3;
            this.groupTime.TabStop = false;
            this.groupTime.Text = "当前时间";
            // 
            // labelTime
            // 
            this.labelTime.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTime.Location = new System.Drawing.Point(58, 27);
            this.labelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(296, 89);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "00:00:00";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerTime
            // 
            this.timerTime.Enabled = true;
            this.timerTime.Interval = 1000;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.AutoSize = true;
            this.checkBoxSave.Location = new System.Drawing.Point(471, 171);
            this.checkBoxSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Size = new System.Drawing.Size(136, 24);
            this.checkBoxSave.TabIndex = 4;
            this.checkBoxSave.Text = "关闭时保存配置";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            // 
            // checkBoxMail
            // 
            this.checkBoxMail.AutoSize = true;
            this.checkBoxMail.Location = new System.Drawing.Point(693, 171);
            this.checkBoxMail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxMail.Name = "checkBoxMail";
            this.checkBoxMail.Size = new System.Drawing.Size(91, 24);
            this.checkBoxMail.TabIndex = 5;
            this.checkBoxMail.Text = "邮件提醒";
            this.checkBoxMail.UseVisualStyleBackColor = true;
            this.checkBoxMail.CheckedChanged += new System.EventHandler(this.checkBoxMail_CheckedChanged);
            // 
            // groupMail
            // 
            this.groupMail.Controls.Add(this.labelMailTo);
            this.groupMail.Controls.Add(this.textBoxMailTo);
            this.groupMail.Controls.Add(this.labelMailServer);
            this.groupMail.Controls.Add(this.textBoxMailServer);
            this.groupMail.Controls.Add(this.labelMailPasswd);
            this.groupMail.Controls.Add(this.textBoxMailPasswd);
            this.groupMail.Controls.Add(this.labelMailUser);
            this.groupMail.Controls.Add(this.textBoxMailUser);
            this.groupMail.Enabled = false;
            this.groupMail.Location = new System.Drawing.Point(432, 229);
            this.groupMail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupMail.Name = "groupMail";
            this.groupMail.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupMail.Size = new System.Drawing.Size(410, 203);
            this.groupMail.TabIndex = 6;
            this.groupMail.TabStop = false;
            this.groupMail.Text = "SMTP配置";
            // 
            // labelMailTo
            // 
            this.labelMailTo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMailTo.Location = new System.Drawing.Point(8, 159);
            this.labelMailTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMailTo.Name = "labelMailTo";
            this.labelMailTo.Size = new System.Drawing.Size(129, 31);
            this.labelMailTo.TabIndex = 10;
            this.labelMailTo.Text = "收件人";
            this.labelMailTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMailTo
            // 
            this.textBoxMailTo.Location = new System.Drawing.Point(141, 159);
            this.textBoxMailTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMailTo.Name = "textBoxMailTo";
            this.textBoxMailTo.Size = new System.Drawing.Size(256, 27);
            this.textBoxMailTo.TabIndex = 9;
            // 
            // labelMailServer
            // 
            this.labelMailServer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMailServer.Location = new System.Drawing.Point(8, 120);
            this.labelMailServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMailServer.Name = "labelMailServer";
            this.labelMailServer.Size = new System.Drawing.Size(129, 31);
            this.labelMailServer.TabIndex = 8;
            this.labelMailServer.Text = "SMTP服务器:";
            this.labelMailServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMailServer
            // 
            this.textBoxMailServer.Location = new System.Drawing.Point(141, 120);
            this.textBoxMailServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMailServer.Name = "textBoxMailServer";
            this.textBoxMailServer.Size = new System.Drawing.Size(256, 27);
            this.textBoxMailServer.TabIndex = 7;
            // 
            // labelMailPasswd
            // 
            this.labelMailPasswd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMailPasswd.Location = new System.Drawing.Point(8, 81);
            this.labelMailPasswd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMailPasswd.Name = "labelMailPasswd";
            this.labelMailPasswd.Size = new System.Drawing.Size(129, 31);
            this.labelMailPasswd.TabIndex = 6;
            this.labelMailPasswd.Text = "密码:";
            this.labelMailPasswd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMailPasswd
            // 
            this.textBoxMailPasswd.Location = new System.Drawing.Point(141, 81);
            this.textBoxMailPasswd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMailPasswd.Name = "textBoxMailPasswd";
            this.textBoxMailPasswd.Size = new System.Drawing.Size(256, 27);
            this.textBoxMailPasswd.TabIndex = 5;
            this.textBoxMailPasswd.UseSystemPasswordChar = true;
            // 
            // labelMailUser
            // 
            this.labelMailUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMailUser.Location = new System.Drawing.Point(8, 43);
            this.labelMailUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMailUser.Name = "labelMailUser";
            this.labelMailUser.Size = new System.Drawing.Size(129, 31);
            this.labelMailUser.TabIndex = 4;
            this.labelMailUser.Text = "用户名:";
            this.labelMailUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMailUser
            // 
            this.textBoxMailUser.Location = new System.Drawing.Point(141, 43);
            this.textBoxMailUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMailUser.Name = "textBoxMailUser";
            this.textBoxMailUser.Size = new System.Drawing.Size(256, 27);
            this.textBoxMailUser.TabIndex = 3;
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonLaunch.Location = new System.Drawing.Point(482, 533);
            this.buttonLaunch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(309, 107);
            this.buttonLaunch.TabIndex = 7;
            this.buttonLaunch.Text = "启动";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // timerCheck
            // 
            this.timerCheck.Interval = 60000;
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // timerRetry
            // 
            this.timerRetry.Interval = 3000;
            this.timerRetry.Tick += new System.EventHandler(this.timerRetry_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 748);
            this.Controls.Add(this.buttonLaunch);
            this.Controls.Add(this.groupMail);
            this.Controls.Add(this.checkBoxMail);
            this.Controls.Add(this.checkBoxSave);
            this.Controls.Add(this.groupTime);
            this.Controls.Add(this.groupTask);
            this.Controls.Add(this.groupInfo);
            this.Controls.Add(this.groupLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupLogin.ResumeLayout(false);
            this.groupLogin.PerformLayout();
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            this.groupTask.ResumeLayout(false);
            this.groupTime.ResumeLayout(false);
            this.groupMail.ResumeLayout(false);
            this.groupMail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupLogin;
        private System.Windows.Forms.Label labelPasswd;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textBoxPasswd;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.Label labelRoom;
        private System.Windows.Forms.TextBox textBoxRoom;
        private System.Windows.Forms.Label labelApart;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.Label labelGrade;
        private System.Windows.Forms.Label labelZone;
        private System.Windows.Forms.ComboBox comboBoxGrade;
        private System.Windows.Forms.ComboBox comboBoxApart;
        private System.Windows.Forms.ComboBox comboBoxZone;
        private System.Windows.Forms.GroupBox groupTask;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelMin3;
        private System.Windows.Forms.Label labelMin2;
        private System.Windows.Forms.Label labelMin1;
        private System.Windows.Forms.Label labelHour3;
        private System.Windows.Forms.Label labelHour2;
        private System.Windows.Forms.Label labelHour1;
        private System.Windows.Forms.Button buttonDel2;
        private System.Windows.Forms.Button buttonDel1;
        private System.Windows.Forms.Button buttonAdd2;
        private System.Windows.Forms.Button buttonAdd1;
        private System.Windows.Forms.ComboBox comboBoxMin3;
        private System.Windows.Forms.ComboBox comboBoxHour3;
        private System.Windows.Forms.ComboBox comboBoxMin2;
        private System.Windows.Forms.ComboBox comboBoxHour2;
        private System.Windows.Forms.ComboBox comboBoxMin1;
        private System.Windows.Forms.ComboBox comboBoxHour1;
        private System.Windows.Forms.GroupBox groupTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timerTime;
        private System.Windows.Forms.CheckBox checkBoxSave;
        private System.Windows.Forms.CheckBox checkBoxMail;
        private System.Windows.Forms.GroupBox groupMail;
        private System.Windows.Forms.Label labelMailTo;
        private System.Windows.Forms.TextBox textBoxMailTo;
        private System.Windows.Forms.Label labelMailServer;
        private System.Windows.Forms.TextBox textBoxMailServer;
        private System.Windows.Forms.Label labelMailPasswd;
        private System.Windows.Forms.TextBox textBoxMailPasswd;
        private System.Windows.Forms.Label labelMailUser;
        private System.Windows.Forms.TextBox textBoxMailUser;
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.Timer timerCheck;
        private System.Windows.Forms.Timer timerRetry;
    }
}

