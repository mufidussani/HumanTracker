using System;
using System.Collections.Generic;
using System.Text;

namespace HumanTracker
{
    class TipePengunjung : Pengunjung
    {
        public string Nama { get; set; }
        public override string ToString()
        {
            return Nama;
        }
    }
}
