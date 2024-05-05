using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                currentOpenUser = new UserClass("", "", "", 0, 0, DateTime.Now, "");
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
                    }
                    break;
                case "Студент":
                    {
                        FullNameTB.Enabled = false;
                        AccessLevelCB.Enabled = false;
                        RoomNB.Enabled = false;
                        dateTimePicker2.Enabled = false;
                        LoginPanel.Visible = false;
                    }
                    break;
                default:
                    // если сюда дошли, то что-то не так
                    throw new ArgumentOutOfRangeException();
            }


            buttonSaved.Enabled = false;
            tabControl1.SelectTab(1);
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

        private void button4_Click(object sender, EventArgs e)
        {
            bool newUser = currentOpenUser.Login == "";

            currentOpenUser.AccessLevel = Helper.AccessLevelTextToInt(AccessLevelCB.Text);
            currentOpenUser.FullName = FullNameTB.Text;
            currentOpenUser.Room = Decimal.ToInt32(RoomNB.Value);
            currentOpenUser.CreateDate = dateTimePicker2.Value;
            currentOpenUser.Login = LoginTB.Text;
            currentOpenUser.Password = PasswordTB.Text;

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
        private void buttonRegistr_Click(object sender, EventArgs e)
        {
            OpenAccount("");
        }
    }
}
