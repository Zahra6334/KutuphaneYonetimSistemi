namespace KutuphaneYonetimSistemi.Entities
{
    public class OduncIstek
    {
        public string ISBN { get; set; }
        public string KullaniciAdi { get; set; }
        public bool OnaylandiMi { get; set; } = false;
        public bool ReddedildiMi { get; set; } = false;
    }
}
