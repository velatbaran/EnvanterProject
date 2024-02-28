using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvanterProject
{
    public partial class fKategoriEkle : Form
    {
        private EnvanterDbEntities db = new EnvanterDbEntities();
        private Kategoriler kategoriler = new Kategoriler();
        public fKategoriEkle()
        {
            InitializeComponent();
        }

        private void UrunKategoriDoldur()
        {
            fUrunEkle f = (fUrunEkle)Application.OpenForms["fUrunEkle"];
            if (f != null)
            {
                f.KategoriDoldur();
            }
        }

        private void KategoriDoldur()
        {
            listKategori.DisplayMember = "Ad";
            listKategori.ValueMember = "Id";
            listKategori.DataSource = db.Kategoriler.OrderByDescending(a => a.Id).ToList();
        }

        private void fKategoriEkle_Load(object sender, EventArgs e)
        {
            KategoriDoldur();
        }

        private void btnKategoriKaydet_Click(object sender, EventArgs e)
        {
            if (txtKategoriEkle.Text != "")
            {
                if (db.Kategoriler.Any(x=>x.Ad.ToLower() == txtKategoriEkle.Text.ToLower()))
                {
                    kategoriler.Ad = txtKategoriEkle.Text;
                    db.SaveChanges();
                    KategoriDoldur();
                    txtKategoriEkle.Clear();
                    txtKategoriEkle.Focus();
                    MessageBox.Show("Kayıt işlemi başarıyla gerçekleşti.");
                    UrunKategoriDoldur();
                }
                else
                {
                    kategoriler.Ad = txtKategoriEkle.Text;
                    db.Kategoriler.Add(kategoriler);
                    db.SaveChanges();
                    KategoriDoldur();
                    txtKategoriEkle.Clear();
                    txtKategoriEkle.Focus();
                    MessageBox.Show("Kayıt işlemi başarıyla gerçekleşti.");
                    UrunKategoriDoldur();
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int kategoriId = Convert.ToInt32(listKategori.SelectedValue.ToString());
            string kategoriAd = listKategori.Text;
            DialogResult onay = MessageBox.Show(kategoriAd + " kategorisini silmek istediğinize emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                var kategori = db.Kategoriler.FirstOrDefault(x => x.Id == kategoriId);
                db.Kategoriler.Remove(kategori);
                db.SaveChanges();
                KategoriDoldur();
                txtKategoriEkle.Focus();
                MessageBox.Show("Silme işlemi başarıyla gerçekleşti.");
                UrunKategoriDoldur();
            }
            else
            {
                MessageBox.Show("Silme işlemi iptal edildi!");
            }
        }

        private void listKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKategoriEkle.Text = listKategori.Text;
        }

        private void fKategoriEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic result = MessageBox.Show("Çıkmak istiyor musunuz?", "Kategori Ekleme Sayfası", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                    KategoriDoldur();
                }

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
