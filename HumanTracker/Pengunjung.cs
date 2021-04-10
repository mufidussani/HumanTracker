using System;
using System.Collections.Generic;
using System.Text;

namespace HumanTracker
{
    abstract class Pemilik
    {
        public abstract string ToString();
    }
    class Pengunjung
    {
        public Pengunjung()
        {
            EntranceTime = DateTime.Now;
        }

        public string Nama { get; set; }
        public TipePengunjung Tipe { get; set; }
        public DateTime EntranceTime { get; set; }
        public DateTime ExitTime { get; set; }

        public int Time
        {
            get
            {
                TimeSpan diff = (ExitTime - EntranceTime);
                if (diff - TimeSpan.FromMinutes((int)diff.TotalMinutes)>TimeSpan.Zero)
                {
                    diff = diff.Add(TimeSpan.FromMinutes(1));
                }
                return (int)diff.TotalMinutes;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} -- {1} -- {2}", Nama, Tipe, DateTime.Now.ToString());
        }

    }
}
