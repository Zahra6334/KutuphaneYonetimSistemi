using KutuphaneYonetimSistemi.Entities;
using KutuphaneYonetimSistemi.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KutuphaneYonetimSistemi.Managers
{
    // IUserManager arayüzünü uygulayan sınıf
    public class UserManager : IUserManager
    {
        private List<User> _kullanicilar;
        private readonly string _dosyaYolu = "Data/users.json";

        public UserManager()
        {
            // Kullanıcı verilerini dosyadan oku
            if (File.Exists(_dosyaYolu))
            {
                string json = File.ReadAllText(_dosyaYolu);
                _kullanicilar = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            }
            else
            {
                _kullanicilar = new List<User>();
            }
        }

        public User GirisYap(string kullaniciAdi, string sifre)
        {
            return _kullanicilar.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
        }

        public void KayitOl(User kullanici)
        {
            _kullanicilar.Add(kullanici);
            Kaydet();
        }

        private void Kaydet()
        {
            string json = JsonConvert.SerializeObject(_kullanicilar, Formatting.Indented);
            File.WriteAllText(_dosyaYolu, json);
        }
    }
}
