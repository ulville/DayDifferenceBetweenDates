using System;

namespace DayDifferenceBetweenDates
{
    class Program
    {
        //artık yıl olmayan bir yıl için her aya göre yılbaşından o ay başına kadar olan gün sayıları
        static int[] ayaKadarGunSayisi = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
        //artık bir yıl için her aya göre yılbaşından o ay başına kadar olan gün sayıları
        static int[] ayaKadarGunSayisiArtikYil = { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335 };

        static void Main(string[] args)
        {
            //kullanıcıdan iki tarih girmesini istiyoruz
            Console.WriteLine("1. Tarihi giriniz");
            Console.WriteLine("Gün:");

            //Console.ReadLine() fonksiyonu string döndürür.
            //String ile işlem yapamayacağımız için
            //değişkenleri int'e çevirmemiz gerekiyor
            int g1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ay:");
            int a1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Yıl:");
            int y1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("2. Tarihi giriniz");
            Console.WriteLine("Gün:");
            int g2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ay:");
            int a2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Yıl:");
            int y2 = Int32.Parse(Console.ReadLine());

            // 01.01.0001 tarihini başlangıç kabul edip girdiğimiz iki tarihten
            // ayrı ayrı bu tarihe kadar olan gün sayılarını hesaplıyoruz.
            int toplamGun1 = ToplamGunSayisi(y1, a1, g1);
            int toplamGun2 = ToplamGunSayisi(y2, a2, g2);

            Console.Write("Tarihler arasındaki gün farkı: ");
            //  hesapladığımız iki gün sayısı arasındaki fark bize
            //  girdiğimiz iki tarih arasındaki gün farkını verir
            //  gün sayısı negatif çıkmasın diye iki sayıyı karşılaştırıp
            //  ona göre çıkarma işlemi yapıyoruz
            if (toplamGun1 > toplamGun2)
            {
                Console.WriteLine(toplamGun1 - toplamGun2);
            }
            else
            {
                Console.WriteLine(toplamGun2 - toplamGun1);
            }

            Console.WriteLine("Bitirmek için ENTER");
            Console.ReadLine();
        }

        static int ToplamGunSayisi(int yil, int ay, int gun)
        {
            if (ArtikYil(yil)) // girilen yıl artık yıl ise
            {
                // 01.01.0001 tarihinden bizim girdiğimiz tarihe
                // kadar olan gün sayısını böyle hesaplıyoruz

                yil--; // girilen yıl tamamlanmadığı için hesapta bir önceki yılı kullanacağız

                // 4'e tam bölünen 100'e bölünmeyen ama 400'e bölünen yıllar artık yıldır
                int artikYilSayisi = yil / 4 - yil / 100 + yil / 400;

                //  artık yıllar olmasa yılbaşına kadar olan gün sayısı yıl*365 olurdu
                //  her artık yıl bunun üzerine 1 gün daha ekler
                //  yılbaşından aybaşına olan gün sayısını da başta tanımladığımız array ile buluyoruz
                //  bunun üzerine de girilen gün değerini ekliyoruz
                //  başlangıç kabul ettiğimiz tarih 01.01.0001 olduğu için bir gün düşüyoruz
                return yil * 365 + artikYilSayisi + ayaKadarGunSayisiArtikYil[ay - 1] + gun - 1;
            }
            else // artık yıl değilse
            {
                //  üsttekinin aynısı sadece bu sefer artık olmayan
                //  yıllara ait ayaKadarGunSayisi'nı kullanıyoruz
                yil--;
                int artikYilSayisi = yil / 4 - yil / 100 + yil / 400;
                return yil * 365 + artikYilSayisi + ayaKadarGunSayisi[ay - 1] + gun - 1;
            }
        }

        static bool ArtikYil(int yil)
        {
            //  girilen yılın artık yıl olup olmadığını kontrol ediyoruz
            //  Bir yıl 4'e tam bölünüyor ama 100'e tam bölünMüyorsa artık yıldır
            //  İstisna olarak 400'e tam bölünen yıllar da artık yıldır
            //  Örneğin 1996 yılı ve 2000 yılı artık yıldır ama 1900 yılı artık yıl değildir
            //  2100 yılı da artık yıl olmayacaktır ama 2400 yılı artık yıldır
            return (yil % 4 == 0) && ((yil % 100 != 0) || (yil % 400 == 0));
        }
    }
}
