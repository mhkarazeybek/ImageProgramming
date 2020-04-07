using System;
using System.Linq;

namespace GoldbachTheoremAnd2Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstSpaces = "";
            string secoundSpaces = "";
            int c = 0;
            int d = 1;

            #region SekmeDeseni
            void SekmeDeseni()
            {
                Console.WriteLine("************************************");
                Console.WriteLine("\tSekme Deseni");
                Console.WriteLine("************************************\n");
                //Height ve Width değerlerini klavyeden alıp int tipindeki h ve w değişkenlerine atama yaptık. Convert.ToInt32() fonksiyonu ile kullanıcıdan aldığımız değerleri int tipine dönüştürdük.
                Console.Write("Height: ");
                int h = Convert.ToInt32(Console.ReadLine());
                Console.Write("Width: ");
                int w = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                w = w - 1;
                c = 0;
                d = 1;
                for (int i = 0; i < h; i++)
                {
                    // satırın başına | işaretini koyup Enumerable.Repeat() fonksiyonu ile " " değerini 2. parametre(c ve w-c) kadar tekrarlatıp string.join() fonksiyonu "" ile birleştirmesini yapıp firstSpaces ve secoundSpaces değişkenlerine atadık.
                    Console.Write("|");
                    firstSpaces = string.Join("", Enumerable.Repeat(" ", c).ToArray());
                    secoundSpaces = string.Join("", Enumerable.Repeat(" ", (w - c)).ToArray());
                    Console.Write(firstSpaces + "*" + secoundSpaces);
                    Console.Write("|\n");
                    //d değişkeni ile yönü kontrol edip c değeri değiştirdik
                    if (w > c && d == 1)
                        c++;
                    else
                        c--;
                    if (c == 0 || c == w)
                        d = -d;
                }
                Console.WriteLine();
            }

            #endregion

            #region GoldbachTeo
            void GoldbachTeo()
            {
                Console.WriteLine("************************************");
                Console.WriteLine("\tGoldbach Teoremi");
                Console.WriteLine("************************************\n");
                //2k = p1 + p2 + p3 – 1
                void Goldbach(int n)
                {
                    //Gelen değerin 2 den küçük ve ya tek sayı olma durumu için hata mesajı bastırdık. Arkaplan rengini kırmızı ve yazı renginide beyaz tanımladık.
                    if (n <= 2 || n % 2 != 0)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("" + n + " is invalid input");
                        return;
                    }
                    //Gelen değerin asal sayı toplamları için kontrolünü sağladık.
                    for (int i = 2; i < n / 2; i++)
                    {
                        if (isPrime(i) && isPrime(n - i))
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("" + n + " = " + i + " + " + (n - i));
                        }
                    }
                }
                //Gelen değerin asal sayı olup olmadığını hesapladık.
                bool isPrime(int n)
                {
                    for (int i = 2; i < n / 2; i++)
                    {
                        if (n % i == 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }

                Console.Write("number: ");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Goldbach(num);
                Console.WriteLine();
            }

            #endregion


            #region BaklavaDeseni
            void BaklavaDeseni()
            {
                Console.WriteLine("************************************");
                Console.WriteLine("\tBaklava Deseni");
                Console.WriteLine("************************************\n");
                firstSpaces = "";
                string character = "";
                Console.Write("n: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                c = n - 1;
                // * karakterini tutan değişken
                int count = 1;
                d = 1;

                for (int i = 0; i < n * 2 - 1; i++)
                {
                    // Enumerable.Repeat() fonksiyonu ile " " ve * karakterini 2. parametre(c ve count) kadar tekrarlatıp string.join() fonksiyonu "" ile birleştirmesini yapıp firstSpaces ve character değişkenlerine atadık.
                    firstSpaces = string.Join("", Enumerable.Repeat(" ", c).ToArray());
                    character = string.Join("", Enumerable.Repeat("*", count).ToArray());
                    Console.WriteLine(firstSpaces + character);
                    //d değişkeni ile satırı kontrol edip c değeri değiştirdik
                    if (n > c && d == 1)
                    {
                        c--;
                        count += 2;
                    }
                    else
                    {
                        c++;
                        count -= 2;
                    }
                    if (c == 0 || c == n)
                        d = -d;
                }
                Console.WriteLine();
            }
            #endregion


            #region Console
            string option = "";

            while (option != "q")
            {
                //Sıyah konsol arkaplanı tanımlaması
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("1: SekmeDeseni\n2: GoldbachTeo\n3: BaklavaDeseni\nq: Quit\n");
                Console.Write("option: ");
                //Değeri
                option = Console.ReadLine();
                //konsol ekranını temizleme
                Console.Clear();
                //Kullanıcıdan alınan değere göre işlem yapan switch case yapısı
                switch (option)
                {
                    case "1":
                        SekmeDeseni();
                        break;
                    case "2":
                        GoldbachTeo();
                        break;
                    case "3":
                        BaklavaDeseni();
                        break;
                    default:
                        break;
                }

            }
            #endregion
        }
    }
}
