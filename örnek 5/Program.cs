using System;
using System.Collections;


class Program
{
    static void Main()
    {
        Hashtable kisiler = new Hashtable();
        int secim;

        do
        {
            Console.WriteLine("\n1- Ekle");
            Console.WriteLine("2- Sil");
            Console.WriteLine("3- Yazdır");
            Console.WriteLine("4- Kişi sayısı");
            Console.WriteLine("5- Kişi bul");
            Console.WriteLine("0- Çıkış");
            Console.Write("Seçiminiz: ");
            secim = Convert.ToInt32(Console.ReadLine());
            //istenen verilerim bunlar 

            switch (secim)
            {
                case 1:
                    Console.Write("Kişi ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("İsim: ");
                    string isim = Console.ReadLine();
                    if (!kisiler.ContainsKey(id))
                    {
                        kisiler.Add(id, isim);
                        Console.WriteLine("Kişi eklendi!");
                    }
                    else
                    {
                        Console.WriteLine("Bu ID zaten mevcut!");
                    }
                    break;

                case 2:
                    Console.Write("Silinecek kişi ID: ");
                    int silID = Convert.ToInt32(Console.ReadLine());
                    if (kisiler.ContainsKey(silID))
                    {
                        kisiler.Remove(silID);
                        Console.WriteLine("Kişi silindi!");
                    }
                    else
                    {
                        Console.WriteLine("Bu ID bulunamadı!");
                    }
                    break;

                case 3:
                    Console.WriteLine("\nKişiler Listesi:");
                    foreach (DictionaryEntry kisi in kisiler)
                    {
                        Console.WriteLine("ID: " + kisi.Key + " -> " + kisi.Value);
                    }
                    break;

                case 4:
                    Console.WriteLine("Toplam kişi sayısı: " + kisiler.Count);
                    break;

                case 5:
                    Console.Write("Aranacak kişi ID: ");
                    int araID = Convert.ToInt32(Console.ReadLine());
                    if (kisiler.ContainsKey(araID))
                    {
                        Console.WriteLine("Bulunan kişi: " + kisiler[araID]);
                    }
                    else
                    {
                        Console.WriteLine("Bu ID'ye sahip kişi bulunamadı!");
                    }
                    break;

                case 0:
                    Console.WriteLine("Çıkış yapılıyor...");
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }
        } while (secim != 0);
    }
}