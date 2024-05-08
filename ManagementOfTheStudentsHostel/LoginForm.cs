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

namespace ManagementOfTheStudentsHostel
{
    public partial class LoginForm : Form
    {
        public FileManager fm = new FileManager();
        public LoginForm()
        {
            InitializeComponent();

        }

        private void Login_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (loginTxt.Text == "admin" || loginTxt.Text == "moderator") 
                {
                    fm.Login(loginTxt.Text, passwordTxt.Text);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
            catch (LoginException ex)
            {
                MessageBox.Show(ex.Message,"Ошибка!");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            passwordTxt.UseSystemPasswordChar = ShowPassord.Checked;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm(fm.GetTextInstr());
            infoForm.ShowDialog();
        }

        private void loginTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
