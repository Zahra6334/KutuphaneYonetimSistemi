namespace KutuphaneYonetimSistemi.Entities
{
    // Bu sınıf, kullanıcı bilgilerini tutar (admin veya normal kullanıcı olabilir)
    public class User
    {
        public string KullaniciAdi { get; set; } // Giriş için kullanıcı adı
        public string Sifre { get; set; } // Giriş için şifre
        public bool AdminMi { get; set; } // true = admin, false = normal kullanıcı
    }
}
