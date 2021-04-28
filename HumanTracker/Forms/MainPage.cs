using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HumanTracker
{
    public partial class MainPage : Form
    {
        private object listbox_Pengunjung;
        private object listbox_TipePengunjung;
        string listname;
        List<Pengunjung> exitPengunjung = new List<Pengunjung>();
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            listBox_TipePengunjung.Items.Add(new TipePengunjung { Nama = "Pemilik" });
            listBox_TipePengunjung.Items.Add(new TipePengunjung { Nama = "Petinggi" });
            listBox_TipePengunjung.Items.Add(new TipePengunjung { Nama = "Karyawan" });
            listBox_TipePengunjung.Items.Add(new TipePengunjung { Nama = "Pengunjung Umum" });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Pengunjung p = new Pengunjung();
            p.Nama = txtNama.Text;
            p.Tipe = (TipePengunjung)listBox_TipePengunjung.SelectedItem;

            listBox_Pengunjung.Items.Add(p);
        }

        private void listBox_TipePengunjung_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            if (listBox_Pengunjung.SelectedItem == null) return;

            Pengunjung selected = (Pengunjung)listBox_Pengunjung.SelectedItem;
            exitPengunjung.Add(selected);
            listBox_Pengunjung.SelectedItems.Remove(selected);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report f = new Report();
            decimal total = 0;
            Pengunjung p = new Pengunjung();
            p.Nama = txtNama.Text;
            p.Tipe = (TipePengunjung)listBox_TipePengunjung.SelectedItem;

            foreach (Pengunjung item in exitPengunjung)
            {
                total = total;
            }
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\CODE\HumanTracker Asli\HumanTracker\Database\HumanTrackerDatabase.mdf';Integrated Security=True");

            using (SqlCommand cmd = new SqlCommand("INSERT INTO PengunjungKeluar (Nama_Pengunjung, Tipe, Waktu) VALUES (@namaPengunjung, @tipe, @waktu)"))
            {
                foreach (Pengunjung item in exitPengunjung)
                {
                    if (item.Nama != "" && item.Tipe.Nama != "")
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@namaPengunjung", item.Nama);
                        cmd.Parameters.AddWithValue("@tipe", item.Tipe.Nama);
                        cmd.Parameters.AddWithValue("@waktu", item.Time.ToString());
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nama dan Tipe Pengunjung tidak boleh kosong!");
                    }
                }
            }
            f.lblTotalPengunjung.Text = exitPengunjung.Count.ToString();
            f.Show();
        }

        private void listBox_Pengunjung_ContextMenuStripChanged(object sender, EventArgs e)
        {

        }

        private void listBox_Pengunjung_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbltime_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox_Pengunjung_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox_Pengunjung.SelectedItem == null) return;
            Pengunjung selected = (Pengunjung)listBox_Pengunjung.SelectedItem;

            selected.ExitTime = DateTime.Now;
            lbl_Nama.Text = selected.Nama;
            lblWaktu.Text = selected.Time.ToString();
        }
    }
}
