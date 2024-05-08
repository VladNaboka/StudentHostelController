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

        public MainForm()
        {
            InitializeComponent();
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

                        if (session.user.AccessLevelString == "Администратор")
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
                currentOpenUser = new UserClass("", "", "", 0, 0, DateTime.Now, "", 0, false);
            }
            else
            {
                currentOpenUser = session.GetUser(login);
            }

            // заносим данные
            FullNameTB.Text = currentOpenUser.FullName;
            AccessLevelCB.SelectedIndex = currentOpenUser.AccessLevel;
            RoomNB.Value = currentOpenUser.Room;
            dateTimePicker2.Value = currentOpenUser.CreateDate;
            PasswordTB.Text = currentOpenUser.Password;
            LoginTB.Text = currentOpenUser.Login;
            textIIN.Text = currentOpenUser.IIN;

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
            if (session.user.AccessLevelString == "Администратор"
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
                case "Администратор":
                    {
                        FullNameTB.Enabled = true;
                        AccessLevelCB.Enabled = true;
                        RoomNB.Enabled = true;
                        dateTimePicker2.Enabled = true;
                        LoginPanel.Visible = true;
                        textIIN.Enabled = true;
                        // если создаем новый акк, то включаем редактирование логина
                        if (login == "")
                        {
                            LoginTB.Enabled = true;
                        }else
                        {
                            LoginTB.Enabled = false;
                        }
                    }
                    break;
                case "Модератор":
                    {
                        FullNameTB.Enabled = false;
                        AccessLevelCB.Enabled = false;
                        RoomNB.Enabled = true;
                        dateTimePicker2.Enabled = false;
                        LoginPanel.Visible = false;
                        textIIN.Enabled = false;
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
                    }
                    break;
                default:
                    // если сюда дошли, то что-то не так
                    throw new ArgumentOutOfRangeException();
            }


            buttonSaved.Enabled = false;
            tabControl1.SelectTab(1);
        }

        private void OpenEvent(string eventName)
        {
            if (eventName == "")
            {
                currentOpenEvent = new MeropriatiaClass("", "", DateTime.Now);
            }
            else
            {
                // Получение данных мероприятия из экземпляра FileManager
                currentOpenEvent = session.GetEvent(eventName);
            }

            // Отображение данных мероприятия в элементах управления
            nameEventsTB.Text = currentOpenEvent.NameEvent;
            DescriptionEvents.Text = currentOpenEvent.DescriptionEvent;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn &&
                e.RowIndex >= 0)
            {
                OpenAccount(senderGrid.Rows[e.RowIndex].Cells[senderGrid.Columns["Login"].Index].Value.ToString());
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
                    currentOpenEvent.DescriptionEvent = DescriptionEvents.Text;
                    currentOpenEvent.DateEvent = dateTimePicker1.Value;

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
                    }
                    catch (UserAlreadyExistException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!");
                    }
                }
                else
                {
                    // Если currentOpenEvent равен null, создаем новый экземпляр MeropriatiaClass
                    currentOpenEvent = new MeropriatiaClass("", "", DateTime.Now);
                    //OpenEvent(currentOpenEvent.NameEvent);
                    // Здесь можно добавить дополнительные действия с currentOpenEvent
                    bool newEvent = currentOpenEvent.NameEvent == "";

                    currentOpenEvent.NameEvent = nameEventsTB.Text;
                    currentOpenEvent.DescriptionEvent = DescriptionEvents.Text;
                    currentOpenEvent.DateEvent = dateTimePicker1.Value;

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

                }
                catch (UserAlreadyExistException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            
        }
        private void buttonRegistr_Click(object sender, EventArgs e)
        {
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
    }
}
