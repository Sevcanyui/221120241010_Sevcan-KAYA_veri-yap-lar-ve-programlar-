using System;
using System.Collections.Generic;


////Stack, ilk giren son çıkar işleyişine sahip bir koleksiyondur.
//Diğer bir deyişle; ilk eklenen elemanın koleksiyondan en son çıkarıldığı ve en son eklenen elemanında ilk çıkarıldığı bir veri yapısıdır
class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();
        string command;

        Console.WriteLine("- push\n- pop\n- print\n- top\n- exit");

        while (true)
        {
            Console.Write("\nKomut girin: ");
            command = Console.ReadLine().ToLower();

            switch (command)
            {
                case "push":
                    Console.Write("Sayı: ");
                    if (int.TryParse(Console.ReadLine(), out int number))
                    {
                        stack.Push(number);
                        Console.WriteLine("Stack yapısı oluşturuldu, ilk eleman stack'e eklendi.");
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz giriş!");
                    }
                    break;

                case "pop":
                    if (stack.Count > 0)
                    {
                        Console.WriteLine("Çıkarılan eleman: " + stack.Pop());
                    }
                    else
                    {
                        Console.WriteLine("Stack boş!");
                    }
                    break;

                case "print":
                    if (stack.Count > 0)
                    {
                        Console.WriteLine("Stack içeriği: " + string.Join(", ", stack));
                    }
                    else
                    {
                        Console.WriteLine("Stack boş!");
                    }
                    break;

                case "top":
                    if (stack.Count > 0)
                    {
                        Console.WriteLine("En üstteki eleman: " + stack.Peek());
                    }
                    else
                    {
                        Console.WriteLine("Stack boş!");
                    }
                    break;

                case "exit":
                    return;

                default:
                    Console.WriteLine("Geçersiz komut!");
                    break;
            }
        }
    }
}
