using Odev.Atiklar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Kutular
{
    public class Kutu : IAtikKutusu
    {
        public int BosaltmaPuani { get; }

        public int Kapasite { get; set; }
        private int _DoluHacim;
        public int DoluHacim { get { return _DoluHacim; } }
     
        public int DolulukOrani { get { return _DolulukOrani; } }
        private int _DolulukOrani;
        public Kutu(int _BosaltmaPuani,int Kapasite)
        {
            this.BosaltmaPuani = _BosaltmaPuani;
            this.Kapasite = Kapasite;
        }
        /**
         * 
         *  kapasite     _Dolu hacim 
         * 100            x
         * 
         * 100* Doluhacim /kapasite
         * 
         * **/


        public bool Bosalt()
        {
            if (DolulukOrani >= 75)
            {
                _DoluHacim = 0;
                _DolulukOrani = 0;
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public bool Ekle(Atik atik)
        {
            if (DolulukOrani<(75))
            {
                _DoluHacim = atik.Hacim + _DoluHacim;
                _DolulukOrani = 100* _DoluHacim / Kapasite;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
