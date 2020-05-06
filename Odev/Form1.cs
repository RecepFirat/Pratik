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
        IAtik Salca;
        Atik[] Atiklar;
        public Form1()
        {
            InitializeComponent();
            Atiklar = new Atik[8];


            byte[] BardakImageByte = File.ReadAllBytes(Application.StartupPath+"/Resimler/bardak.png");
            Image BardakImage = (Bitmap)((new ImageConverter()).ConvertFrom(BardakImageByte));
            bardak = new Atik(250, BardakImage);

            byte[] CamSiseImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/camsise.png"); 
            Image CamSiseImage = (Bitmap)((new ImageConverter()).ConvertFrom(CamSiseImageByte));
            camsise = new Atik(600, CamSiseImage);



            byte[] DergiImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/dergi.png"); 
            Image DergiImage = (Bitmap)((new ImageConverter()).ConvertFrom(DergiImageByte));
           
            dergi = new Atik(200, DergiImage);


            byte[] domatImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/domat.png");
            Image  domatImage  = (Bitmap)((new ImageConverter()).ConvertFrom(domatImageByte));
            domat = new Atik(150, domatImage);



            byte[] gazeteImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/gazete.png");
            Image gazeteImage = (Bitmap)((new ImageConverter()).ConvertFrom(gazeteImageByte));
            gazete = new Atik(250, gazeteImage);



            byte[] kolakutusuImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/kolakutusu.png");
            Image kolakutusuiImage = (Bitmap)((new ImageConverter()).ConvertFrom(kolakutusuImageByte));
            KolaKutusu = new Atik(350, kolakutusuiImage);



            byte[] salatalikImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/salatalik.png");
            Image salatalikImage = (Bitmap)((new ImageConverter()).ConvertFrom(salatalikImageByte));
            Salatalik = new Atik(120, salatalikImage);



            byte[] salcaKutusuImageByte = File.ReadAllBytes(Application.StartupPath + "/Resimler/salca.png");
            Image salcaKutusuImage = (Bitmap)((new ImageConverter()).ConvertFrom(salcaKutusuImageByte));
            Salca = new Atik(550, salcaKutusuImage); 



            




        }
        int Sure = 60;
        private void btn_YeniOyun_Click(object sender, EventArgs e)
        {
            timer_sayac_Oyun.Start();
        }

        private void timer_sayac_Oyun_Tick(object sender, EventArgs e)
        {
            Sure--;
            lbl_Sure_Dynamic.Text = Sure.ToString();
        }
    }
}
