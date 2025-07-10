﻿using System;
using KutuphaneYonetimSistemi.Entities;
using KutuphaneYonetimSistemi.Managers;

namespace KutuphaneYonetimSistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "📚 Kütüphane Yönetim Sistemi";

            var kullaniciYonetici = new UserManager();
            var kitapYonetici = new BookManager();

            Console.WriteLine("=== KÜTÜPHANE YÖNETİM SİSTEMİ ===");
            Console.Write("Kullanıcı Adı: ");
            string kullaniciAdi = Console.ReadLine();
            Console.Write("Şifre: ");
            string sifre = Console.ReadLine();

            var girisYapan = kullaniciYonetici.GirisYap(kullaniciAdi, sifre);

            if (girisYapan == null)
            {
                Console.WriteLine("❌ Giriş başarısız. Kullanıcı bulunamadı.");
                return;
            }

            Console.WriteLine($"\n✅ Giriş başarılı. Hoş geldiniz: {girisYapan.KullaniciAdi}");

            if (girisYapan.AdminMi)
            {
                AdminMenusu(kitapYonetici);
            }
            else
            {
                KullaniciMenusu(kitapYonetici, girisYapan.KullaniciAdi);
            }
        }

        static void AdminMenusu(BookManager kitapYonetici)
        {
            while (true)
            {
                Console.WriteLine("\n=== YÖNETİCİ MENÜSÜ ===");
                Console.WriteLine("1 - Kitap Ekle");
                Console.WriteLine("2 - Kitap Sil");
                Console.WriteLine("3 - Kitap Güncelle");
                Console.WriteLine("4 - Kitapları Listele");
                Console.WriteLine("5 - Kitap Ödünç Ver");
                Console.WriteLine("6 - Kitap İade Al");
                Console.WriteLine("0 - Çıkış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.Write("ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Kitap Adı: ");
                        string ad = Console.ReadLine();
                        Console.Write("Yazar: ");
                        string yazar = Console.ReadLine();
                        Console.Write("Yayın Yılı: ");
                        int yil = int.Parse(Console.ReadLine());

                        kitapYonetici.KitapEkle(new Book
                        {
                            ISBN = isbn,
                            Adi = ad,
                            Yazari = yazar,
                            YayinYili = yil
                        });
                        Console.WriteLine("✅ Kitap eklendi.");
                        break;

                    case "2":
                        Console.Write("Silinecek ISBN: ");
                        kitapYonetici.KitapSil(Console.ReadLine());
                        Console.WriteLine("🗑️ Kitap silindi.");
                        break;

                    case "3":
                        Console.Write("Güncellenecek ISBN: ");
                        string gIsbn = Console.ReadLine();
                        Console.Write("Yeni Ad: ");
                        string gAd = Console.ReadLine();
                        Console.Write("Yeni Yazar: ");
                        string gYazar = Console.ReadLine();
                        Console.Write("Yeni Yayın Yılı: ");
                        int gYil = int.Parse(Console.ReadLine());

                        kitapYonetici.KitapGuncelle(new Book
                        {
                            ISBN = gIsbn,
                            Adi = gAd,
                            Yazari = gYazar,
                            YayinYili = gYil
                        });
                        Console.WriteLine("📝 Kitap güncellendi.");
                        break;

                    case "4":
                        var kitaplar = kitapYonetici.TumKitaplariGetir();
                        Console.WriteLine("📚 TÜM KİTAPLAR:");
                        foreach (var k in kitaplar)
                        {
                            Console.WriteLine($"{k.ISBN} - {k.Adi} ({(k.OduncteMi ? "Ödünçte" : "Kütüphanede")})");
                        }
                        break;

                    case "5":
                        Console.Write("Ödünç Verilecek ISBN: ");
                        string oIsbn = Console.ReadLine();
                        Console.Write("Kullanıcı Adı: ");
                        string oKullanici = Console.ReadLine();
                        kitapYonetici.KitapOduncVer(oIsbn, oKullanici);
                        Console.WriteLine("📤 Kitap ödünç verildi.");
                        break;

                    case "6":
                        Console.Write("İade Alınacak ISBN: ");
                        string iIsbn = Console.ReadLine();
                        Console.Write("Kullanıcı Adı: ");
                        string iKullanici = Console.ReadLine();
                        kitapYonetici.KitapIadeAl(iIsbn, iKullanici);
                        Console.WriteLine("📥 Kitap iade alındı.");
                        break;

                    case "0":
                        Console.WriteLine("👋 Çıkış yapılıyor...");
                        return;

                    default:
                        Console.WriteLine("⚠️ Geçersiz seçim.");
                        break;
                }
            }
        }

        static void KullaniciMenusu(BookManager kitapYonetici, string kullaniciAdi)
        {
            while (true)
            {
                Console.WriteLine("\n=== KULLANICI MENÜSÜ ===");
                Console.WriteLine("1 - Kütüphanedeki Kitapları Listele");
                Console.WriteLine("2 - Ödünç Aldığım Kitaplar");
                Console.WriteLine("3 - Kitap İade Et");
                Console.WriteLine("0 - Çıkış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        var kitaplar = kitapYonetici.TumKitaplariGetir();
                        foreach (var k in kitaplar.Where(k => !k.OduncteMi))
                        {
                            Console.WriteLine($"{k.ISBN} - {k.Adi} ({k.Yazari})");
                        }
                        break;

                    case "2":
                        var oduncKitaplar = kitapYonetici.KullaniciOduncKitaplari(kullaniciAdi);
                        Console.WriteLine("📚 ÖDÜNÇ ALDIĞINIZ KİTAPLAR:");
                        foreach (var k in oduncKitaplar)
                        {
                            Console.WriteLine($"{k.ISBN} - {k.Adi}");
                        }
                        break;

                    case "3":
                        Console.Write("İade Etmek İstediğiniz Kitabın ISBN: ");
                        string isbn = Console.ReadLine();
                        kitapYonetici.KitapIadeAl(isbn, kullaniciAdi);
                        Console.WriteLine("📥 Kitap iade edildi.");
                        break;

                    case "0":
                        Console.WriteLine("👋 Çıkış yapılıyor...");
                        return;

                    default:
                        Console.WriteLine("⚠️ Geçersiz seçim.");
                        break;
                }
            }
        }
    }
}
