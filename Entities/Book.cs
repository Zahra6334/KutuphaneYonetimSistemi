namespace KutuphaneYonetimSistemi.Entities
{
    // Bu sınıf, kitaplara ait bilgileri tutar
    public class Book
    {
        public string ISBN { get; set; } // Kitap numarası (isteğe bağlı ama benzersiz olabilir)
        public string Adi { get; set; } // Kitap adı
        public string Yazari { get; set; } // Yazar adı
        public int YayinYili { get; set; } // Yayın yılı
        public bool OduncteMi { get; set; } = false; // Kitap ödünçte mi?
    }
}
