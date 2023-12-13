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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text != "" && txtSifre.Text != "")
            {

                using (var db = new EnvanterDbEntities())
                {
                    try
                    {
                        if (db.Kullanicilar.Any())
                        {
                            var bak = db.Kullanicilar.Where(x => x.KullaniciAdi == txtKullaniciAdi.Text && x.Sifre == txtSifre.Text).FirstOrDefault();
                            if (bak != null)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                fBaslangic f = new fBaslangic();
                                f.lblKullanici.Text = txtKullaniciAdi.Text;
                                f.Show();
                                this.Hide();
                                Cursor.Current = Cursors.Default;
                            }
                            else
                            {
                                MessageBox.Show("Kullancı adı veya şifre hatalı!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Şu an sistemde herhangi bir kullanıcı tanımlı değil!"); ;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz!");
            }

        }
    }
}
