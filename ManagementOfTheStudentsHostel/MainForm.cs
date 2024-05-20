using FontAwesome.Sharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementOfTheStudentsHostel
{
    public partial class MainForm : Form
    {
        public FileManager session;
        public UserClass currentOpenUser;
        public MeropriatiaClass currentOpenEvent;
        public RoomsClass currentOpenRoom;
        public PersonalClass currentOpenPersonal;

        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        public MainForm()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 49);
            panelMenu.Controls.Add(leftBorderBtn);
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(95, 77, 221);
            public static Color color3 = Color.FromArgb(24, 161, 251);
            public static Color color4 = Color.FromArgb(249, 88, 155);
        }

        //Methods
        private void ActivatedButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Hide();
            LoginForm lf = new LoginForm();

            DialogResult r = lf.ShowDialog(this);
            switch (r)
            {
                case (DialogResult.Cancel):
                    {
                        Close();
                        break;
                    }
                case (DialogResult.OK):
                    {
                        session = lf.fm;
                        FullNameLabel.Text = session.user.FullName;
                        AccesLvlLabel.Text = session.user.AccessLevelString;
                        textIIN.Text = session.user.IIN;

                        if (session.user.AccessLevelString == "Комендант")
                        {
                            buttonRegistr.Visible = true;
                        }
                        else
                        {
                            buttonRegistr.Visible = false;
                        }

                        OpenAccount(session.user.Login);
                        Show();
                        break;
                    }
                default:
                    {
                        MessageBox.Show(r.ToString(), "Неизвестный результат работы программы");
                        break;
                    }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAccount(session.user.Login);
        }

        private void OpenAccount(string login)
        {
            if (login == "")
            {
                currentOpenUser = new UserClass("", "", "", 0, 0, DateTime.Now, "", 0, "", "", "", "", 0, false);
            }
            else
            {
                currentOpenUser = session.GetUser(login);
            }

            // заносим данные
            FullNameTB.Text = currentOpenUser.FullName;
            AccessLevelCB.SelectedIndex = currentOpenUser.AccessLevel;
            RoomNB.Value = currentOpenUser.Room;
            labelDataTimeNow.Text = currentOpenUser.CreateDate.ToLongDateString();
            PasswordTB.Text = currentOpenUser.Password;
            LoginTB.Text = currentOpenUser.Login;
            textIIN.Text = currentOpenUser.IIN;
            FacultyFB.Text = currentOpenUser.Faculty;
            SpecialityFB.Text = currentOpenUser.Speciality;
            GenderFB.Text = currentOpenUser.Gender;
            FormLearningFB.Text = currentOpenUser.FormLearning;
            CourseFB.Value = currentOpenUser.Course;

            // устанавливаем права

            // панель с логином видно только 
            if (login == "")
            {
                LoginPanel.Visible = true;
            }
            else
            {
                LoginPanel.Visible = false;
            }

            

            // если админ или это профиль текущего пользователя, то можно показать пароль
            if (session.user.AccessLevelString == "Комендант"
            || session.user.Login == currentOpenUser.Login)
            {
                PasswordPanel.Visible = true;
            }
            else
            {
                PasswordPanel.Visible = false;
            }

            // настройка панели с информацией
            switch (session.user.AccessLevelString)
            {
                case "Комендант":
                    {
                        FullNameTB.Enabled = true;
                        AccessLevelCB.Enabled = true;
                        RoomNB.Enabled = true;
                        dateTimePicker2.Enabled = true;
                        LoginPanel.Visible = true;
                        textIIN.Enabled = true;
                        FacultyFB.Enabled = true;
                        SpecialityFB.Enabled = true;
                        GenderFB.Enabled = true;
                        FormLearningFB.Enabled = true;
                        CourseFB.Enabled = true;
                        // если создаем новый акк, то включаем редактирование логина
                        if (login == "")
                        {
                            LoginTB.Enabled = true;

                            RoomNB.Visible = true;
                            FacultyFB.Visible = true;
                            SpecialityFB.Visible = true;
                            GenderFB.Visible = true;
                            FormLearningFB.Visible = true;
                            CourseFB.Visible = true;
                            label6.Visible = true;
                            label9.Visible = true;
                            label10.Visible = true;
                            label15.Visible = true;
                            label14.Visible = true;
                            label13.Visible = true;
                        }
                        else
                        {
                            LoginTB.Enabled = false;

                            RoomNB.Visible = false;
                            FacultyFB.Visible = false;
                            SpecialityFB.Visible = false;
                            GenderFB.Visible = false;
                            FormLearningFB.Visible = false;
                            CourseFB.Visible = false;
                            label6.Visible = false;
                            label9.Visible = false;
                            label10.Visible = false;
                            label15.Visible = false;
                            label14.Visible = false;
                            label13.Visible = false;
                        }
                    }
                    break;
                case "Воспитатель":
                    {
                        FullNameTB.Enabled = false;
                        AccessLevelCB.Enabled = false;
                        RoomNB.Enabled = true;
                        dateTimePicker2.Enabled = false;
                        LoginPanel.Visible = false;
                        textIIN.Enabled = false;
                        FacultyFB.Enabled = false;
                        SpecialityFB.Enabled = false;
                        GenderFB.Enabled = false;
                        FormLearningFB.Enabled = false;
                        CourseFB.Enabled = false;
                    }
                    break;
                case "Студент":
                    {
                        FullNameTB.Enabled = false;
                        AccessLevelCB.Enabled = false;
                        RoomNB.Enabled = false;
                        dateTimePicker2.Enabled = false;
                        LoginPanel.Visible = false;
                        textIIN.Enabled = false;
                        FacultyFB.Enabled = false;
                        SpecialityFB.Enabled = false;
                        GenderFB.Enabled = false;
                        FormLearningFB.Enabled = false;
                        CourseFB.Enabled = false;
                    }
                    break;
                default:
                    // если сюда дошли, то что-то не так
                    throw new ArgumentOutOfRangeException();
            }


            buttonSaved.Enabled = false;
            tabControl1.SelectTab(1);

            buttonSaved.Visible = true;
            CreateEventsButton.Visible = false;
            buttonRegistr.Visible = false;
            addPersonalButton.Visible = false;
            addRoomButton.Visible = false;
        }

        private void OpenEvent(string eventName)
        {
            if (eventName == "")
            {
                currentOpenEvent = new MeropriatiaClass("", "", DateTime.Now, "", "");
            }
            else
            {
                // Получение данных мероприятия из экземпляра FileManager
                currentOpenEvent = session.GetEvent(eventName);
            }

            // Отображение данных мероприятия в элементах управления
            nameEventsTB.Text = currentOpenEvent.NameEvent;
            DescriptionEvents.Text = currentOpenEvent.PlaceEvent;
            dateTimePicker1.Value = currentOpenEvent.DateEvent;


            //if (session.events.Find(e => e.NameEvent == eventName) == currentOpenEvent)
            //{
            //    buttonSaved.Enabled = false;
            //    tabControl1.SelectTab(3);
            //}

            // Установка доступности элементов управления в зависимости от уровня доступа
            // Здесь можно добавить дополнительные условия, если необходимо
            buttonSaved.Enabled = false; // Отключаем кнопку сохранения изменений по умолчанию

            RefreshMeropriatiaList();
            // Переключение на вкладку с мероприятиями
            tabControl1.SelectTab(3);
        }
        private void OpenRoom(int roomNumber)
        {
            if (roomNumber == 0)
            {
                currentOpenRoom = new RoomsClass(0, 0, 0, 0, 0, 0, 0, false, "", false);
            }
            else
            {
                currentOpenRoom = session.GetRoom(roomNumber);
            }

            // Отображение данных мероприятия в элементах управления
            NumberRoomFB.Value = currentOpenRoom.NumberRoom;
            FloorRoomFB.Value = currentOpenRoom.FloorRoom;
            SquareRoomFB.Value = currentOpenRoom.SquareRoom;
            CountBadroomFB.Value = currentOpenRoom.CountBadroom;
            CountWardrobeFB.Value = currentOpenRoom.CountWardrobe;
            TableRoomFB.Value = currentOpenRoom.TableRoom;
            ChairsRoomFB.Value = currentOpenRoom.ChairsRoom;
            StoveRoomFB.Checked = currentOpenRoom.StoveRoom;
            ElectricRoomFB.Text = currentOpenRoom.ElectricRoom;
            WiFiRoomFB.Checked = currentOpenRoom.WiFiRoom;

            //if (session.events.Find(e => e.NameEvent == eventName) == currentOpenEvent)
            //{
            //    buttonSaved.Enabled = false;
            //    tabControl1.SelectTab(3);
            //}

            // Установка доступности элементов управления в зависимости от уровня доступа
            // Здесь можно добавить дополнительные условия, если необходимо
            buttonSaved.Enabled = false; // Отключаем кнопку сохранения изменений по умолчанию

            RefreshRoomsList();
            // Переключение на вкладку с мероприятиями
            tabControl1.SelectTab(6);
        }

        private void OpenPersonal(string namePersonal)
        {
            if (namePersonal == "")
            {
                currentOpenPersonal = new PersonalClass("", "", "", "");
            }
            else
            {
                currentOpenPersonal = session.GetPersonal(namePersonal);
            }

            NamePersonalFB.Text = currentOpenPersonal.NamePersonal;
            PostPersonalFB.Text = currentOpenPersonal.PostPersonal;
            AdressPersonalFB.Text = currentOpenPersonal.AdressPersonal;
            PhonePersonalFB.Text = currentOpenPersonal.PhonePersonal;

            buttonSaved.Enabled = false; // Отключаем кнопку сохранения изменений по умолчанию

            RefreshPersonalList();
            tabControl1.SelectTab(7);
        }

        private void SaveChangesBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool newUser = currentOpenUser.Login == "";

            currentOpenUser.AccessLevel = Helper.AccessLevelTextToInt(AccessLevelCB.Text);
            currentOpenUser.FullName = FullNameTB.Text;
            currentOpenUser.Room = Decimal.ToInt32(RoomNB.Value);
            currentOpenUser.CreateDate = dateTimePicker2.Value;
            currentOpenUser.Login = LoginTB.Text;
            currentOpenUser.Password = PasswordTB.Text;
            currentOpenUser.IIN = textIIN.Text;
            currentOpenUser.Faculty = FacultyFB.Text;
            currentOpenUser.Speciality = SpecialityFB.Text;
            currentOpenUser.Gender = GenderFB.Text;
            currentOpenUser.FormLearning = FormLearningFB.Text;
            currentOpenUser.Course = Decimal.ToInt32(CourseFB.Value);

            try
            {
                if (newUser)
                {
                    session.CreateUser(currentOpenUser);
                    OpenAccount(currentOpenUser.IIN);
                }
                else
                {
                    session.ChangeUser(currentOpenUser);
                }

                buttonSaved.Enabled = false;

            }
            catch (UserAlreadyExistException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }

        private void Account_EditChanget(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshUsersList();

            tabControl1.SelectTab(0);
        }

        private void RefreshUsersList()
        {
            var source = new BindingSource();

            List<UserClass> list = session.GetAllUsers();
            source.DataSource = list;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = source;
        }
        private void RefreshMeropriatiaList()
        {
            var source = new BindingSource();

            List<MeropriatiaClass> list = session.GetAllEvents();
            source.DataSource = list;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = source;
        }
        private void RefreshRoomsList()
        {
            var source = new BindingSource();

            List<RoomsClass> list = session.GetAllRooms();
            source.DataSource = list;
            dataGridView4.AutoGenerateColumns = false;
            dataGridView4.DataSource = source;
        }
        private void RefreshPersonalList()
        {
            var source = new BindingSource();

            List<PersonalClass> list = session.GetAllPersonal();
            source.DataSource = list;
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.DataSource = source;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn &&
                e.RowIndex >= 0)
            {
                OpenAccount(senderGrid.Rows[e.RowIndex].Cells[senderGrid.Columns["Login"].Index].Value.ToString());
                RoomNB.Visible = true;
                FacultyFB.Visible = true;
                SpecialityFB.Visible = true;
                GenderFB.Visible = true;
                FormLearningFB.Visible = true;
                CourseFB.Visible = true;
                label6.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label15.Visible = true;
                label14.Visible = true;
                label13.Visible = true;
            }
        }

        private void ShowPassord_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTB.UseSystemPasswordChar = ShowPassord.Checked;
        }

        private void RegistrationBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAccount("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenAccount(session.user.Login);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshUsersList();

            tabControl1.SelectTab(0);
        }

        private string GenerateRandomLogin()
        {
            Random random = new Random();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(characters, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GenerateRandomPassword()
        {
            Random random = new Random();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            return new string(Enumerable.Repeat(characters, 12)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void ButtonSaved_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
            {
                //MessageBox.Show("Добавление нового мероприятия!");
                // Проверяем, что currentOpenEvent не равен null
                if (currentOpenEvent != null)
                {
                    bool newEvent = currentOpenEvent.NameEvent == "";

                    currentOpenEvent.NameEvent = nameEventsTB.Text;
                    currentOpenEvent.PlaceEvent = DescriptionEvents.Text;
                    currentOpenEvent.DateEvent = dateTimePicker1.Value;
                    currentOpenEvent.ExecutorEvent = ExecutorEventFB.Text;

                    try
                    {
                        if (newEvent)
                        {
                            session.AddEvent(currentOpenEvent);
                            OpenEvent(currentOpenEvent.NameEvent);
                        }
                        else
                        {
                            session.UpdateEvent(currentOpenEvent);
                        }

                        buttonSaved.Enabled = false;

                        tabControl1.SelectTab(2);
                    }
                    catch (UserAlreadyExistException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!");
                    }
                }
                else
                {
                    // Если currentOpenEvent равен null, создаем новый экземпляр MeropriatiaClass
                    currentOpenEvent = new MeropriatiaClass("", "", DateTime.Now, "", "");
                    //OpenEvent(currentOpenEvent.NameEvent);
                    // Здесь можно добавить дополнительные действия с currentOpenEvent
                    bool newEvent = currentOpenEvent.NameEvent == "";

                    currentOpenEvent.NameEvent = nameEventsTB.Text;
                    currentOpenEvent.PlaceEvent = DescriptionEvents.Text;
                    currentOpenEvent.DateEvent = dateTimePicker1.Value;
                    currentOpenEvent.ExecutorEvent = ExecutorEventFB.Text;

                    try
                    {
                        
                        if (newEvent)
                        {
                            session.AddEvent(currentOpenEvent);
                            OpenEvent(currentOpenEvent.NameEvent);
                        }
                        else
                        {
                            session.UpdateEvent(currentOpenEvent);
                        }

                        buttonSaved.Enabled = false;
                        tabControl1.SelectTab(2);
                    }
                    catch (UserAlreadyExistException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!");
                    }

                    buttonSaved.Enabled = false;
                }

            }

            if (tabControl1.SelectedIndex == 1)
            {
                bool isGuest = string.IsNullOrEmpty(LoginTB.Text) && string.IsNullOrEmpty(PasswordTB.Text);

                bool newUser = currentOpenUser.Login == "";

                currentOpenUser.AccessLevel = Helper.AccessLevelTextToInt(AccessLevelCB.Text);
                currentOpenUser.FullName = FullNameTB.Text;
                currentOpenUser.Room = Decimal.ToInt32(RoomNB.Value);
                currentOpenUser.CreateDate = dateTimePicker2.Value;
                currentOpenUser.IIN = textIIN.Text;
                currentOpenUser.IsGuest = isGuest;
                currentOpenUser.Faculty = FacultyFB.Text;
                currentOpenUser.Speciality = SpecialityFB.Text;
                currentOpenUser.Gender = GenderFB.Text;
                currentOpenUser.FormLearning = FormLearningFB.Text;
                currentOpenUser.Course = Decimal.ToInt32(CourseFB.Value);

                if (isGuest)
                {
                    string generatedLogin = GenerateRandomLogin();
                    string generatedPassword = GenerateRandomPassword();

                    // Проверяем уникальность логина
                    while (session.IsLoginExists(generatedLogin))
                    {
                        generatedLogin = GenerateRandomLogin();
                    }

                    // Устанавливаем сгенерированный логин и пароль
                    LoginTB.Text = generatedLogin;
                    PasswordTB.Text = generatedPassword;
                    currentOpenUser.Login = LoginTB.Text;
                    currentOpenUser.Password = PasswordTB.Text;
                }

                try
                {
                    if (newUser)
                    {
                        session.CreateUser(currentOpenUser);
                        OpenAccount(currentOpenUser.Login);
                    }
                    else
                    {
                        session.ChangeUser(currentOpenUser);
                    }

                    buttonSaved.Enabled = false;
                    buttonRegistr.Visible = true;
                    RefreshUsersList();
                    tabControl1.SelectTab(0);
                }
                catch (UserAlreadyExistException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }

            if (tabControl1.SelectedIndex == 6)
            {
                if (currentOpenRoom != null)
                {
                    bool newRoom = currentOpenRoom.NumberRoom == 0;

                    currentOpenRoom.NumberRoom = Decimal.ToInt32(NumberRoomFB.Value);
                    currentOpenRoom.FloorRoom = Decimal.ToInt32(FloorRoomFB.Value);
                    currentOpenRoom.SquareRoom = Decimal.ToInt32(SquareRoomFB.Value);
                    currentOpenRoom.CountBadroom = Decimal.ToInt32(CountBadroomFB.Value);
                    currentOpenRoom.CountWardrobe = Decimal.ToInt32(CountWardrobeFB.Value);
                    currentOpenRoom.TableRoom = Decimal.ToInt32(TableRoomFB.Value);
                    currentOpenRoom.ChairsRoom = Decimal.ToInt32(ChairsRoomFB.Value);
                    currentOpenRoom.StoveRoom = StoveRoomFB.Checked;
                    currentOpenRoom.ElectricRoom = ElectricRoomFB.Text;
                    currentOpenRoom.WiFiRoom = WiFiRoomFB.Checked;

                    try
                    {
                        if (newRoom)
                        {
                            session.AddRoom(currentOpenRoom);
                            OpenRoom(currentOpenRoom.NumberRoom);
                        }
                        else
                        {
                            session.UpdateRoom(currentOpenRoom);
                        }

                        buttonSaved.Enabled = false;
                        tabControl1.SelectTab(5);
                    }
                    catch (UserAlreadyExistException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!");
                    }
                }
                else
                {
                    currentOpenRoom = new RoomsClass(0, 0, 0, 0, 0, 0, 0, false, "", false);
                    bool newRoom = currentOpenRoom.NumberRoom == 0;

                    currentOpenRoom.NumberRoom = Decimal.ToInt32(NumberRoomFB.Value);
                    currentOpenRoom.FloorRoom = Decimal.ToInt32(FloorRoomFB.Value);
                    currentOpenRoom.SquareRoom = Decimal.ToInt32(SquareRoomFB.Value);
                    currentOpenRoom.CountBadroom = Decimal.ToInt32(CountBadroomFB.Value);
                    currentOpenRoom.CountWardrobe = Decimal.ToInt32(CountWardrobeFB.Value);
                    currentOpenRoom.TableRoom = Decimal.ToInt32(TableRoomFB.Value);
                    currentOpenRoom.ChairsRoom = Decimal.ToInt32(ChairsRoomFB.Value);
                    currentOpenRoom.StoveRoom = StoveRoomFB.Checked;
                    currentOpenRoom.ElectricRoom = ElectricRoomFB.Text;
                    currentOpenRoom.WiFiRoom = WiFiRoomFB.Checked;

                    try
                    {
                        if (newRoom)
                        {
                            session.AddRoom(currentOpenRoom);
                            OpenRoom(currentOpenRoom.NumberRoom);
                        }
                        else
                        {
                            session.UpdateRoom(currentOpenRoom);
                        }

                        buttonSaved.Enabled = false;
                        tabControl1.SelectTab(5);
                    }
                    catch (UserAlreadyExistException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!");
                    }

                    buttonSaved.Enabled = false;
                }
            }

            if (tabControl1.SelectedIndex == 7)
            {
                if (currentOpenPersonal != null)
                {
                    bool newPersonal = currentOpenPersonal.NamePersonal == "";

                    currentOpenPersonal.NamePersonal = NamePersonalFB.Text;
                    currentOpenPersonal.PostPersonal = PostPersonalFB.Text;
                    currentOpenPersonal.AdressPersonal = AdressPersonalFB.Text;
                    currentOpenPersonal.PhonePersonal = PhonePersonalFB.Text;

                    try
                    {
                        if (newPersonal)
                        {
                            session.AddPersonal(currentOpenPersonal);
                            OpenPersonal(currentOpenPersonal.NamePersonal);
                        }
                        else
                        {
                            session.UpdatePersonal(currentOpenPersonal);
                        }

                        buttonSaved.Enabled = false;
                        tabControl1.SelectTab(4);
                    }
                    catch (UserAlreadyExistException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!");
                    }
                }
                else
                {
                    // Если currentOpenEvent равен null, создаем новый экземпляр MeropriatiaClass
                    currentOpenPersonal = new PersonalClass("", "", "", "");

                    bool newPersonal = currentOpenPersonal.NamePersonal == "";

                    currentOpenPersonal.NamePersonal = NamePersonalFB.Text;
                    currentOpenPersonal.PostPersonal = PostPersonalFB.Text;
                    currentOpenPersonal.AdressPersonal = AdressPersonalFB.Text;
                    currentOpenPersonal.PhonePersonal = PhonePersonalFB.Text;

                    try
                    {
                        if (newPersonal)
                        {
                            session.AddPersonal(currentOpenPersonal);
                            OpenPersonal(currentOpenPersonal.NamePersonal);
                        }
                        else
                        {
                            session.UpdatePersonal(currentOpenPersonal);
                        }

                        buttonSaved.Enabled = false;
                        tabControl1.SelectTab(4);
                    }
                    catch (UserAlreadyExistException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!");
                    }

                    buttonSaved.Enabled = false;
                }
            }
        }
        private void buttonRegistr_Click(object sender, EventArgs e)
        {
            labelDataTimeNow.Text = DateTime.Now.ToLongDateString();
            OpenAccount("");
        }

        private void textIIN_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void AccessLevelCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn &&
                e.RowIndex >= 0)
            {
                string eventName = senderGrid.Rows[e.RowIndex].Cells[senderGrid.Columns["NameEvent"].Index].Value.ToString();
                OpenEvent(eventName);
            }
        }

        private void MeropriatiaButton_Click_1(object sender, EventArgs e)
        {
            RefreshMeropriatiaList();

            tabControl1.SelectTab(2);
        }

        private void CreateEventsButton_Click_1(object sender, EventArgs e)
        {
            labelDateEventFB.Text = DateTime.Now.ToLongDateString();
            OpenEvent("");
            buttonSaved.Enabled = false;
            tabControl1.SelectTab(3);
        }

        private void DescriptionEvents_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void nameEventsTB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivatedButton(sender, RGBColors.color1);
            RefreshUsersList();

            tabControl1.SelectTab(0);

            buttonSaved.Visible = true;
            CreateEventsButton.Visible = false;
            buttonRegistr.Visible = true;
            addPersonalButton.Visible = false;
            addRoomButton.Visible = false;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivatedButton(sender, RGBColors.color2);
            RefreshMeropriatiaList();

            tabControl1.SelectTab(2);

            buttonSaved.Visible = true;
            CreateEventsButton.Visible = true;
            buttonRegistr.Visible = false;
            addPersonalButton.Visible = false;
            addRoomButton.Visible = false;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivatedButton(sender, RGBColors.color3);
            RefreshRoomsList();

            tabControl1.SelectTab(5);

            buttonSaved.Visible = true;
            CreateEventsButton.Visible = false;
            buttonRegistr.Visible = false;
            addPersonalButton.Visible = false;
            addRoomButton.Visible = true;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivatedButton(sender, RGBColors.color4);
            RefreshPersonalList();

            tabControl1.SelectTab(4);

            buttonSaved.Visible = true;
            CreateEventsButton.Visible = false;
            buttonRegistr.Visible = false;
            addPersonalButton.Visible = true;
            addRoomButton.Visible = false;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            OpenAccount(session.user.Login);
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn &&
                e.RowIndex >= 0)
            {
                int roomNum = (int)senderGrid.Rows[e.RowIndex].Cells[senderGrid.Columns["NumberRoom"].Index].Value;
                OpenRoom(roomNum);
            }
        }

        private void FacultyFB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void SpecialityFB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void CourseFB_ValueChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void FormLearningFB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void GenderFB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void addPersonalButton_Click(object sender, EventArgs e)
        {
            OpenPersonal("");
        }

        private void addRoomButton_Click(object sender, EventArgs e)
        {
            OpenRoom(0);
        }

        private void NumberRoomFB_ValueChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void FloorRoomFB_ValueChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void CountBadroomFB_ValueChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void SquareRoomFB_ValueChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void CountWardrobeFB_ValueChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void ElectricRoomFB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void TableRoomFB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void ChairsRoomFB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void StoveRoomFB_CheckedChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void WiFiRoomFB_CheckedChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void ExecutorEventFB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn &&
                e.RowIndex >= 0)
            {
                string personalName = senderGrid.Rows[e.RowIndex].Cells[senderGrid.Columns["NamePersonal"].Index].Value.ToString();
                OpenPersonal(personalName);
            }
        }

        private void NamePersonalFB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void PostPersonalFB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void AdressPersonalFB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }

        private void PhonePersonalFB_TextChanged(object sender, EventArgs e)
        {
            buttonSaved.Enabled = true;
        }
    }
}
