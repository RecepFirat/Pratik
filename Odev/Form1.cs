using Odev.Atiklar;
using Odev.Kutular;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev
{
    public partial class Form1 : Form
    {
        IAtik bardak;
        IAtik camsise;
        IAtik dergi;
        IAtik domat;
        IAtik gazete;
        IAtik KolaKutusu;
        IAtik Salatalik;
        IAtik SalcaKutusu;

        IAtikKutusu OrganikAtikKutusu;
        IAtikKutusu KagitKutusu;
        IAtikKutusu CamKutusu;
        IAtikKutusu MetalKutusu;

        IAtik[] Atiklar;


        Random RND;
        public static int Sure = 60;
        public static int Puan = 0;
        public static int ResimIndex = 0;
        public Form1()
        {
            InitializeComponent();
            Tanimlamalar();
        }

        private void Tanimlamalar()
        {
            Atiklar = new Atik[8];

            byte[] BardakImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/bardak.png");
            Image BardakImage = (Bitmap)((new ImageConverter()).ConvertFrom(BardakImageByte));
            bardak = new Atik(250, BardakImage, Tur.Cam, "Bardak");

            byte[] CamSiseImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/camsise.png");
            Image CamSiseImage = (Bitmap)((new ImageConverter()).ConvertFrom(CamSiseImageByte));
            camsise = new Atik(600, CamSiseImage, Tur.Cam, "Cam Şişe");

            byte[] DergiImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/dergi.png");
            Image DergiImage = (Bitmap)((new ImageConverter()).ConvertFrom(DergiImageByte));
            dergi = new Atik(200, DergiImage, Tur.Kagit, "Dergi");


            byte[] domatImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/domat.png");
            Image domatImage = (Bitmap)((new ImageConverter()).ConvertFrom(domatImageByte));
            domat = new Atik(150, domatImage, Tur.Organik, "Domates");

            byte[] gazeteImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/gazete.png");
            Image gazeteImage = (Bitmap)((new ImageConverter()).ConvertFrom(gazeteImageByte));
            gazete = new Atik(250, gazeteImage, Tur.Kagit, "Gazete");

            byte[] kolakutusuImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/kolakutusu.png");
            Image kolakutusuiImage = (Bitmap)((new ImageConverter()).ConvertFrom(kolakutusuImageByte));
            KolaKutusu = new Atik(350, kolakutusuiImage, Tur.Metal, "Kola Kutusu");

            byte[] salatalikImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/salatalik.png");
            Image salatalikImage = (Bitmap)((new ImageConverter()).ConvertFrom(salatalikImageByte));
            Salatalik = new Atik(120, salatalikImage, Tur.Organik, "Salatalık");

            byte[] salcaKutusuImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/salcaKutusu.png");
            Image salcaKutusuImage = (Bitmap)((new ImageConverter()).ConvertFrom(salcaKutusuImageByte));
            SalcaKutusu = new Atik(550, salcaKutusuImage, Tur.Metal, "Salça Kutusu");

            Atiklar[0] = bardak;
            Atiklar[1] = camsise;
            Atiklar[2] = dergi;
            Atiklar[3] = domat;
            Atiklar[4] = gazete;
            Atiklar[5] = KolaKutusu;
            Atiklar[6] = Salatalik;
            Atiklar[7] = SalcaKutusu;

            OrganikAtikKutusu = new Kutu(0, 700);
            KagitKutusu = new Kutu(1000, 1200);
            CamKutusu = new Kutu(600, 2200);
            MetalKutusu = new Kutu(800, 2300);
        }
        private void ResimDondurme()
        {
            RND = new Random();
            var RastgeleDeger = RND.Next(0, 7);
            ResimIndex = RastgeleDeger;
            pictureBox_Resim.Image = Atiklar[RastgeleDeger].Image;

        }
        private void btn_YeniOyun_Click(object sender, EventArgs e)
        {
            Puan = 0;
            Sure = 60;
            ResimDondurme();
            timer_sayac_Oyun.Start();
            btn_YeniOyun.Enabled = false;
        }

        private void timer_sayac_Oyun_Tick(object sender, EventArgs e)
        {
            Sure--;
            lbl_Sure_Dynamic.Text = Sure.ToString();
            if (Sure == 0)
            {
                timer_sayac_Oyun.Stop();
                btn_YeniOyun.Enabled = true;
            }
        }

        #region OrganikAtik
        private void btn_OrganikAtik_Click(object sender, EventArgs e)
        {

            if (Sure != 0)
            {
                if (Atiklar[ResimIndex].tur == Tur.Organik)
                {
                    if (OrganikAtikKutusu.Ekle((Atik)Atiklar[ResimIndex]))
                    {

                        progressBar_OrganikAtik.Value = OrganikAtikKutusu.DolulukOrani;
                        Puan = Puan + Atiklar[ResimIndex].Hacim;
                        lbl_Puan_Dynamic.Text = Puan.ToString();
                        listView_OrganikAtik.Items.Add($"{Atiklar[ResimIndex].Isim} ({Atiklar[ResimIndex].Hacim})");
                        ResimDondurme();
                    }
                }
            }
        }



        private void btn_OrganikAtikBosalt_Click(object sender, EventArgs e)
        {
            if (OrganikAtikKutusu.Bosalt())
            {
                Sure = Sure + 3;
                lbl_Sure_Dynamic.Text = Sure.ToString();
                progressBar_OrganikAtik.Value = 0;
                listView_OrganikAtik.Items.Clear();
            }
            else
            {

            }
        }
        #endregion

        #region CamIslemleri
        private void btn_Cam_Click(object sender, EventArgs e)
        {
            if (Sure != 0)
            {

                if (Atiklar[ResimIndex].tur == Tur.Cam)
                {
                    if (CamKutusu.Ekle((Atik)Atiklar[ResimIndex]))
                    {

                        progressBar_cam.Value = CamKutusu.DolulukOrani;
                        Puan = Puan + Atiklar[ResimIndex].Hacim;
                        lbl_Puan_Dynamic.Text = Puan.ToString();
                        listView_Cam.Items.Add($"{Atiklar[ResimIndex].Isim} ({Atiklar[ResimIndex].Hacim})");
                        ResimDondurme();
                    }
                }

            }
        }
        private void btn_CamBosalt_Click(object sender, EventArgs e)
        {
            if (CamKutusu.Bosalt())
            {
                Sure = Sure + 3;
                lbl_Sure_Dynamic.Text = Sure.ToString();
                Puan = Puan + 600;
                lbl_Puan_Dynamic.Text = Puan.ToString();
                progressBar_cam.Value = 0;
                listView_Cam.Items.Clear();

            }
            else
            {

            }
        }


        #endregion

        #region KagitIslemleri
        private void Btn_Kagit_Click(object sender, EventArgs e)
        {
            if (Sure != 0)
            {

                if (Atiklar[ResimIndex].tur == Tur.Kagit)
                {
                    if (KagitKutusu.Ekle((Atik)Atiklar[ResimIndex]))
                    {

                        progressBar_kagitAtik.Value = KagitKutusu.DolulukOrani;
                        Puan = Puan + Atiklar[ResimIndex].Hacim;
                        lbl_Puan_Dynamic.Text = Puan.ToString();
                        listView_Kagit.Items.Add($"{Atiklar[ResimIndex].Isim} ({Atiklar[ResimIndex].Hacim})");
                        ResimDondurme();

                    }
                }


            }

        }
        private void btn_KagitBosalt_Click(object sender, EventArgs e)
        {
            if (KagitKutusu.Bosalt())
            {
                Sure = Sure + 3;
                lbl_Sure_Dynamic.Text = Sure.ToString();
                Puan = Puan + 1000;
                lbl_Puan_Dynamic.Text = Puan.ToString();
                progressBar_kagitAtik.Value = 0;
                listView_Kagit.Items.Clear();
            }
            else
            {

            }
        }
        #endregion

        #region MetalIslemleri
        private void btn_Metal_Click(object sender, EventArgs e)
        {
            if (Sure != 0)
            {

                if (Atiklar[ResimIndex].tur == Tur.Metal)
                {
                    if (MetalKutusu.Ekle((Atik)Atiklar[ResimIndex]))
                    {
                        progressBar_Metal.Value = MetalKutusu.DolulukOrani;
                        Puan = Puan + Atiklar[ResimIndex].Hacim;
                        lbl_Puan_Dynamic.Text = Puan.ToString();
                        listView_Metal.Items.Add($"{Atiklar[ResimIndex].Isim} ({Atiklar[ResimIndex].Hacim})");
                        ResimDondurme();
                    }
                }
                else
                {

                }

            }

        }
        private void btn_MetalBosalt_Click(object sender, EventArgs e)
        {
            if (MetalKutusu.Bosalt())
            {
                Sure = Sure + 3;
                lbl_Sure_Dynamic.Text = Sure.ToString();
                Puan = Puan + 800;
                lbl_Puan_Dynamic.Text = Puan.ToString();
                progressBar_Metal.Value = 0;
                listView_Metal.Items.Clear();
            }
            else
            {

            }
        }
        #endregion

        private void btn_Cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
