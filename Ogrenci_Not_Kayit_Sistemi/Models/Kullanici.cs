namespace Ogrenci_Not_Kayit_Sistemi.Models
{

    public class Kullanici
    {
        public int KullaniciId { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; }
        public string? OgrNumara { get; set; }
    }
}