using KutuphaneYonetimSistemi.Entities;
using System.Collections.Generic;

namespace KutuphaneYonetimSistemi.Interfaces
{
    // Kitapla ilgili temel işlemler
    public interface IBookOperations
    {
        void KitapEkle(Book kitap); // Yeni kitap ekleme
        void KitapSil(string isbn); // Kitap silme
        void KitapGuncelle(Book kitap); // Kitap bilgisi güncelleme
        List<Book> TumKitaplariGetir(); // Tüm kitapları listeleme
    }
}
