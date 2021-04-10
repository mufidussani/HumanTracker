using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace HumanTracker
{
    public partial class LoginPage : Form, ILoginPageViewModel
    {
        string ILoginPageViewModel.txtUsername { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ILoginPageViewModel.txtPassword { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public LoginPage()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "mufidussani" && txtPassword.Text != "123456")
            {
                MessageBox.Show("Username dan password salah. Silakan ulangi kembali");
            }
            else
            {
                MessageBox.Show("Login berhasil.");
                this.Close();
                Thread Th1 = new Thread((ThreadStart)delegate { Application.Run(new MainPage()); });
                Th1.Start();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                var checkBox = (CheckBox)sender;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                var checkBox = (CheckBox)sender;
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
