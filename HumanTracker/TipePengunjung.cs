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
