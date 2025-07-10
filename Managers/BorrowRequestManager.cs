using KutuphaneYonetimSistemi.Entities;
using KutuphaneYonetimSistemi.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KutuphaneYonetimSistemi.Managers
{
    public class BorrowRequestManager : IBorrowRequestManager
    {
        private List<OduncIstek> _istekler;
        private readonly string _dosyaYolu = "Data/borrowrequests.json";

        public BorrowRequestManager()
        {
            if (File.Exists(_dosyaYolu))
            {
                string json = File.ReadAllText(_dosyaYolu);
                _istekler = JsonConvert.DeserializeObject<List<OduncIstek>>(json) ?? new List<OduncIstek>();
            }
            else
            {
                _istekler = new List<OduncIstek>();
            }
        }

        public void IstekEkle(OduncIstek istek)
        {
            _istekler.Add(istek);
            Kaydet();
        }

        public List<OduncIstek> TumIstekleriGetir()
        {
            return _istekler.Where(i => !i.OnaylandiMi && !i.ReddedildiMi).ToList();
        }

        public void IstekOnayla(string isbn, string kullaniciAdi)
        {
            var istek = _istekler.FirstOrDefault(i => i.ISBN == isbn && i.KullaniciAdi == kullaniciAdi);
            if (istek != null)
            {
                istek.OnaylandiMi = true;
                Kaydet();
            }
        }

        public void IstekReddet(string isbn, string kullaniciAdi)
        {
            var istek = _istekler.FirstOrDefault(i => i.ISBN == isbn && i.KullaniciAdi == kullaniciAdi);
            if (istek != null)
            {
                istek.ReddedildiMi = true;
                Kaydet();
            }
        }

        private void Kaydet()
        {
            string json = JsonConvert.SerializeObject(_istekler, Formatting.Indented);
            File.WriteAllText(_dosyaYolu, json);
        }
    }
}
