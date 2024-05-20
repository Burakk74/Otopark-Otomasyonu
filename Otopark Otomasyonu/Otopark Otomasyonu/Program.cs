using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otopark_Otomasyonu
{
    class Araç
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Renk { get; set; }
        public string yer {  get; set; }
    }



    internal class Program
    {

        static List<Araç> araclar = new List<Araç>();
        static int otoparkKapasite = 10;
        
        static void Main(string[] args)
        {
            string arac_plaka;

            while (true)
            {
                Console.WriteLine("\n----------- MENÜ -----------");
                Console.WriteLine("1. Araç Ekle");
                Console.WriteLine("2. Araç Çıkar");
                
                Console.WriteLine("3. Tüm Araçları Listele");
                Console.WriteLine("4. Boş Park Yeri Kontrolü");
                Console.WriteLine("5. Araç Yeri Sorgula");
                Console.WriteLine("6. Çıkış");

                Console.Write("Seçiminizi yapınız: ");
                int secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        AracEkle();
                        break;
                    case 2:
                        AracCikar();
                        break;
                    case 3:
                        TumAraclariListele();
                        break;
                    case 4:
                        BosParkYeriKontrolu();
                        break;
                    case 5:
                       Console.WriteLine("Araç plakasını giriniz: ");
                       arac_plaka = Console.ReadLine();
                        konum_bul(arac_plaka);
                        break;
                        case 6:
                        Environment.Exit(0);
                        break;
                    default:

                        Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                        break;
                }
            }
        }

        // Araç yerini bulmak için kullanılan fonksiyon

        static void konum_bul(string plaka)
        {
            Araç arac = araclar.Find(a => a.Plaka == plaka);

            if (arac != null)
            {
                 
                Console.WriteLine(plaka + $" plakalı aracın konumu: {arac.yer} " );
            }
            else
            {
                Console.WriteLine("Araç bulunamadı.");
            }
        }

        // Araç eklemek için kullanılan fonksiyon
        static void AracEkle()
        {
            if (araclar.Count < otoparkKapasite)
            {
                Araç yeniArac = new Araç();

                Console.Write("Araç plakasını giriniz: ");
                yeniArac.Plaka = Console.ReadLine();

                Console.Write("Araç markasını giriniz: ");
                yeniArac.Marka = Console.ReadLine();

                Console.Write("Araç modelini giriniz: ");
                yeniArac.Model = Console.ReadLine();

                Console.Write("Araç rengini giriniz: ");
                yeniArac.Renk = Console.ReadLine();

                Console.Write("Aracın park konumunu giriniz: ");
                yeniArac.yer = Console.ReadLine();

                araclar.Add(yeniArac);
                Console.WriteLine("Araç başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Otopark dolu, araç eklenemiyor.");
            }
        }

        // Araç çıkarmak için kullanılan fonksiyon
        static void AracCikar()
        {
            if (araclar.Count > 0)
            {
                Console.Write("Çıkarmak istediğiniz aracın plakasını giriniz: ");
                string cikarmaPlaka = Console.ReadLine();
                Araç cikacakArac = araclar.Find(a => a.Plaka == cikarmaPlaka);

                if (cikacakArac != null)
                {
                    araclar.Remove(cikacakArac);
                    Console.WriteLine("Araç başarıyla çıkarıldı.");
                }
                else
                {
                    Console.WriteLine("Araç bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine("Otopark boş, araç çıkaramazsınız.");
            }
        }
        //araçları listelemek için kullanılan fonksiyon
        static void TumAraclariListele()
        {
            Console.WriteLine("\n----- TÜM ARAÇLAR -----");
            foreach (var arac in araclar)
            {
                Console.WriteLine($"Plaka: {arac.Plaka}, Marka: {arac.Marka}, Model: {arac.Model}, Renk: {arac.Renk} ");
            }
        }
       
        // Boş park yerlerini kontrol etmek için kullanılan fonksiyon
        static void BosParkYeriKontrolu()
        {
            if (araclar.Count < otoparkKapasite)
            {
                Console.WriteLine("Otoparkta boş yer var.");
            }
            else
            {
                Console.WriteLine("Otopark dolu.");
            }
        }






















    }
}
