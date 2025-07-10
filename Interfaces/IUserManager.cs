using KutuphaneYonetimSistemi.Entities;

namespace KutuphaneYonetimSistemi.Interfaces
{
    // Kullanıcı işlemleri için arayüz
    public interface IUserManager
    {
        // Giriş yapma fonksiyonu
        User GirisYap(string kullaniciAdi, string sifre);

        // Kayıt olma fonksiyonu (isteğe bağlı kullanılabilir)
        void KayitOl(User kullanici);
    }
}
