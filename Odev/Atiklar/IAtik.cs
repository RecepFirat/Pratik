﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Atiklar
{
    public interface IAtik
    {
        int Hacim { get; }
        System.Drawing.Image Image { get; }
        Tur tur { get; }
        string Isim { get; }
    }

}
