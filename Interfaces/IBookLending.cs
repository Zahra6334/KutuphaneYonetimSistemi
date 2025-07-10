using KutuphaneYonetimSistemi.Entities;
using System.Collections.Generic;

namespace KutuphaneYonetimSistemi.Interfaces
{
    // Ödünç alma ve iade işlemleri için arayüz
    public interface IBookLending
    {
        void KitapOduncVer(string isbn, string kullaniciAdi); // Kitap ödünç ver
        void KitapIadeAl(string isbn, string kullaniciAdi); // Kitap iade al
        List<Book> KullaniciOduncKitaplari(string kullaniciAdi); // Kullanıcının aldığı kitapları getir
    }
}
