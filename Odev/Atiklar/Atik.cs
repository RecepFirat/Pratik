using System.Drawing;

namespace Odev.Atiklar
{
    public   class Atik : IAtik
    {
        public int Hacim { get; }

        public Image Image { get; }
        public Tur tur { get; }

        public string Isim { get; }

        public Atik( int Puan,Image Resim,Tur AtikTuru,string Isim)
        {
            Hacim = Puan;
            Image= Resim ;
            tur = AtikTuru;
            this.Isim = Isim;

        }


       
    }
}