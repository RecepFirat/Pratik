using Odev.Atiklar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Kutular
{
    public class Kutu : IAtikKutusu
    {
        public int BosaltmaPuani { get; }

        public int Kapasite { get; set; }

        public int DoluHacim { get; }

        public int DolulukOrani { get; }

        public Kutu(int _BosaltmaPuani,int _DoluHacim,int _DolulukOrani)
        {

        }

        public bool Bosalt()
        {
            return true;
        }

        public bool Ekle(Atik atik)
        {
            return true;
        }
    }
}
