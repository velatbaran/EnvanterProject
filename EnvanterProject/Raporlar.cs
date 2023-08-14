using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvanterProject
{
    static class Raporlar
    {
        public static string Baslik { get; set; }
        public static string ToplamUrunSayisi { get; set; }
        public static string ToplamYapilanCalismaSayisi { get; set; }

        public static void RaporSayfasiRaposu(DataGridView dgv)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Urunler> listUrunler = new List<Urunler>();
            listUrunler.Clear();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                listUrunler.Add(new Urunler
                {
                    Id = Convert.ToInt32(dgv.Rows[i].Cells["Id"].Value?.ToString()),
                    Kategori = dgv.Rows[i].Cells["Kategori"].Value?.ToString(),
                    Ad = dgv.Rows[i].Cells["Ad"].Value?.ToString(),
                    Marka = dgv.Rows[i].Cells["Marka"].Value?.ToString(),
                    Model = dgv.Rows[i].Cells["Model"].Value?.ToString(),
                    SeriNo = dgv.Rows[i].Cells["SeriNo"].Value?.ToString(),
                    Kullanici = dgv.Rows[i].Cells["Kullanici"].Value?.ToString(),
                    Lokasyon = dgv.Rows[i].Cells["Lokasyon"].Value?.ToString(),
                    Aciklama = dgv.Rows[i].Cells["Aciklama"].Value?.ToString(),
                    Kaydeden = dgv.Rows[i].Cells["Kaydeden"].Value?.ToString(),
                    Tarih = Convert.ToDateTime(dgv.Rows[i].Cells["Tarih"].Value?.ToString())
                });
            }

            ReportDataSource rs = new ReportDataSource();
            rs.Name = "dsGenelRapor";
            rs.Value = listUrunler;
            fRaporGoster f = new fRaporGoster();
            f.reportViewer1.LocalReport.DataSources.Clear();
            f.reportViewer1.LocalReport.DataSources.Add(rs);
            f.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\rpGenelRapor.rdlc";

            ReportParameter[] prm = new ReportParameter[2];
            prm[0] = new ReportParameter("Baslik",Baslik);
            prm[1] = new ReportParameter("ToplamUrunSayisi",ToplamUrunSayisi);
            f.reportViewer1.LocalReport.SetParameters(prm);

            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        public static void RaporYapilanCalisma(DataGridView dgv)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<YapilanCalismalar> listYapilanCalismalar = new List<YapilanCalismalar>();
            listYapilanCalismalar.Clear();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                listYapilanCalismalar.Add(new YapilanCalismalar
                {
                    Id = Convert.ToInt32(dgv.Rows[i].Cells["Id"].Value?.ToString()),
                    BolgeMudurluk = dgv.Rows[i].Cells["BolgeMudurluk"].Value?.ToString(),
                    Sube = dgv.Rows[i].Cells["Sube"].Value?.ToString(),
                    YapilacakIs = dgv.Rows[i].Cells["YapilacakIs"].Value?.ToString(),
                    Durum = dgv.Rows[i].Cells["Durum"].Value?.ToString(),
                    IsıYapanPersonel = dgv.Rows[i].Cells["IsıYapanPersonel"].Value?.ToString(),
                    Kaydeden = dgv.Rows[i].Cells["Kaydeden"].Value?.ToString(),
                    Tarih = Convert.ToDateTime(dgv.Rows[i].Cells["Tarih"].Value?.ToString())
                });
            }

            ReportDataSource rs = new ReportDataSource();
            rs.Name = "dsYapilanIsRapor";
            rs.Value = listYapilanCalismalar;
            fRaporGoster f = new fRaporGoster();
            f.reportViewer1.LocalReport.DataSources.Clear();
            f.reportViewer1.LocalReport.DataSources.Add(rs);
            f.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\rpYapilanIsRapor.rdlc";

            ReportParameter[] prm = new ReportParameter[2];
            prm[0] = new ReportParameter("Baslik", Baslik);
            prm[1] = new ReportParameter("ToplamYapilanCalismaSayisi", ToplamYapilanCalismaSayisi);
            f.reportViewer1.LocalReport.SetParameters(prm);

            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
    }
}
