﻿using System;
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
        private EnvanterDbEntities db = new EnvanterDbEntities();
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
        public void SubeDoldur()
        {
            cmbSube.DisplayMember = "Ad";
            cmbSube.ValueMember = "Id";
            cmbSube.DataSource = db.Subeler.ToList();
        }

        public void TumUrunleriGetir()
        {
            // db.Configuration.LazyLoadingEnabled = false;
            gridUrunler.DataSource = db.Urunler.Select(k => new { k.Id, k.Kategori, k.Marka, k.Model, k.SeriNo, k.Ozellik, k.Aciklama, k.Kullanici, k.Sube, k.Tarih, k.Kaydeden, k.Durum }).OrderByDescending(x => x.Id).ToList();
            //gridUrunler.DataSource = (from k in db.Urunler.ToList()
            //                          select new { k.Id, k.Kategori, k.Marka, k.Model, k.SeriNo, k.Ozellik, k.Aciklama, k.Kullanici, k.Sube, k.Tarih, k.Kaydeden, k.Durum }).OrderByDescending(x => x.Id).ToList();
            // gridUrunler.DataSource = db.Urunler.OrderByDescending(x => x.Id).ToList();
            if (gridUrunler.Rows.Count > 0)
            {
                gridUrunler.Columns[0].Visible = false;
                gridUrunler.Columns[1].HeaderText = "Kategori";
                gridUrunler.Columns[2].HeaderText = "Marka";
                gridUrunler.Columns[3].HeaderText = "Model";
                gridUrunler.Columns[4].HeaderText = "Seri No";
                gridUrunler.Columns[5].HeaderText = "Özellik";
                gridUrunler.Columns[6].HeaderText = "Açıklama";
                gridUrunler.Columns[7].HeaderText = "Kullanıcı";
                gridUrunler.Columns[8].HeaderText = "Şube";
                gridUrunler.Columns[9].HeaderText = "Tarih";
                gridUrunler.Columns[10].HeaderText = "Kaydeden";
                gridUrunler.Columns[11].HeaderText = "Durum";
                lblGirisYapan.Text = SystemInformation.UserName;
                txtUrunSayisi.Text = Convert.ToString(db.Urunler.Count());
            }
        }

        private void Temizle()
        {
            cmbKategori.Text = "seçiniz...";
            txtMarka.Clear();
            txtModel.Clear();
            txtSeriNo.Clear();
            txtKullanici.Clear();
            cmbSube.Text = "seçiniz...";
            txtAciklama.Clear();
            txtUrunId.Clear();
            txtOzellik.Clear();
            txtMarka.Focus();
        }
        private void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            if (cmbKategori.Text != "seçiniz..." && txtMarka.Text != "" && txtModel.Text != "" && txtSeriNo.Text != "" && cmbSube.Text != "seçiniz..." && txtKullanici.Text != "")
            {
                if (db.Urunler.Any(x => x.SeriNo == txtSeriNo.Text))
                {
                    MessageBox.Show("Bu seri no ya sahip ürün zaten kayıtlı!", "Ürün Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    urunler.Kategori = cmbKategori.Text;
                    urunler.Ozellik = txtOzellik.Text;
                    urunler.Marka = txtMarka.Text;
                    urunler.Model = txtModel.Text;
                    urunler.SeriNo = txtSeriNo.Text;
                    urunler.Kullanici = txtKullanici.Text;
                    urunler.Sube = cmbSube.Text;
                    urunler.Aciklama = txtAciklama.Text;
                    urunler.Kaydeden = SystemInformation.UserName;
                    urunler.Tarih = DateTime.Now;
                    urunler.Durum = "Faal";
                    db.Urunler.Add(urunler);
                    db.SaveChanges();
                    Temizle();
                    TumUrunleriGetir();
                    MessageBox.Show("Kayıt işlemi başarıyla gerçekleşti.", "Ürün Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli tüm alanları doldurunuz!", "Ürün Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtMarka.Focus();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void fUrunEkle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'envanterDbDataSet.Urunler' table. You can move, or remove it, as needed.
            // Baslangic();
            TumUrunleriGetir();
            KategoriDoldur();
            SubeDoldur();
            cmbSube.Text = "seçiniz...";
            cmbKategori.Text = "seçiniz...";
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
                    if (cmbKategori.Text != "seçiniz..." && txtMarka.Text != "" && txtModel.Text != "" && txtSeriNo.Text != "" && cmbSube.Text != "seçiniz..." && txtKullanici.Text != "")
                    {
                        if (db.Urunler.Any(x => x.SeriNo == txtSeriNo.Text && x.Id != _id))
                        {
                            MessageBox.Show("Bu seri no ya sahip ürün zaten kayıtlı!", "Ürün Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else
                        {
                            var guncelle = db.Urunler.Where(x => x.Id == _id).SingleOrDefault();
                            guncelle.Kategori = cmbKategori.Text;
                            guncelle.Marka = txtMarka.Text;
                            guncelle.Model = txtModel.Text;
                            guncelle.SeriNo = txtSeriNo.Text;
                            guncelle.Ozellik = txtOzellik.Text;
                            guncelle.Kullanici = txtKullanici.Text;
                            guncelle.Sube = cmbSube.Text;
                            guncelle.Aciklama = txtAciklama.Text;
                            guncelle.Kaydeden = SystemInformation.UserName;
                            guncelle.Tarih = DateTime.Now;
                            db.SaveChanges();
                            Temizle();
                            TumUrunleriGetir();
                            MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti.", "Ürün Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen gerekli tüm alanları doldurunuz!", "Ürün Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        txtMarka.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Sistemde bu ürün kaydı bulunamadı!", "Ürün Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show("Lütfen sistemde kayıtlı bir ürün seçiniz!", "Ürün Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btnExcelRapor_Click(object sender, EventArgs e)
        {
            if (gridUrunler.Rows.Count == 0)
            {
                MessageBox.Show("Raporda gösterilecek ürün bulunamadı!", "Rapor Alma", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                Raporlar.Baslik = "Bilgi Teknolojileri Şube Müdürlüğü Ürün Envanter Listesi";
                Raporlar.ToplamUrunSayisi = txtUrunSayisi.Text;
                Raporlar.RaporSayfasiRaposu(gridUrunler);
            }
        }

        private void GenelArama()
        {
            try
            {
                if (rdArizali.Checked == true || rdFaal.Checked == true || rdKayittanDusurulme.Checked == true)
                {
                    if (rdArizali.Checked == true)
                    {
                        gridUrunler.DataSource = db.Urunler.Where(a => a.Ozellik.Contains(txtUrunOzellikAra.Text) && a.Kategori.Contains(txtUrunKategoriAra.Text) && a.Kullanici.Contains(txtUrunKullaniciAra.Text) && a.SeriNo.Contains(txtUrunSeriNoAra.Text) && a.Marka.Contains(txtUrunMarkaAra.Text) && a.Model.Contains(txtUrunModelAra.Text) && a.Sube.Contains(txtUruSubeAra.Text) && a.Durum == rdArizali.Text).Select(k => new { k.Id, k.Kategori, k.Marka, k.Model, k.SeriNo, k.Ozellik, k.Aciklama, k.Kullanici, k.Sube, k.Tarih, k.Kaydeden, k.Durum }).OrderByDescending(x => x.Id).ToList();

                    }
                    else if (rdFaal.Checked == true)
                    {
                        gridUrunler.DataSource = db.Urunler.Where(a => a.Ozellik.Contains(txtUrunOzellikAra.Text) && a.Kategori.Contains(txtUrunKategoriAra.Text) && a.Kullanici.Contains(txtUrunKullaniciAra.Text) && a.SeriNo.Contains(txtUrunSeriNoAra.Text) && a.Marka.Contains(txtUrunMarkaAra.Text) && a.Model.Contains(txtUrunModelAra.Text) && a.Sube.Contains(txtUruSubeAra.Text) && a.Durum == rdFaal.Text).Select(k => new { k.Id, k.Kategori, k.Marka, k.Model, k.SeriNo, k.Ozellik, k.Aciklama, k.Kullanici, k.Sube, k.Tarih, k.Kaydeden, k.Durum }).OrderByDescending(x => x.Id).ToList();
                    }
                    else if (rdKayittanDusurulme.Checked == true)
                    {
                        gridUrunler.DataSource = db.Urunler.Where(a => a.Ozellik.Contains(txtUrunOzellikAra.Text) && a.Kategori.Contains(txtUrunKategoriAra.Text) && a.Kullanici.Contains(txtUrunKullaniciAra.Text) && a.SeriNo.Contains(txtUrunSeriNoAra.Text) && a.Marka.Contains(txtUrunMarkaAra.Text) && a.Model.Contains(txtUrunModelAra.Text) && a.Sube.Contains(txtUruSubeAra.Text) && a.Durum == rdKayittanDusurulme.Text).Select(k => new { k.Id, k.Kategori, k.Marka, k.Model, k.SeriNo, k.Ozellik, k.Aciklama, k.Kullanici, k.Sube, k.Tarih, k.Kaydeden, k.Durum }).OrderByDescending(x => x.Id).ToList();
                    }
                }
                else
                {
                    gridUrunler.DataSource = db.Urunler.Where(a => a.Ozellik.Contains(txtUrunOzellikAra.Text) && a.Kategori.Contains(txtUrunKategoriAra.Text) && a.Kullanici.Contains(txtUrunKullaniciAra.Text) && a.SeriNo.Contains(txtUrunSeriNoAra.Text) && a.Marka.Contains(txtUrunMarkaAra.Text) && a.Model.Contains(txtUrunModelAra.Text) && a.Sube.Contains(txtUruSubeAra.Text)).Select(k => new { k.Id, k.Kategori, k.Marka, k.Model, k.SeriNo, k.Ozellik, k.Aciklama, k.Kullanici, k.Sube, k.Tarih, k.Kaydeden, k.Durum }).OrderByDescending(x => x.Id).ToList();
                }

                if (gridUrunler.Rows.Count == 0)
                {
                    txtUrunSayisi.Text = Convert.ToString(gridUrunler.Rows.Count);
                    MessageBox.Show("Kayıt bulunamadı!", "Ürün Arama", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                txtUrunSayisi.Text = Convert.ToString(gridUrunler.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ürün Arama", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void Aramasifirla()
        {
            txtUrunOzellikAra.Clear();
            txtUrunKategoriAra.Clear();
            txtUrunKullaniciAra.Clear();
            txtUrunSeriNoAra.Clear();
            txtUrunMarkaAra.Clear();
            txtUrunModelAra.Clear();
            txtUruSubeAra.Clear();
            rdArizali.Checked = false;
            rdFaal.Checked = false;
            rdKayittanDusurulme.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            //Baslangic();
            TumUrunleriGetir();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            var tarih1 = dateTimePicker1.Value;
            var tarih2 = dateTimePicker2.Value;
            gridUrunler.DataSource = db.Urunler.Where(a => a.Tarih >= tarih1 && a.Tarih <= tarih2).OrderByDescending(a => a.Id).ToList();
            txtUrunSayisi.Text = Convert.ToString(gridUrunler.Rows.Count);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridUrunler.Rows.Count > 0)
            {
                int seciliAlan = gridUrunler.SelectedCells[0].RowIndex;
                int urunId = Convert.ToInt32(gridUrunler.Rows[seciliAlan].Cells[0].Value.ToString());
                string urunMarka = gridUrunler.Rows[seciliAlan].Cells[2].Value.ToString();
                DialogResult onay = MessageBox.Show(urunMarka + " ürününü silmek istdeğinize emin misiniz?", "Ürün Silme", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (onay == DialogResult.Yes)
                {
                    var urun = db.Urunler.Find(urunId);
                    db.Urunler.Remove(urun);
                    db.SaveChanges();
                    MessageBox.Show("Ürün silme işlemi başarılıyla gerçekleşti.", "Ürün Silme", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    // Baslangic();
                    TumUrunleriGetir();
                }
                else
                {
                    MessageBox.Show("Silme işlemi iptal edildi!", "Ürün Silme", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void gridUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seciliAlan = gridUrunler.SelectedCells[0].RowIndex;
            string id = gridUrunler.Rows[seciliAlan].Cells[0].Value.ToString();
            string kategori = gridUrunler.Rows[seciliAlan].Cells[1].Value.ToString();
            string marka = gridUrunler.Rows[seciliAlan].Cells[2].Value.ToString();
            string model = gridUrunler.Rows[seciliAlan].Cells[3].Value.ToString();
            string serino = gridUrunler.Rows[seciliAlan].Cells[4].Value.ToString();
            string ozellik = gridUrunler.Rows[seciliAlan].Cells[5].Value.ToString();
            string aciklama = gridUrunler.Rows[seciliAlan].Cells[6].Value.ToString();
            string kullanici = gridUrunler.Rows[seciliAlan].Cells[7].Value.ToString();
            string sube = gridUrunler.Rows[seciliAlan].Cells[8].Value.ToString();

            cmbKategori.Text = kategori;
            txtMarka.Text = marka;
            txtModel.Text = model;
            txtSeriNo.Text = serino;
            txtAciklama.Text = aciklama;
            txtKullanici.Text = kullanici;
            cmbSube.Text = sube;
            txtOzellik.Text = ozellik;
            txtUrunId.Text = id;
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            //  Baslangic();
            TumUrunleriGetir();
        }

        private void fUrunEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Cikis = MessageBox.Show("Ekrandan Çıkmak İstediğinizden Emin Misiniz?", "Çıkış Mesajı!", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (Cikis == DialogResult.Yes)
            {
                this.Hide();

            }
            else if (Cikis == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void yapılanÇalışmalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fYapilanCalisma frm = new fYapilanCalisma();
            frm.ShowDialog();
        }

        private void durumGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fUrunDurumGuncelle f = new fUrunDurumGuncelle();
            int seciliAlan = gridUrunler.SelectedCells[0].RowIndex;
            f.lblUrunDurumId.Text = gridUrunler.Rows[seciliAlan].Cells[0].Value.ToString();
            f.Show();
        }

        private void btnGenelArama_Click_1(object sender, EventArgs e)
        {
            GenelArama();
        }

        private void btnAramaTemizle_Click_1(object sender, EventArgs e)
        {
            Aramasifirla();
        }
    }
}
