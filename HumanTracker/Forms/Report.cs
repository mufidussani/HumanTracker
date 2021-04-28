using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace HumanTracker
{
    public partial class Report : Form
    {
        List<Pengunjung> exitPengunjung = new List<Pengunjung>();
        public Report()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTotalWaktu_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalPengunjung_Click(object sender, EventArgs e)
        {

        }

        private void Report_Load(object sender, EventArgs e)
        {
            Report f = new Report();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\CODE\HumanTracker Asli\HumanTracker\Database\HumanTrackerDatabase.mdf';Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PengunjungKeluar");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem li = new ListViewItem();
                li.Text = dr["Nama_Pengunjung"].ToString();
                li.SubItems.Add(dr["Tipe"].ToString());
                li.SubItems.Add(dr["Waktu"].ToString());
                listView1.Items.Add(li);
            }
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var b = listView1.FocusedItem.Text;

            string query = "delete from PengunjungKeluar where Nama_Pengunjung=@names;";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\CODE\HumanTracker Asli\HumanTracker\Database\HumanTrackerDatabase.mdf';Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    using (SqlTransaction trans = con.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con, trans))
                        {
                            cmd.Parameters.AddWithValue("@names", b);
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            listView1.Clear();
        }

        private void Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            listView1.Clear();
        }
    }
}
