using System.Drawing;

namespace Odev.Atiklar
{
    public   class Atik : IAtik
    {
        public int Hacim { get; }

        public Image Image { get; }

        public Atik( int Puan,Image Resim)
        {
            Hacim = Puan;
            Resim = Image;
        }
    }
}