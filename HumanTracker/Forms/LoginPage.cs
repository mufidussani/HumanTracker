using System;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

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
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\CODE\HumanTracker Asli\HumanTracker\Database\HumanTrackerDatabase.mdf';Integrated Security=True");
                    SqlCommand cmd = new SqlCommand();

                    SqlDataAdapter da = new SqlDataAdapter("SELECT COUNT (*) FROM TabelLogin where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Login Sukses!");
                        this.Close();
                        Thread Th1 = new Thread((ThreadStart)delegate { Application.Run(new MainPage()); });
                        Th1.Start();
                    }
                    else
                    {
                        MessageBox.Show("Username dan Password salah!");
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!");
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
