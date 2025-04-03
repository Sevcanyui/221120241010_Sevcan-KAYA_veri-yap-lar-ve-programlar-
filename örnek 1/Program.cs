using System;

//Linked List içerisinde bellek üzerinde tanımlanan elemanlar göstericiler yardımı ile birbirlerine bağlanarak tıpkı tren vagonları gibi bir liste yapısı oluştururlar
class Node
{
    public int data;
    public Node next;
    public Node prev;

    public Node(int data)
    {
        this.data = data;
        this.next = null;
        this.prev = null;
    }
}

class LinkedList
{
    private Node head;
    private Node tail;

    public LinkedList()
    {
        head = null;
        tail = null;
    }

    public void BasaEkle(int data)
    {
        Node yeniNode = new Node(data);
        if (head == null)
        {
            head = tail = yeniNode;
            head.next = head;
            head.prev = head;
        }
        else
        {
            yeniNode.next = head;
            yeniNode.prev = tail;
            tail.next = yeniNode;
            head.prev = yeniNode;
            head = yeniNode;
        }
        Console.WriteLine($"Başa {data} eklendi.");
    }

    public void SonaEkle(int data)
    {
        if (head == null)
        {
            BasaEkle(data);
            return;
        }
        Node yeniNode = new Node(data);
        yeniNode.next = head;
        yeniNode.prev = tail;
        tail.next = yeniNode;
        head.prev = yeniNode;
        tail = yeniNode;
        Console.WriteLine($"Sona {data} eklendi.");
    }

    public void Yazdir()
    {
        if (head == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }
        Node temp = head;
        Console.Write("Liste (Baştan): ");
        do
        {
            Console.Write(temp.data + " <-> ");
            temp = temp.next;
        } while (temp != head);
        Console.WriteLine("(Başa döndü)");
    }

    public void TerstenYazdir()
    {
        if (head == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }
        Node temp = tail;
        Console.Write("Liste (Sondan): ");
        do
        {
            Console.Write(temp.data + " <-> ");
            temp = temp.prev;
        } while (temp != tail);
        Console.WriteLine("(Sona döndü)");
    }

    public void BastanSil()
    {
        if (head == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }
        if (head == tail)
        {
            head = tail = null;
        }
        else
        {
            head = head.next;
            head.prev = tail;
            tail.next = head;
        }
        Console.WriteLine("Baştan eleman silindi.");
    }

    public void SondanSil()
    {
        if (head == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }
        if (head == tail)
        {
            head = tail = null;
        }
        else
        {
            tail = tail.prev;
            tail.next = head;
            head.prev = tail;
        }
        Console.WriteLine("Sondan eleman silindi.");
    }
}

class Program
{
    static void Main()
    {
        LinkedList liste = new LinkedList();
        int secim;

        do
        {
            Console.WriteLine("\nMenü:");
            Console.WriteLine("1 - Başa ekle");
            Console.WriteLine("2 - Sona ekle");
            Console.WriteLine("3 - Baştan sil");
            Console.WriteLine("4 - Sondan sil");
            Console.WriteLine("5 - Listeyi yazdır");
            Console.WriteLine("6 - Listeyi tersten yazdır");
            Console.WriteLine("0 - Çıkış");
            Console.Write("Seçiminiz: ");
            secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    Console.Write("Başa eklenecek sayıyı girin: ");
                    int basa = int.Parse(Console.ReadLine());
                    liste.BasaEkle(basa);
                    break;

                case 2:
                    Console.Write("Sona eklenecek sayıyı girin: ");
                    int sona = int.Parse(Console.ReadLine());
                    liste.SonaEkle(sona);
                    break;

                case 3:
                    liste.BastanSil();
                    break;

                case 4:
                    liste.SondanSil();
                    break;

                case 5:
                    liste.Yazdir();
                    break;

                case 6:
                    liste.TerstenYazdir();
                    break;

                case 0:
                    Console.WriteLine("Programdan çıkılıyor...");
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                    break;
            }
        } while (secim != 0);
    }
}
