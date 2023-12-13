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
    public partial class fKullaniciEkle : Form
    {
        public fKullaniciEkle()
        {
            InitializeComponent();
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            if (btnKullaniciKaydet.Text == "Kaydet")
            {
                if (txtAdSoyad.Text != "" && txtKullaniciAdi.Text != "" && txtEposta.Text != "" && txtSifre.Text != "" && txtSifreTekrar.Text != "")
                {
                    if (txtSifre.Text == txtSifreTekrar.Text)
                    {
                        try
                        {
                            using (var db = new EnvanterDbEntities())
                            {
                                if (!db.Kullanicilar.Any(x => x.KullaniciAdi == txtKullaniciAdi.Text))
                                {
                                    Kullanicilar k = new Kullanicilar()
                                    {
                                        AdSoyad = txtAdSoyad.Text,
                                        KullaniciAdi = txtKullaniciAdi.Text.Trim(),
                                        Eposta = txtEposta.Text,
                                        Sifre = txtSifre.Text
                                    };
                                    db.Kullanicilar.Add(k);
                                    db.SaveChanges();
                                    gridKullanicilar.DataSource = db.Kullanicilar.Select(x => new { x.Id, x.AdSoyad, x.KullaniciAdi, x.Eposta }).ToList();
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Bu kullanıcı zaten kayıtlı!");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hata oluştu");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor!");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen gerekli alanları doldurunuz!");
                }
            }
            else if (btnKullaniciKaydet.Text == "Güncelle")
            {
                if (txtAdSoyad.Text != "" && txtKullaniciAdi.Text != "" && txtEposta.Text != "" && txtSifre.Text != "" && txtSifreTekrar.Text != "")
                {
                    if (txtSifre.Text == txtSifreTekrar.Text)
                    {
                        int _id = Convert.ToInt32(lblKullaniciId.Text);
                        try
                        {
                            using (var db = new EnvanterDbEntities())
                            {
                                if (db.Kullanicilar.Any(x => x.KullaniciAdi == txtKullaniciAdi.Text && x.Id != _id))
                                {
                                    MessageBox.Show("Bu kullanıcı adı zaten kayıtlı!");
                                }
                                else
                                {
                                    var k = db.Kullanicilar.Where(x => x.Id == _id).FirstOrDefault();
                                    k.AdSoyad = txtAdSoyad.Text;
                                    k.KullaniciAdi = txtKullaniciAdi.Text.Trim();
                                    k.Eposta = txtEposta.Text;
                                    k.Sifre = txtSifre.Text;
                                    db.SaveChanges();
                                    gridKullanicilar.DataSource = db.Kullanicilar.Select(x => new { x.Id, x.AdSoyad, x.KullaniciAdi, x.Eposta }).ToList();
                                    btnKullaniciKaydet.Text = "Kaydet";
                                    MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti.");
                                    Temizle();
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hata oluştu");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor!");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen gerekli alanları doldurunuz!");
                }
            }
        }

        private void btnKullaniciTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            txtAdSoyad.Clear();
            txtEposta.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            txtSifreTekrar.Clear();
        }

        private void düzenlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridKullanicilar.Rows.Count > 0)
            {
                int id = Convert.ToInt32(gridKullanicilar.CurrentRow.Cells["Id"].Value.ToString());
                using (var db = new EnvanterDbEntities())
                {
                    var kullanici = db.Kullanicilar.Where(x => x.Id == id).FirstOrDefault();
                    txtAdSoyad.Text = kullanici.AdSoyad;
                    txtKullaniciAdi.Text = kullanici.KullaniciAdi;
                    txtEposta.Text = kullanici.Eposta;
                    txtSifre.Text = kullanici.Sifre;
                    txtSifreTekrar.Text = kullanici.Sifre;
                    lblKullaniciId.Text = Convert.ToString(kullanici.Id);
                    btnKullaniciKaydet.Text = "Güncelle";
                }
            }
        }

        private void fKullaniciEkle_Load(object sender, EventArgs e)
        {
            using (var db = new EnvanterDbEntities())
            {
                gridKullanicilar.DataSource = db.Kullanicilar.Select(x => new { x.Id, x.AdSoyad, x.KullaniciAdi, x.Eposta }).ToList();
            }
        }
    }
}
