using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanTracker
{
    public partial class MainPage : Form
    {
        private object listbox_Pengunjung;
        private object listbox_TipePengunjung;

        public MainPage()
        {
            InitializeComponent();
        }

        List<Pengunjung> exitPengunjung = new List<Pengunjung>();
        private void MainPage_Load(object sender, EventArgs e)
        {
            listBox_TipePengunjung.Items.Add(new TipePengunjung { Nama = "Pemilik"});
            listBox_TipePengunjung.Items.Add(new TipePengunjung { Nama = "Petinggi"});
            listBox_TipePengunjung.Items.Add(new TipePengunjung { Nama = "Karyawan"});
            listBox_TipePengunjung.Items.Add(new TipePengunjung { Nama = "Pengunjung Umum"});
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
            if (listBox_Pengunjung.SelectedItem == null) return;
            Pengunjung selected = (Pengunjung)listBox_Pengunjung.SelectedItem;

            selected.ExitTime = DateTime.Now;
            lbl_Nama.Text = selected.Nama;
            lblWaktu.Text = selected.Time.ToString();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            if (listBox_Pengunjung.SelectedItems == null) return;

            Pengunjung selected = (Pengunjung)listBox_Pengunjung.SelectedItem;
            exitPengunjung.Add(selected);
            listBox_Pengunjung.Items.Remove(selected);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report f = new Report();
            decimal total = 0;

            foreach (Pengunjung item in exitPengunjung)
            {
                ListViewItem li = new ListViewItem();
                li.Text = item.Nama;
                li.SubItems.Add(item.Tipe.Nama);
                
                li.SubItems.Add(item.Time.ToString());
                
                f.listView1.Items.Add(li);
                total = total;
            }
            f.lblTotalPengunjung.Text = exitPengunjung.Count.ToString();
            f.Show();
        }

        private void listBox_Pengunjung_ContextMenuStripChanged(object sender, EventArgs e)
        {

        }

        private void listBox_Pengunjung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Pengunjung.SelectedItem == null) return;
            Pengunjung selected = (Pengunjung)listBox_Pengunjung.SelectedItem;

            selected.ExitTime = DateTime.Now;
            lbl_Nama.Text = selected.Nama;
            lblWaktu.Text = selected.Time.ToString();
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbltime_Click(object sender, EventArgs e)
        {

        }
    }
}
