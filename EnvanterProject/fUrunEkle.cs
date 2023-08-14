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
    public partial class fUrunEkle : Form
    {
        private EnvanterDbEntities1 db = new EnvanterDbEntities1();
        private Urunler urunler = new Urunler();
        public fUrunEkle()
        {
            InitializeComponent();
        }

        public void KategoriDoldur()
        {
            cmbKategori.DisplayMember = "Ad";
            cmbKategori.ValueMember = "Id";
            cmbKategori.DataSource = db.Kategoriler.OrderByDescending(a => a.Id).ToList();
        }

        private void Baslangic()
        {
            txtUrunSayisi.Text = Convert.ToString(db.Urunler.Count());
            gridUrunler.DataSource = db.Urunler.OrderByDescending(a=>a.Id).ToList();
            gridUrunler.EnableHeadersVisualStyles = false;
            gridUrunler.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
            this.gridUrunler.DefaultCellStyle.Font = new Font("Tahoma", 8);
        }

        private void Temizle()
        {
            txtAd.Clear();
            txtMarka.Clear();
            txtModel.Clear();
            txtSeriNo.Clear();
            txtKullanici.Clear();
            txtLokasyon.Clear();
            txtAciklama.Clear();
            txtAd.Focus();
            txtUrunId.Clear();
        }
        private void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            if (cmbKategori.Text != "" && txtAd.Text != "" && txtMarka.Text != "" && txtModel.Text != "" && txtSeriNo.Text != "" && txtKullanici.Text != "" && txtLokasyon.Text != "")
            {
                if (db.Urunler.Any(x => x.SeriNo == txtSeriNo.Text))
                {
                    MessageBox.Show("Bu seri no ya sahip ürün zaten kayıtlı!");
                }
                else
                {
                    urunler.Kategori = cmbKategori.Text;
                    urunler.Ad = txtAd.Text;
                    urunler.Marka = txtMarka.Text;
                    urunler.Model = txtModel.Text;
                    urunler.SeriNo = txtSeriNo.Text;
                    urunler.Kullanici = txtKullanici.Text;
                    urunler.Lokasyon = txtLokasyon.Text;
                    urunler.Aciklama = txtAciklama.Text;
                    urunler.Kaydeden = SystemInformation.UserName;
                    urunler.Tarih = DateTime.Now;
                    db.Urunler.Add(urunler);
                    db.SaveChanges();
                    Temizle();
                    Baslangic();
                    MessageBox.Show("Kayıt işlemi başarıyla gerçekleşti.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli tüm alanları doldurunuz!");
                txtAd.Focus();
            }
        }

        private void txtUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunAdAra.Text.Length > 1)
            {
                string urun = txtUrunAdAra.Text;
                //gridUrunler.DataSource = db.Urunler.Where(a => a.Ad.Contains(urun) || a.Kategori.Contains(urun) || a.Marka.Contains(urun) || a.SeriNo.Contains(urun) || a.Model.Contains(urun) || a.Kullanici.Contains(urun) || a.Lokasyon.Contains(urun)).ToList();
                gridUrunler.DataSource = db.Urunler.Where(a => a.Ad.Contains(urun)).ToList();
                txtUrunSayisi.Text = Convert.ToString(gridUrunler.Rows.Count);
            }
            else
            {
                Baslangic();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void fUrunEkle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'envanterDbDataSet.Urunler' table. You can move, or remove it, as needed.
            Baslangic();
            KategoriDoldur();
        }

        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            fKategoriEkle f = new fKategoriEkle();
            f.ShowDialog();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtUrunId.Text != "")
            {
                int _id = Convert.ToInt32(txtUrunId.Text);
                if (db.Urunler.Any(x => x.Id == _id))
                {
                    if (cmbKategori.Text != "" && txtAd.Text != "" && txtMarka.Text != "" && txtModel.Text != "" && txtSeriNo.Text != "" && txtKullanici.Text != "" && txtLokasyon.Text != "")
                    {
                        if (db.Urunler.Any(x => x.SeriNo == txtSeriNo.Text && x.Id != _id))
                        {
                            MessageBox.Show("Bu seri no ya sahip ürün zaten kayıtlı!");
                        }
                        else
                        {
                            var guncelle = db.Urunler.Where(x => x.Id == _id).SingleOrDefault();
                            guncelle.Kategori = cmbKategori.Text;
                            guncelle.Ad = txtAd.Text;
                            guncelle.Marka = txtMarka.Text;
                            guncelle.Model = txtModel.Text;
                            guncelle.SeriNo = txtSeriNo.Text;
                            guncelle.Kullanici = txtKullanici.Text;
                            guncelle.Lokasyon = txtLokasyon.Text;
                            guncelle.Aciklama = txtAciklama.Text;
                            guncelle.Kaydeden = SystemInformation.UserName;
                            guncelle.Tarih = DateTime.Now;
                            db.SaveChanges();
                            Temizle();
                            Baslangic();
                            MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen gerekli tüm alanları doldurunuz!");
                        txtAd.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Sistemde bu ürün kaydı bulunamadı!");
                }
            }
            else
            {
                MessageBox.Show("Lütfen sistemde kayıtlı bir ürün seçiniz!");
            }
        }

        private void btnExcelRapor_Click(object sender, EventArgs e)
        {
            if (gridUrunler.Rows.Count == 0)
            {
                MessageBox.Show("Raporda gösterilecek ürün bulunamadı!");
            }
            else
            {
                Raporlar.Baslik = "Bilgi Teknolojileri Şube Müdürlüğü Ürün Envanter Listesi";
                Raporlar.ToplamUrunSayisi = txtUrunSayisi.Text;
                Raporlar.RaporSayfasiRaposu(gridUrunler);
            }
        }

        private void txtUrunKullaniciAra_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunKullaniciAra.Text.Length > 1)
            {
                string urun = txtUrunKullaniciAra.Text;
                gridUrunler.DataSource = db.Urunler.Where(a => a.Kullanici.ToLower().Contains(urun.ToLower()) ).ToList();
                txtUrunSayisi.Text = Convert.ToString(gridUrunler.Rows.Count);
            }
            else
            {
                Baslangic();
            }
        }

        private void txtUrunKategoriAra_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunKategoriAra.Text.Length > 1)
            {
                string urun = txtUrunKategoriAra.Text;
                gridUrunler.DataSource = db.Urunler.Where(a => a.Kategori.ToLower().Contains(urun.ToLower())).ToList();
                txtUrunSayisi.Text = Convert.ToString(gridUrunler.Rows.Count);
            }
            else
            {
                Baslangic();
            }
        }

        private void txtUrunSeriNoAra_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunSeriNoAra.Text.Length > 1)
            {
                string urun = txtUrunSeriNoAra.Text;
                gridUrunler.DataSource = db.Urunler.Where(a => a.SeriNo.ToLower().Contains(urun.ToLower())).ToList();
                txtUrunSayisi.Text = Convert.ToString(gridUrunler.Rows.Count);
            }
            else
            {
                Baslangic();
            }
        }

        private void txtUrunMarkaAra_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunMarkaAra.Text.Length > 1)
            {
                string urun = txtUrunMarkaAra.Text;
                gridUrunler.DataSource = db.Urunler.Where(a => a.Marka.ToLower().Contains(urun.ToLower())).ToList();
                txtUrunSayisi.Text = Convert.ToString(gridUrunler.Rows.Count);
            }
            else
            {
                Baslangic();
            }
        }

        private void txtUrunModelAra_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunModelAra.Text.Length > 1)
            {
                string urun = txtUrunModelAra.Text;
                gridUrunler.DataSource = db.Urunler.Where(a => a.Model.ToLower().Contains(urun.ToLower())).ToList();
                txtUrunSayisi.Text = Convert.ToString(gridUrunler.Rows.Count);
            }
            else
            {
                Baslangic();
            }
        }

        private void txtUruLokasyonAra_TextChanged(object sender, EventArgs e)
        {
            if (txtUruLokasyonAra.Text.Length > 1)
            {
                string urun = txtUruLokasyonAra.Text;
                gridUrunler.DataSource = db.Urunler.Where(a => a.Lokasyon.ToLower().Contains(urun.ToLower())).ToList();
                txtUrunSayisi.Text = Convert.ToString(gridUrunler.Rows.Count);
            }
            else
            {
                Baslangic();
            }
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            var tarih1 = dateTimePicker1.Value;
            var tarih2 = dateTimePicker2.Value;
            gridUrunler.DataSource = db.Urunler.Where(a => a.Tarih >= tarih1 && a.Tarih <= tarih2).ToList(); ;
            txtUrunSayisi.Text = Convert.ToString(gridUrunler.Rows.Count - 1);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridUrunler.Rows.Count > 0)
            {
                int urunId = Convert.ToInt32(gridUrunler.CurrentRow.Cells["Id"].Value.ToString());
                string urunAd = gridUrunler.CurrentRow.Cells["Ad"].Value.ToString();
                DialogResult onay = MessageBox.Show(urunAd + " ürününü silmek istdeğinize emin misiniz?", "Ürün Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var urun = db.Urunler.Find(urunId);
                    db.Urunler.Remove(urun);
                    db.SaveChanges();
                    MessageBox.Show("Ürün silme işlemi başarılıyla gerçekleşti.");
                    Baslangic();
                }
                else
                {
                    MessageBox.Show("Silme işlemi iptal edildi!");
                }
            }
        }
        private void gridUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seciliAlan = gridUrunler.SelectedCells[0].RowIndex;
            string id = gridUrunler.Rows[seciliAlan].Cells[0].Value.ToString();
            string kategori = gridUrunler.Rows[seciliAlan].Cells[1].Value.ToString();
            string ad = gridUrunler.Rows[seciliAlan].Cells[2].Value.ToString();
            string marka = gridUrunler.Rows[seciliAlan].Cells[3].Value.ToString();
            string model = gridUrunler.Rows[seciliAlan].Cells[4].Value.ToString();
            string serino = gridUrunler.Rows[seciliAlan].Cells[5].Value.ToString();
            string aciklama = gridUrunler.Rows[seciliAlan].Cells[6].Value.ToString();
            string kullanici = gridUrunler.Rows[seciliAlan].Cells[7].Value.ToString();
            string lokasyon = gridUrunler.Rows[seciliAlan].Cells[8].Value.ToString();

            cmbKategori.Text = kategori;
            txtAd.Text = ad;
            txtMarka.Text = marka;
            txtModel.Text = model;
            txtSeriNo.Text = serino;
            txtAciklama.Text = aciklama;
            txtKullanici.Text = kullanici;
            txtLokasyon.Text = lokasyon;
            txtUrunId.Text = id;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
