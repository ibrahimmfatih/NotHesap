using System;

class Program
{
    static void Main()
    {
        bool devam = true;

        while (devam)
        {
            Console.WriteLine("Çıkış için 'E'");
            Console.WriteLine("Not hesaplamak için 'H'");
            Console.Write("Lütfen yapmak istediğiniz işlemi seçiniz >> ");

            string secim = Console.ReadLine().ToUpper();

            switch (secim)
            {
                case "E":
                    Console.WriteLine("Programdan çıkılıyor..");
                    devam = false;
                    break;
                case "H":
                    NotHesapla();
                    break;
                default:
                    Console.WriteLine("Geçersiz işlem! Lütfen 'E' veya 'H' giriniz.");
                    break;
            }
        }
    }

    static void NotHesapla()
    {
        Console.Write("Lütfen dersin adını giriniz >> ");
        string dersAdi = Console.ReadLine();

        Console.Write("Lütfen girmek istediğiniz not adedini giriniz >> ");
        int notAdedi;

        while (!int.TryParse(Console.ReadLine(), out notAdedi) || notAdedi <= 0)
        {
            Console.WriteLine("Geçersiz değer! Lütfen pozitif bir tam sayı giriniz.");
            Console.Write("Lütfen girmek istediğiniz not adedini giriniz >> ");
        }

        double toplamNot = 0;
        double toplamYuzde = 0;
        bool yuzdelerGecerli = false;

        while (!yuzdelerGecerli)
        {
            toplamNot = 0;
            toplamYuzde = 0;

            for (int i = 1; i <= notAdedi; i++)
            {
                double not;
                double yuzde;

                Console.Write($"{i}. notunuzu giriniz >> ");
                while (!double.TryParse(Console.ReadLine(), out not) || not < 0 || not > 100)
                {
                    Console.WriteLine("Girilen not 0 ile 100 arasında olmalıdır!");
                    Console.Write($"{i}. notunuzu giriniz >> ");
                }

                double kalanYuzde = 100 - toplamYuzde;

                Console.Write($"{i}. notunuzun yüzdesini giriniz >> ");
                while (!double.TryParse(Console.ReadLine(), out yuzde) || yuzde < 0 || yuzde > kalanYuzde)
                {
                    if (yuzde > kalanYuzde)
                    {
                        Console.WriteLine($"Yüzde değeri {kalanYuzde}’den fazla olamaz!");
                    }
                    else
                    {
                        Console.WriteLine("Yüzde değeri 0'dan küçük olamaz!");
                    }
                    Console.Write($"{i}. notunuzun yüzdesini giriniz >> ");
                }

                toplamNot += (not * yuzde / 100);
                toplamYuzde += yuzde;
            }

            if (toplamYuzde != 100)
            {
                Console.WriteLine("Yüzdeler toplamı 100’e eşit olmalıdır. Tekrar deneyiniz.");
            }
            else
            {
                yuzdelerGecerli = true;
            }
        }

        double notOrtalamasi = toplamNot;
        string harfNotu = HarfNotuHesapla(notOrtalamasi);
        string gecmeDurumu = (notOrtalamasi >= 50) ? "GEÇTİ" : "KALDI";

        Console.WriteLine($"Sonuç: {dersAdi} dersi not ortalamanız {notOrtalamasi:F1} Harf notunuz {harfNotu} Durumunuz {gecmeDurumu}");
    }

    static string HarfNotuHesapla(double notOrtalamasi)
    {
        if (notOrtalamasi >= 90)
            return "AA";
        else if (notOrtalamasi >= 85)
            return "BA";
        else if (notOrtalamasi >= 80)
            return "BB";
        else if (notOrtalamasi >= 75)
            return "CB";
        else if (notOrtalamasi >= 65)
            return "CC";
        else if (notOrtalamasi >= 60)
            return "DC";
        else if (notOrtalamasi >= 55)
            return "DD";
        else if (notOrtalamasi >= 50)
            return "FD";
        else
            return "FF";
    }
}
