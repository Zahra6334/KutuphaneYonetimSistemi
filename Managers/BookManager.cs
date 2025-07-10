using KutuphaneYonetimSistemi.Entities;
using KutuphaneYonetimSistemi.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KutuphaneYonetimSistemi.Managers
{
    // Hem IBookOperations hem IBookLending arayüzlerini uygular
    public class BookManager : IBookOperations, IBookLending
    {
        private List<Book> _kitaplar;
        private readonly string _dosyaYolu = "Data/books.json";

        public BookManager()
        {
            if (File.Exists(_dosyaYolu))
            {
                string json = File.ReadAllText(_dosyaYolu);
                _kitaplar = JsonConvert.DeserializeObject<List<Book>>(json) ?? new List<Book>();
            }
            else
            {
                _kitaplar = new List<Book>();
            }
        }

        public void KitapEkle(Book kitap)
        {
            _kitaplar.Add(kitap);
            Kaydet();
        }

        public void KitapSil(string isbn)
        {
            _kitaplar.RemoveAll(k => k.ISBN == isbn);
            Kaydet();
        }

        public void KitapGuncelle(Book guncelKitap)
        {
            var kitap = _kitaplar.FirstOrDefault(k => k.ISBN == guncelKitap.ISBN);
            if (kitap != null)
            {
                kitap.Adi = guncelKitap.Adi;
                kitap.Yazari = guncelKitap.Yazari;
                kitap.YayinYili = guncelKitap.YayinYili;
                Kaydet();
            }
        }

        public List<Book> TumKitaplariGetir()
        {
            return _kitaplar;
        }

        public void KitapOduncVer(string isbn, string kullaniciAdi)
        {
            var kitap = _kitaplar.FirstOrDefault(k => k.ISBN == isbn && !k.OduncteMi);
            if (kitap != null)
            {
                kitap.OduncteMi = true;
                Kaydet();
            }
        }

        public void KitapIadeAl(string isbn, string kullaniciAdi)
        {
            var kitap = _kitaplar.FirstOrDefault(k => k.ISBN == isbn && k.OduncteMi);
            if (kitap != null)
            {
                kitap.OduncteMi = false;
                Kaydet();
            }
        }

        public List<Book> KullaniciOduncKitaplari(string kullaniciAdi)
        {
            return _kitaplar.Where(k => k.OduncteMi).ToList();
        }

        private void Kaydet()
        {
            string json = JsonConvert.SerializeObject(_kitaplar, Formatting.Indented);
            File.WriteAllText(_dosyaYolu, json);
        }
    }
}
