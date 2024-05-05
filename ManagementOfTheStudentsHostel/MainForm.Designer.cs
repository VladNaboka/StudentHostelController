namespace ManagementOfTheStudentsHostel
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Students = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FullName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.AccessLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentsDetail = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.LoginTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PasswordPanel = new System.Windows.Forms.Panel();
            this.ShowPassord = new System.Windows.Forms.CheckBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CreateAccountDateLbl = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.AccessLevelCB = new System.Windows.Forms.ComboBox();
            this.RoomNB = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FullNameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AccesLvlLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FullNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsersListBS = new System.Windows.Forms.BindingSource(this.components);
            this.buttonProfile = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.buttonRegistr = new System.Windows.Forms.Button();
            this.buttonSaved = new System.Windows.Forms.Button();
            this.userClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.Students.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.StudentsDetail.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.LoginPanel.SuspendLayout();
            this.PasswordPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomNB)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersListBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Students);
            this.tabControl1.Controls.Add(this.StudentsDetail);
            this.tabControl1.Location = new System.Drawing.Point(0, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(977, 504);
            this.tabControl1.TabIndex = 0;
            // 
            // Students
            // 
            this.Students.Controls.Add(this.dataGridView1);
            this.Students.Location = new System.Drawing.Point(4, 25);
            this.Students.Margin = new System.Windows.Forms.Padding(4);
            this.Students.Name = "Students";
            this.Students.Padding = new System.Windows.Forms.Padding(4);
            this.Students.Size = new System.Drawing.Size(969, 475);
            this.Students.TabIndex = 0;
            this.Students.Text = "Студенты";
            this.Students.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullName,
            this.AccessLevel,
            this.Room,
            this.CreateDate,
            this.Login,
            this.Notes});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(961, 467);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "ФИО";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AccessLevel
            // 
            this.AccessLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AccessLevel.DataPropertyName = "AccessLevelString";
            this.AccessLevel.HeaderText = "Статус";
            this.AccessLevel.MinimumWidth = 6;
            this.AccessLevel.Name = "AccessLevel";
            this.AccessLevel.ReadOnly = true;
            this.AccessLevel.Width = 82;
            // 
            // Room
            // 
            this.Room.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Room.DataPropertyName = "Room";
            this.Room.HeaderText = "Комната";
            this.Room.MinimumWidth = 6;
            this.Room.Name = "Room";
            this.Room.ReadOnly = true;
            this.Room.Width = 94;
            // 
            // CreateDate
            // 
            this.CreateDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Дата регистрации";
            this.CreateDate.MinimumWidth = 6;
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 145;
            // 
            // Login
            // 
            this.Login.DataPropertyName = "Login";
            this.Login.HeaderText = "Login";
            this.Login.MinimumWidth = 6;
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            this.Login.Visible = false;
            this.Login.Width = 125;
            // 
            // Notes
            // 
            this.Notes.DataPropertyName = "Notes";
            this.Notes.HeaderText = "Notes";
            this.Notes.MinimumWidth = 6;
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
            this.Notes.Visible = false;
            this.Notes.Width = 125;
            // 
            // StudentsDetail
            // 
            this.StudentsDetail.AutoScroll = true;
            this.StudentsDetail.Controls.Add(this.tableLayoutPanel2);
            this.StudentsDetail.Location = new System.Drawing.Point(4, 25);
            this.StudentsDetail.Margin = new System.Windows.Forms.Padding(4);
            this.StudentsDetail.Name = "StudentsDetail";
            this.StudentsDetail.Padding = new System.Windows.Forms.Padding(4);
            this.StudentsDetail.Size = new System.Drawing.Size(969, 475);
            this.StudentsDetail.TabIndex = 1;
            this.StudentsDetail.Text = "Аккаунт";
            this.StudentsDetail.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.LoginPanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.PasswordPanel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(31, 9);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(905, 439);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // LoginPanel
            // 
            this.LoginPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginPanel.AutoSize = true;
            this.LoginPanel.Controls.Add(this.LoginTB);
            this.LoginPanel.Controls.Add(this.label7);
            this.LoginPanel.Location = new System.Drawing.Point(4, 4);
            this.LoginPanel.Margin = new System.Windows.Forms.Padding(4);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(897, 77);
            this.LoginPanel.TabIndex = 18;
            this.LoginPanel.Visible = false;
            // 
            // LoginTB
            // 
            this.LoginTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginTB.Location = new System.Drawing.Point(107, 20);
            this.LoginTB.Margin = new System.Windows.Forms.Padding(4, 25, 27, 4);
            this.LoginTB.Name = "LoginTB";
            this.LoginTB.Size = new System.Drawing.Size(339, 34);
            this.LoginTB.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(-1, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 29);
            this.label7.TabIndex = 19;
            this.label7.Text = "Логин:";
            // 
            // PasswordPanel
            // 
            this.PasswordPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordPanel.AutoSize = true;
            this.PasswordPanel.Controls.Add(this.ShowPassord);
            this.PasswordPanel.Controls.Add(this.PasswordTB);
            this.PasswordPanel.Controls.Add(this.label8);
            this.PasswordPanel.Location = new System.Drawing.Point(4, 89);
            this.PasswordPanel.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordPanel.Name = "PasswordPanel";
            this.PasswordPanel.Size = new System.Drawing.Size(897, 81);
            this.PasswordPanel.TabIndex = 17;
            this.PasswordPanel.Visible = false;
            // 
            // ShowPassord
            // 
            this.ShowPassord.AutoSize = true;
            this.ShowPassord.Checked = true;
            this.ShowPassord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowPassord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowPassord.Location = new System.Drawing.Point(477, 23);
            this.ShowPassord.Margin = new System.Windows.Forms.Padding(4);
            this.ShowPassord.Name = "ShowPassord";
            this.ShowPassord.Size = new System.Drawing.Size(146, 33);
            this.ShowPassord.TabIndex = 41;
            this.ShowPassord.Text = "Скрывать";
            this.ShowPassord.UseVisualStyleBackColor = true;
            this.ShowPassord.CheckedChanged += new System.EventHandler(this.ShowPassord_CheckedChanged);
            // 
            // PasswordTB
            // 
            this.PasswordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTB.Location = new System.Drawing.Point(107, 22);
            this.PasswordTB.Margin = new System.Windows.Forms.Padding(4, 25, 27, 4);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(339, 34);
            this.PasswordTB.TabIndex = 20;
            this.PasswordTB.UseSystemPasswordChar = true;
            this.PasswordTB.TextChanged += new System.EventHandler(this.Account_EditChanget);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(-5, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 29);
            this.label8.TabIndex = 19;
            this.label8.Text = "Пароль:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CreateAccountDateLbl);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.AccessLevelCB);
            this.panel1.Controls.Add(this.RoomNB);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.FullNameTB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 178);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 257);
            this.panel1.TabIndex = 15;
            // 
            // CreateAccountDateLbl
            // 
            this.CreateAccountDateLbl.AutoSize = true;
            this.CreateAccountDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateAccountDateLbl.Location = new System.Drawing.Point(67, 188);
            this.CreateAccountDateLbl.Margin = new System.Windows.Forms.Padding(27, 25, 4, 25);
            this.CreateAccountDateLbl.Name = "CreateAccountDateLbl";
            this.CreateAccountDateLbl.Size = new System.Drawing.Size(229, 29);
            this.CreateAccountDateLbl.TabIndex = 22;
            this.CreateAccountDateLbl.Text = "Дата регистрации:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Location = new System.Drawing.Point(314, 188);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(452, 34);
            this.dateTimePicker2.TabIndex = 21;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.Account_EditChanget);
            // 
            // AccessLevelCB
            // 
            this.AccessLevelCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccessLevelCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AccessLevelCB.Items.AddRange(new object[] {
            "Студент",
            "Модератор",
            "Администратор"});
            this.AccessLevelCB.Location = new System.Drawing.Point(455, 82);
            this.AccessLevelCB.Margin = new System.Windows.Forms.Padding(4);
            this.AccessLevelCB.Name = "AccessLevelCB";
            this.AccessLevelCB.Size = new System.Drawing.Size(441, 37);
            this.AccessLevelCB.TabIndex = 20;
            this.AccessLevelCB.SelectedValueChanged += new System.EventHandler(this.Account_EditChanget);
            // 
            // RoomNB
            // 
            this.RoomNB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RoomNB.Location = new System.Drawing.Point(211, 84);
            this.RoomNB.Margin = new System.Windows.Forms.Padding(4);
            this.RoomNB.Maximum = new decimal(new int[] {
            1299,
            0,
            0,
            0});
            this.RoomNB.Name = "RoomNB";
            this.RoomNB.Size = new System.Drawing.Size(103, 34);
            this.RoomNB.TabIndex = 19;
            this.RoomNB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RoomNB.ValueChanged += new System.EventHandler(this.Account_EditChanget);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(-5, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(27, 25, 4, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 29);
            this.label6.TabIndex = 18;
            this.label6.Text = "Номер комнаты:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(344, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(27, 25, 4, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 29);
            this.label5.TabIndex = 17;
            this.label5.Text = "Статус:";
            // 
            // FullNameTB
            // 
            this.FullNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullNameTB.Location = new System.Drawing.Point(107, 21);
            this.FullNameTB.Margin = new System.Windows.Forms.Padding(4, 25, 27, 4);
            this.FullNameTB.Name = "FullNameTB";
            this.FullNameTB.Size = new System.Drawing.Size(789, 34);
            this.FullNameTB.TabIndex = 16;
            this.FullNameTB.Text = "Игорь михайловский\r\n";
            this.FullNameTB.TextChanged += new System.EventHandler(this.Account_EditChanget);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-3, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "ФИО:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.AccesLvlLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.FullNameLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(976, 43);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // AccesLvlLabel
            // 
            this.AccesLvlLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AccesLvlLabel.AutoSize = true;
            this.AccesLvlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AccesLvlLabel.Location = new System.Drawing.Point(278, 9);
            this.AccesLvlLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AccesLvlLabel.Name = "AccesLvlLabel";
            this.AccesLvlLabel.Size = new System.Drawing.Size(78, 25);
            this.AccesLvlLabel.TabIndex = 4;
            this.AccesLvlLabel.Text = "Статус";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(146, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ваш статус:";
            // 
            // FullNameLabel
            // 
            this.FullNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FullNameLabel.AutoSize = true;
            this.FullNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullNameLabel.Location = new System.Drawing.Point(78, 9);
            this.FullNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FullNameLabel.Name = "FullNameLabel";
            this.FullNameLabel.Size = new System.Drawing.Size(60, 25);
            this.FullNameLabel.TabIndex = 3;
            this.FullNameLabel.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "ФИО:";
            // 
            // buttonProfile
            // 
            this.buttonProfile.Location = new System.Drawing.Point(210, 524);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new System.Drawing.Size(163, 36);
            this.buttonProfile.TabIndex = 13;
            this.buttonProfile.Text = "Профиль";
            this.buttonProfile.UseVisualStyleBackColor = true;
            this.buttonProfile.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonUsers
            // 
            this.buttonUsers.Location = new System.Drawing.Point(12, 524);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(163, 36);
            this.buttonUsers.TabIndex = 14;
            this.buttonUsers.Text = "Все пользователи";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonRegistr
            // 
            this.buttonRegistr.Location = new System.Drawing.Point(12, 576);
            this.buttonRegistr.Name = "buttonRegistr";
            this.buttonRegistr.Size = new System.Drawing.Size(361, 32);
            this.buttonRegistr.TabIndex = 15;
            this.buttonRegistr.Text = "Зарегистрировать нового пользователя";
            this.buttonRegistr.UseVisualStyleBackColor = true;
            this.buttonRegistr.Click += new System.EventHandler(this.buttonRegistr_Click);
            // 
            // buttonSaved
            // 
            this.buttonSaved.Location = new System.Drawing.Point(801, 523);
            this.buttonSaved.Name = "buttonSaved";
            this.buttonSaved.Size = new System.Drawing.Size(163, 36);
            this.buttonSaved.TabIndex = 15;
            this.buttonSaved.Text = "Сохранить";
            this.buttonSaved.UseVisualStyleBackColor = true;
            this.buttonSaved.Click += new System.EventHandler(this.button4_Click);
            // 
            // userClassBindingSource
            // 
            this.userClassBindingSource.DataSource = typeof(ManagementOfTheStudentsHostel.UserClass);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(976, 623);
            this.Controls.Add(this.buttonSaved);
            this.Controls.Add(this.buttonUsers);
            this.Controls.Add(this.buttonProfile);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonRegistr);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Учет и регистрация студентов в общежитии";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.Students.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.StudentsDetail.ResumeLayout(false);
            this.StudentsDetail.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.PasswordPanel.ResumeLayout(false);
            this.PasswordPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomNB)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersListBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userClassBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Students;
        private System.Windows.Forms.TabPage StudentsDetail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label AccesLvlLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label FullNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource userClassBindingSource;
        private System.Windows.Forms.BindingSource UsersListBS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel PasswordPanel;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CreateAccountDateLbl;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox AccessLevelCB;
        private System.Windows.Forms.NumericUpDown RoomNB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FullNameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ShowPassord;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.TextBox LoginTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewLinkColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccessLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.Button buttonUsers;
        private System.Windows.Forms.Button buttonRegistr;
        private System.Windows.Forms.Button buttonSaved;
    }
}