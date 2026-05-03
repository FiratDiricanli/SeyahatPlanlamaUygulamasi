using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Seyahat_Planlama_Uygulaması
{
    public class Konaklama
    {
        public string otel_adi { get; set; }
        public double fiyat { get; set; }
    }

    public class Plan
    {
        public string rota { get; set; }
        public string aktiviteler { get; set; }
    }

    public class Seyahat
    {
        [DisplayName("Seyahat ID")]
        public int seyahat_id { get; set; }

        [DisplayName("Gidiş Yeri")]
        public string gidis_yeri { get; set; }

        [DisplayName("Tarih")]
        public string tarih { get; set; }

        [Browsable(false)]
        public Konaklama konaklama_bilgisi { get; set; }

        [Browsable(false)]
        public Plan plan_bilgisi { get; set; }

        [DisplayName("Otel Adı")]
        public string OtelAdi => konaklama_bilgisi?.otel_adi;

        [DisplayName("Otel Fiyatı (TL)")]
        public double OtelFiyati => konaklama_bilgisi != null ? konaklama_bilgisi.fiyat : 0;

        [DisplayName("Rota")]
        public string Rota => plan_bilgisi?.rota;

        [DisplayName("Planlanan Aktiviteler")]
        public string Aktiviteler => plan_bilgisi?.aktiviteler;
    }

    public partial class Form1 : Form
    {
        List<Seyahat> seyahatler = new List<Seyahat>();
        int seyahatSayac = 10001;

        TabControl sekmeler;
        TabPage sekmeYeniKayıt, sekmeListe;
        DataGridView dgvSeyahatler;

        TextBox txtGidisYeri, txtTarih, txtOtelAdi, txtOtelFiyati, txtRota, txtAktiviteler;

        public Form1()
        {
            this.Text = "Seyahat Planlama Uygulaması - 2300005412 Fırat Diricanlı";
            this.Size = new Size(1150, 750);
            this.StartPosition = FormStartPosition.CenterScreen;

            SistemVerileriniHazirla();
            ArayuzuInsaEt();
        }

        private void SistemVerileriniHazirla()
        {
            seyahatler.Add(new Seyahat { seyahat_id = seyahatSayac++, gidis_yeri = "Paris, Fransa", tarih = "15.06.2026", konaklama_bilgisi = new Konaklama { otel_adi = "Ritz Paris", fiyat = 15000 }, plan_bilgisi = new Plan { rota = "Şehir Merkezi", aktiviteler = "Eyfel Kulesi Ziyareti, Louvre Müzesi Turu" } });
            seyahatler.Add(new Seyahat { seyahat_id = seyahatSayac++, gidis_yeri = "Roma, İtalya", tarih = "22.07.2026", konaklama_bilgisi = new Konaklama { otel_adi = "Hotel Artemide", fiyat = 8500 }, plan_bilgisi = new Plan { rota = "Tarihi Yarımada", aktiviteler = "Kolezyum Turu, Vatikan Ziyareti" } });
            seyahatler.Add(new Seyahat { seyahat_id = seyahatSayac++, gidis_yeri = "Tokyo, Japonya", tarih = "10.08.2026", konaklama_bilgisi = new Konaklama { otel_adi = "Shinjuku Granbell", fiyat = 12000 }, plan_bilgisi = new Plan { rota = "Shinjuku - Shibuya", aktiviteler = "Fuji Dağı Turu, Shibuya Meydanı" } });
            seyahatler.Add(new Seyahat { seyahat_id = seyahatSayac++, gidis_yeri = "New York, ABD", tarih = "05.09.2026", konaklama_bilgisi = new Konaklama { otel_adi = "The Plaza Hotel", fiyat = 20000 }, plan_bilgisi = new Plan { rota = "Manhattan", aktiviteler = "Özgürlük Anıtı, Central Park Yürüyüşü" } });
            seyahatler.Add(new Seyahat { seyahat_id = seyahatSayac++, gidis_yeri = "Londra, İngiltere", tarih = "12.10.2026", konaklama_bilgisi = new Konaklama { otel_adi = "The Savoy", fiyat = 18000 }, plan_bilgisi = new Plan { rota = "Westminster", aktiviteler = "London Eye, British Museum" } });
            seyahatler.Add(new Seyahat { seyahat_id = seyahatSayac++, gidis_yeri = "Kapadokya, Türkiye", tarih = "20.05.2026", konaklama_bilgisi = new Konaklama { otel_adi = "Museum Hotel", fiyat = 7000 }, plan_bilgisi = new Plan { rota = "Göreme - Ürgüp", aktiviteler = "Balon Turu, Peri Bacaları Gezisi" } });
            seyahatler.Add(new Seyahat { seyahat_id = seyahatSayac++, gidis_yeri = "Antalya, Türkiye", tarih = "01.07.2026", konaklama_bilgisi = new Konaklama { otel_adi = "Regnum Carya", fiyat = 14000 }, plan_bilgisi = new Plan { rota = "Belek - Kaş", aktiviteler = "Düden Şelalesi, Dalış Turu" } });
            seyahatler.Add(new Seyahat { seyahat_id = seyahatSayac++, gidis_yeri = "Barselona, İspanya", tarih = "14.08.2026", konaklama_bilgisi = new Konaklama { otel_adi = "W Barcelona", fiyat = 11000 }, plan_bilgisi = new Plan { rota = "Katalonya Meydanı", aktiviteler = "Sagrada Familia, Park Güell Turu" } });
            seyahatler.Add(new Seyahat { seyahat_id = seyahatSayac++, gidis_yeri = "Dubai, BAE", tarih = "25.11.2026", konaklama_bilgisi = new Konaklama { otel_adi = "Burj Al Arab", fiyat = 35000 }, plan_bilgisi = new Plan { rota = "Dubai Marina", aktiviteler = "Çöl Safarisi, Burj Khalifa Seyir Terası" } });
            seyahatler.Add(new Seyahat { seyahat_id = seyahatSayac++, gidis_yeri = "Prag, Çekya", tarih = "18.12.2026", konaklama_bilgisi = new Konaklama { otel_adi = "Four Seasons Prag", fiyat = 9500 }, plan_bilgisi = new Plan { rota = "Eski Şehir Merkezi", aktiviteler = "Charles Köprüsü, Astronomik Saat Ziyareti" } });
        }

        private void ArayuzuInsaEt()
        {
            sekmeler = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10, FontStyle.Bold) };

            sekmeYeniKayıt = new TabPage("Yeni Seyahat Oluştur");
            sekmeListe = new TabPage("Mevcut Seyahat Planları");

            Panel pnlKayit = new Panel { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke };

            Label lblGenel = new Label { Text = "Genel Seyahat Bilgileri", Location = new Point(30, 20), AutoSize = true, ForeColor = Color.SteelBlue, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            txtGidisYeri = new TextBox { Location = new Point(30, 50), Width = 250, PlaceholderText = "Gidiş Yeri (Örn: Berlin, Almanya)" };
            txtTarih = new TextBox { Location = new Point(300, 50), Width = 250, PlaceholderText = "Seyahat Tarihi (Örn: 10.09.2026)" };

            Label lblKonaklama = new Label { Text = "Konaklama Detayları", Location = new Point(30, 100), AutoSize = true, ForeColor = Color.SteelBlue, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            txtOtelAdi = new TextBox { Location = new Point(30, 130), Width = 250, PlaceholderText = "Otel Adı" };
            txtOtelFiyati = new TextBox { Location = new Point(300, 130), Width = 250, PlaceholderText = "Toplam Konaklama Fiyatı (TL)" };

            Label lblPlan = new Label { Text = "Aktivite ve Rota Planı", Location = new Point(30, 180), AutoSize = true, ForeColor = Color.SteelBlue, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            txtRota = new TextBox { Location = new Point(30, 210), Width = 520, PlaceholderText = "Rota Bilgisi (Örn: Şehir Merkezi - Kuzey Kıyıları)" };
            txtAktiviteler = new TextBox { Location = new Point(30, 250), Width = 520, Height = 60, Multiline = true, PlaceholderText = "Planlanan Aktiviteler (Virgül ile ayırabilirsiniz)" };

            Button btnPlanKaydet = new Button { Text = "SEYAHAT PLANINI SİSTEME KAYDET", Location = new Point(30, 330), Size = new Size(520, 45), BackColor = Color.SeaGreen, ForeColor = Color.White };
            btnPlanKaydet.Click += (s, e) => SeyahatKaydet();

            pnlKayit.Controls.AddRange(new Control[] { lblGenel, txtGidisYeri, txtTarih, lblKonaklama, txtOtelAdi, txtOtelFiyati, lblPlan, txtRota, txtAktiviteler, btnPlanKaydet });
            sekmeYeniKayıt.Controls.Add(pnlKayit);

            dgvSeyahatler = TabloOlustur();
            sekmeListe.Controls.Add(dgvSeyahatler);

            sekmeler.TabPages.AddRange(new TabPage[] { sekmeYeniKayıt, sekmeListe });
            this.Controls.Add(sekmeler);

            TabloGuncelle();
        }

        private DataGridView TabloOlustur()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
        }

        private void TabloGuncelle()
        {
            dgvSeyahatler.DataSource = null;
            dgvSeyahatler.DataSource = seyahatler.ToList();
        }

        private void SeyahatKaydet()
        {
            if (!string.IsNullOrWhiteSpace(txtGidisYeri.Text) && double.TryParse(txtOtelFiyati.Text, out double fiyatSistemi))
            {
                Konaklama yeniKonaklama = new Konaklama
                {
                    otel_adi = txtOtelAdi.Text,
                    fiyat = fiyatSistemi
                };

                Plan yeniPlan = new Plan
                {
                    rota = txtRota.Text,
                    aktiviteler = txtAktiviteler.Text
                };

                Seyahat yeniSeyahat = new Seyahat
                {
                    seyahat_id = seyahatSayac++,
                    gidis_yeri = txtGidisYeri.Text,
                    tarih = txtTarih.Text,
                    konaklama_bilgisi = yeniKonaklama,
                    plan_bilgisi = yeniPlan
                };

                seyahatler.Add(yeniSeyahat);

                txtGidisYeri.Clear(); txtTarih.Clear(); txtOtelAdi.Clear(); txtOtelFiyati.Clear(); txtRota.Clear(); txtAktiviteler.Clear();
                TabloGuncelle();

                MessageBox.Show("Yeni seyahat planı başarıyla sisteme kaydedilmiştir.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sekmeler.SelectedTab = sekmeListe;
            }
            else
            {
                MessageBox.Show("Lütfen zorunlu alanları eksiksiz doldurunuz ve fiyat bilgisini sayısal olarak giriniz.", "Eksik Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}