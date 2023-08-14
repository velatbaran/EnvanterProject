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
    public partial class fYapilanCalisma : Form
    {
        private EnvanterDbEntities1 db = new EnvanterDbEntities1();
        private YapilanCalismalar yapilanCalismalar = new YapilanCalismalar();

        public fYapilanCalisma()
        {
            InitializeComponent();
        }

        private void Baslangic()
        {
            txtToplamYapilacakIsSayisi.Text = Convert.ToString(db.YapilanCalismalar.Count());
            gridYapilanIsler.DataSource = db.YapilanCalismalar.OrderByDescending(a => a.Id).ToList();
            gridYapilanIsler.EnableHeadersVisualStyles = false;
            gridYapilanIsler.ColumnHeadersDefaultCellStyle.BackColor = Color.Beige;
            this.gridYapilanIsler.DefaultCellStyle.Font = new Font("Tahoma", 8);
            lblKullanici.Text = SystemInformation.UserName;
        }

        private void Temizle()
        {
            txtDurum.Clear();
            txtIsiYapan.Clear();
            txtYapılacakIs.Clear();
            cmbSubeler.Text = "seçiniz...";
            txtYapilacakId.Clear();
        }

        private void btnYapilacakIsEkle_Click(object sender, EventArgs e)
        {
            if (cmbSubeler.Text != "seçiniz..." && txtDurum.Text != "" && txtIsiYapan.Text != "" && txtYapılacakIs.Text != "")
            {
                yapilanCalismalar.BolgeMudurluk = txtBolgeMudurluk.Text;
                yapilanCalismalar.Sube = cmbSubeler.Text;
                yapilanCalismalar.YapilacakIs = txtYapılacakIs.Text;
                yapilanCalismalar.IsıYapanPersonel = txtIsiYapan.Text;
                yapilanCalismalar.Durum = txtDurum.Text;
                yapilanCalismalar.Kaydeden = SystemInformation.UserName;
                yapilanCalismalar.Tarih = DateTime.Now;
                db.YapilanCalismalar.Add(yapilanCalismalar);
                db.SaveChanges();
                Temizle();
                Baslangic();
                MessageBox.Show("Kayıt işlemi başarıyla gerçekleşti.");

            }
            else
            {
                MessageBox.Show("Lütfen gerekli tüm alanları doldurunuz!");
                txtYapılacakIs.Focus();
            }
        }
        private void btnYapilacakTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void fYapilanCalisma_Load(object sender, EventArgs e)
        {
            Baslangic();
        }

        private void btnYapilacakIsGuncelle_Click(object sender, EventArgs e)
        {
            if (txtYapilacakId.Text != "")
            {
                int _id = Convert.ToInt32(txtYapilacakId.Text);
                if (db.YapilanCalismalar.Any(x => x.Id == _id))
                {
                    if (cmbSubeler.Text != "seçiniz..." && txtDurum.Text != "" && txtIsiYapan.Text != "" && txtYapılacakIs.Text != "")
                    {

                        var guncelle = db.YapilanCalismalar.Where(x => x.Id == _id).SingleOrDefault();
                        guncelle.BolgeMudurluk = txtBolgeMudurluk.Text;
                        guncelle.Sube = cmbSubeler.Text;
                        guncelle.YapilacakIs = txtYapılacakIs.Text;
                        guncelle.Durum = txtDurum.Text;
                        guncelle.IsıYapanPersonel = txtIsiYapan.Text;
                        guncelle.Kaydeden = SystemInformation.UserName;
                        guncelle.Tarih = DateTime.Now;
                        db.SaveChanges();
                        Temizle();
                        Baslangic();
                        MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti.");
                    }
                    else
                    {
                        MessageBox.Show("Lütfen gerekli tüm alanları doldurunuz!");
                        txtYapılacakIs.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Sistemde bu çalışma kaydı bulunamadı!");
                }
            }
            else
            {
                MessageBox.Show("Lütfen sistemde kayıtlı bir çalışma seçiniz!");
            }
        }

        private void btnYapilacakIsExcelRapor_Click(object sender, EventArgs e)
        {
            if (gridYapilanIsler.Rows.Count == 0)
            {
                MessageBox.Show("Raporda gösterilecek çalışma bulunamadı!");
            }
            else
            {
                Raporlar.Baslik = "Bilgi Teknolojileri Şube Müdürlüğü Yapılan Çalışmaların Listesi";
                Raporlar.ToplamYapilanCalismaSayisi = txtToplamYapilacakIsSayisi.Text;
                Raporlar.RaporYapilanCalisma(gridYapilanIsler);
            }
        }

        private void btnYapilacakIsGetir_Click(object sender, EventArgs e)
        {
            var tarih1 = dateTimePicker1.Value;
            var tarih2 = dateTimePicker2.Value;
            gridYapilanIsler.DataSource = db.YapilanCalismalar.Where(a => a.Tarih >= tarih1 && a.Tarih <= tarih2).ToList(); ;
            txtToplamYapilacakIsSayisi.Text = Convert.ToString(gridYapilanIsler.Rows.Count);
        }

        private void btnYapilacakIsSifirla_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            Baslangic();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridYapilanIsler.Rows.Count > 0)
            {
                int yapilacakIsId = Convert.ToInt32(gridYapilanIsler.CurrentRow.Cells["Id"].Value.ToString());
                string yapilacakIsAd = gridYapilanIsler.CurrentRow.Cells["YapilacakIs"].Value.ToString();
                DialogResult onay = MessageBox.Show(yapilacakIsAd + " çalışmayı silmek istdeğinize emin misiniz?", "Yapılan Çalışmayı Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var yapilacakIs = db.YapilanCalismalar.Find(yapilacakIsId);
                    db.YapilanCalismalar.Remove(yapilacakIs);
                    db.SaveChanges();
                    MessageBox.Show("Yapılan çalışmayı silme işlemi başarılıyla gerçekleşti.");
                    Baslangic();
                }
                else
                {
                    MessageBox.Show("Silme işlemi iptal edildi!");
                }
            }
        }

        private void gridYapilanIsler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seciliAlan = gridYapilanIsler.SelectedCells[0].RowIndex;
            string id = gridYapilanIsler.Rows[seciliAlan].Cells[0].Value.ToString();
            string mudurluk = gridYapilanIsler.Rows[seciliAlan].Cells[1].Value.ToString();
            string sube = gridYapilanIsler.Rows[seciliAlan].Cells[2].Value.ToString();
            string yapilacakIs = gridYapilanIsler.Rows[seciliAlan].Cells[3].Value.ToString();
            string durum = gridYapilanIsler.Rows[seciliAlan].Cells[4].Value.ToString();
            string isiYapanPersonel = gridYapilanIsler.Rows[seciliAlan].Cells[5].Value.ToString();


            cmbSubeler.Text = sube;
            txtBolgeMudurluk.Text = mudurluk;
            txtYapılacakIs.Text = yapilacakIs;
            txtDurum.Text = durum;
            txtIsiYapan.Text = isiYapanPersonel;
            txtYapilacakId.Text = id;
        }

        private void txtIsArama_TextChanged(object sender, EventArgs e)
        {
            if (txtIsArama.Text.Length > 1)
            {
                string yapilanis = txtIsArama.Text;
                gridYapilanIsler.DataSource = db.YapilanCalismalar.Where(a => a.Sube.Contains(yapilanis) || a.YapilacakIs.Contains(yapilanis) || a.IsıYapanPersonel.Contains(yapilanis)).ToList();
                txtToplamYapilacakIsSayisi.Text = Convert.ToString(gridYapilanIsler.Rows.Count);
            }
            else
            {
                Baslangic();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
