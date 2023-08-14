using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvanterProject
{
    public partial class fBaslangic : Form
    {
        public fBaslangic()
        {
            InitializeComponent();
        }

        private void btnUrunSayfasiGiris_Click(object sender, EventArgs e)
        {
            fUrunEkle f = new fUrunEkle();
            f.lblGirisYapan.Text = SystemInformation.UserName;
            f.ShowDialog();
        }

        private void btnKullanicilarSayfasi_Click(object sender, EventArgs e)
        {
            fKullaniciEkle f = new fKullaniciEkle();
            f.ShowDialog();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult Cikis;
            Cikis = MessageBox.Show("Program Kapatılacak Emin siniz?", "Kapatma Uyarısı!", MessageBoxButtons.YesNo);
            if (Cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnYedekleme_Click(object sender, EventArgs e)
        {
            fYapilanCalisma f = new fYapilanCalisma();
            f.ShowDialog();
        }

        private void btnKullaniciDegistir_Click(object sender, EventArgs e)
        {
            fLogin f = new fLogin();
            f.Show();
            this.Hide();
        }

        private void fBaslangic_Load(object sender, EventArgs e)
        {
            lblKullanici.Text = SystemInformation.UserName; 
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            DialogResult Cikis;
            Cikis = MessageBox.Show("Program Kapatılacak Emin siniz?", "Kapatma Uyarısı!", MessageBoxButtons.YesNo);
            if (Cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
