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
    public partial class fUrunDurumGuncelle : Form
    {
        private EnvanterDbEntities db = new EnvanterDbEntities();
        private Urunler urunler = new Urunler();

        public fUrunDurumGuncelle()
        {
            InitializeComponent();
        }

        private void fUrunDurumGuncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic result = MessageBox.Show("Çıkmak istiyor musunuz?", "Ürün Durum Güncelleme Sayfası", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                   // TumUrunleriGetir();
                }

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnDurumGuncelle_Click(object sender, EventArgs e)
        {
            if (lblUrunDurumId.Text != "")
            {
                int _id = Convert.ToInt32(lblUrunDurumId.Text);
                var urun = db.Urunler.Find(_id);
                fUrunEkle f = (fUrunEkle)Application.OpenForms["fUrunEkle"];
                if (urun != null)
                {
                    if (rdArizali.Checked || rdFaal.Checked || rdKayittanDusme.Checked)
                    {
                        var guncelle = db.Urunler.Find(_id);
                        if (rdFaal.Checked == true)
                        {
                            guncelle.Durum = rdFaal.Text;
                            guncelle.Kaydeden = SystemInformation.UserName;
                        }
                        else if (rdArizali.Checked == true)
                        {
                            guncelle.Durum = rdArizali.Text;
                            guncelle.Kaydeden = SystemInformation.UserName;
                        }
                        else if (rdKayittanDusme.Checked == true)
                        {
                            guncelle.Durum = rdKayittanDusme.Text;
                            guncelle.Kaydeden = SystemInformation.UserName;
                        }
                        db.SaveChanges();
                        Temizle();
                        TumUrunleriGetir();
                        MessageBox.Show("Durum Güncelleme işlemi başarıyla gerçekleşti.", "Ürün Durum Güncelleme Sayfası", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir durum seçiniz!", "Ürün Durum Güncelleme Sayfası", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                }
                else
                {
                    MessageBox.Show("Sistemde bu ürün kaydı bulunamadı!", "Ürün Durum Güncelleme Sayfası", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show("Durum güncellemek için lütfen bir kayıt seçiniz seçiniz!", "Ürün Durum Güncelleme Sayfası", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        private void btnDurumVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
           // TumUrunleriGetir();
        }
        private void TumUrunleriGetir()
        {
            fUrunEkle f = (fUrunEkle)Application.OpenForms["fUrunEkle"];
            f.gridUrunler.DataSource = db.Urunler.Select(k => new { k.Id, k.Kategori, k.Marka, k.Model, k.SeriNo, k.Ozellik, k.Aciklama, k.Kullanici, k.Sube, k.Tarih, k.Kaydeden, k.Durum }).OrderByDescending(x => x.Id).ToList();
            f.txtUrunSayisi.Text = f.gridUrunler.Rows.Count.ToString();
        }

        private void Temizle()
        {
            lblUrunDurumId.Text = "";
            rdArizali.Checked = false;
            rdFaal.Checked = false;
            rdKayittanDusme.Checked = false;
        }

        private void fUrunDurumGuncelle_Load(object sender, EventArgs e)
        {

        }
    }
}
