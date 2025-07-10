using KutuphaneYonetimSistemi.Entities;
using System.Collections.Generic;

namespace KutuphaneYonetimSistemi.Interfaces
{
    public interface IBorrowRequestManager
    {
        void IstekEkle(OduncIstek istek);
        List<OduncIstek> TumIstekleriGetir();
        void IstekOnayla(string isbn, string kullaniciAdi);
        void IstekReddet(string isbn, string kullaniciAdi);
    }
}
