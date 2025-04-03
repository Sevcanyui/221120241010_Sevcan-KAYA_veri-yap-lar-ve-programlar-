using System;


class Ogrenci
{
    public int Numara { get; set; }
    public string Isim { get; set; }
    public string Soyisim { get; set; }
    public string DersAdi { get; set; }
    public int Vize { get; set; }
    public int Final { get; set; }
    public Ogrenci Sonraki { get; set; }
}

class OgrenciBagliListe
{
    private Ogrenci bas;

    public void Ekle(int numara, string isim, string soyisim, string dersAdi, int vize, int final)
    {
        Ogrenci yeniOgrenci = new Ogrenci { Numara = numara, Isim = isim, Soyisim = soyisim, DersAdi = dersAdi, Vize = vize, Final = final, Sonraki = null };
        if (bas == null)
        {
            bas = yeniOgrenci;
        }
        else
        {
            Ogrenci temp = bas;
            while (temp.Sonraki != null)
            {
                temp = temp.Sonraki;
            }
            temp.Sonraki = yeniOgrenci;
        }
        Console.WriteLine($"{numara} numaralı öğrenci eklendi");
    }

    public void Listele()
    {
        Ogrenci temp = bas;
        if (temp == null)
        {
            Console.WriteLine("Liste boş!");
            return;
        }
        while (temp != null)
        {
            Console.WriteLine($"Numara: {temp.Numara}\nİsim: {temp.Isim}\nSoyisim: {temp.Soyisim}\nDers Adı: {temp.DersAdi}\nVize: {temp.Vize}\nFinal: {temp.Final}\n");
            temp = temp.Sonraki;
        }
    }

    public void Sil(int numara)
    {
        if (bas == null)
        {
            Console.WriteLine("Liste boş!");
            return;
        }
        if (bas.Numara == numara)
        {
            bas = bas.Sonraki;
            Console.WriteLine($"{numara} numaralı öğrenci silindi.");
            return;
        }
        Ogrenci temp = bas;
        while (temp.Sonraki != null && temp.Sonraki.Numara != numara)
        {
            temp = temp.Sonraki;
        }
        if (temp.Sonraki == null)
        {
            Console.WriteLine("Öğrenci bulunamadı.");
        }
        else
        {
            temp.Sonraki = temp.Sonraki.Sonraki;
            Console.WriteLine($"{numara} numaralı öğrenci silindi.");
        }
    }

    public void EnBasariliOgrenci()
    {
        if (bas == null)
        {
            Console.WriteLine("Liste boş!");
            return;
        }
        Ogrenci temp = bas;
        Ogrenci enBasarili = bas;
        double maxOrtalama = (bas.Vize * 0.4) + (bas.Final * 0.6);

        while (temp != null)
        {
            double ortalama = (temp.Vize * 0.4) + (temp.Final * 0.6);
            if (ortalama > maxOrtalama)
            {
                maxOrtalama = ortalama;
                enBasarili = temp;
            }
            temp = temp.Sonraki;
        }

        Console.WriteLine($"En başarılı öğrenci:\nNumara: {enBasarili.Numara}\nİsim: {enBasarili.Isim}\nSoyisim: {enBasarili.Soyisim}\nDers Adı: {enBasarili.DersAdi}\nVize: {enBasarili.Vize}\nFinal: {enBasarili.Final}\nOrtalama: {maxOrtalama}");
    }
}

class Program
{
    static void Main()
    {
        OgrenciBagliListe ogrenciListesi = new OgrenciBagliListe();

        while (true)
        {
            Console.WriteLine("\n1- Öğrenci ekle\n2- Öğrenci sil\n3- Öğrencileri yazdır\n4- En başarılı öğrenciyi göster\n0- Programı kapat");
            Console.Write("Seçiminiz: ");
            int secim = Convert.ToInt32(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    Console.Write("Numara: ");
                    int numara = Convert.ToInt32(Console.ReadLine());
                    Console.Write("İsim: ");
                    string isim = Console.ReadLine();
                    Console.Write("Soyisim: ");
                    string soyisim = Console.ReadLine();
                    Console.Write("Ders Adı: ");
                    string dersAdi = Console.ReadLine();
                    Console.Write("Vize: ");
                    int vize = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Final: ");
                    int final = Convert.ToInt32(Console.ReadLine());
                    ogrenciListesi.Ekle(numara, isim, soyisim, dersAdi, vize, final);
                    break;
                case 2:
                    Console.Write("Silmek istediğiniz öğrencinin numarasını girin: ");
                    int silinecekNumara = Convert.ToInt32(Console.ReadLine());
                    ogrenciListesi.Sil(silinecekNumara);
                    break;
                case 3:
                    ogrenciListesi.Listele();
                    break;
                case 4:
                    ogrenciListesi.EnBasariliOgrenci();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
