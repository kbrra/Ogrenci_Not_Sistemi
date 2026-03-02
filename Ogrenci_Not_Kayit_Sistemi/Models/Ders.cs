namespace Ogrenci_Not_Kayit_Sistemi.Models
{
    public class Ders
    {
        public short OgrId { get; set; }
        public string? OgrNumara { get; set; }
        public string? OgrAd { get; set; }
        public string? OgrSoyad { get; set; }
        public byte? Ogrs1 { get; set; }
        public byte? Ogrs2 { get; set; }
        public byte? Ogrs3 { get; set; }
        public decimal? Ortalama { get; set; }
        public bool? Durum { get; set; }
    }
}
