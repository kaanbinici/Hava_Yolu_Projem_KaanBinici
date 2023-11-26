namespace Hava_Yolu_Projem_KaanBinici
{
    namespace ConsoleApp11
    {
        internal class Program
        {
            static string[] business = { "", "", "", "", "", "", "", "", "", "", "", "" };
            static string[] economy = { "", "", "", "", "", "", "", "", "", "", "", "", };
            static int koltuksecim, businesssayac = 0, economysayac = 0;
            static string isim, tus;
            static void Main(string[] args)
            {
                AnaMenu();
                IsimAl();
                KoltukKontrol();
                Rezervasyon();
                Main(null);
                Console.ReadLine();
            }
            private static void KoltukKontrol()
            {
                if (tus == "1") BusinessKoltukKontrol();
                else EconomyKoltukKontrol();

            }

            static void Rezervasyon()
            {
                try
                {
                    Console.WriteLine("İstediğiniz koltuğu seçiniz");
                    koltuksecim = Convert.ToInt32(Console.ReadLine());

                    if (tus == "1")
                    {
                        if (business[koltuksecim - 1] == "")
                        {
                            business[koltuksecim - 1] = isim;
                            businesssayac++;


                        }
                        else
                        {
                            Console.WriteLine($"{koltuksecim}. koltuk daha önce {business[koltuksecim - 1]} kişi tarafından rezerve edilmiştir");
                            Rezervasyon();
                        }

                    }
                    else
                    {
                        if (economy[koltuksecim - 1] == "")
                        {
                            economy[koltuksecim - 1] = isim;
                            economysayac++;


                        }
                        else
                        {
                            Console.WriteLine($"{koltuksecim}. koltuk daha önce {economy[koltuksecim - 1]}kişi tarafından rezerve edilmiştir");
                            Rezervasyon();
                        }
                        KoltukKontrol();

                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Olmayan koltuk seçimi");
                    Rezervasyon();


                }
                catch (FormatException)
                {
                    Console.WriteLine("Koltuk sayısını doğru formatta girmediniz");
                    Rezervasyon();

                }

            }

            private static void EconomyKoltukKontrol()
            {
                for (int i = 0; i < economy.Length; i++)
                {
                    Console.WriteLine(economy[i] == "" ? $"{i + 1}. koltuk boş" : $"{i + 1}. koltuk {business[i]} tarafından dolu.");
                }
                Console.WriteLine(economysayac == economy.Length ? "Uçuşumuz dolmuştur" : "Yerimiz Mevcuttur.");


            }

            private static void BusinessKoltukKontrol()
            {
                for (int i = 0; i < business.Length; i++)
                {
                    Console.WriteLine(business[i] == "" ? $"{i + 1}. koltuk boş" : $"{i + 1}. koltuk {business[i]} tarafından dolu.");
                }
                Console.WriteLine(businesssayac == business.Length ? "Uçuşumuz dolmuştur" : "Yerimiz Mevcuttur.");
            }



            private static void IsimAl()
            {
                Console.WriteLine("Lütfen Adınızı Giriniz");
                isim = Console.ReadLine();
                for (int i = 0; i < isim.Length; i++)
                {
                    if (char.IsDigit(isim[i]))
                    {
                        Console.WriteLine("Sayısal karakter girmeyiniz");
                        IsimAl();

                    }

                }



            }

            private static void AnaMenu()
            {
                Console.WriteLine("***************************Kaan Binici Hava Yollarına Hoş Geldiniz****************************");
                if (economysayac != economy.Length && businesssayac != business.Length)
                {
                    Console.WriteLine("Business Class bölümü için 1 tuşuna basınız");
                    Console.WriteLine("Economy Class bölümü için 2 tuşuna basınız");
                }
                else if (economysayac == economy.Length && businesssayac != business.Length)
                {
                    Console.WriteLine("Business Class bölümü için 1 tuşuna basınız");

                }
                else if (economysayac != economy.Length && businesssayac == business.Length)
                {
                    Console.WriteLine("Economy Class bölümü için 2 tuşuna basınız");
                }
                else
                {
                    Console.WriteLine("Tüm uçuşlarımız dolmuştur.İlginiz için teşekkür ederim");
                    Cikis();
                }

                tus = Console.ReadLine();
                switch (tus)
                {
                    case "1": break;
                    case "2": break;
                    default:
                        Console.WriteLine("Lütfen geçerli bir seçim giriniz");
                        AnaMenu();
                        break;


                }

            }
            private static void Cikis()
            {
                Console.WriteLine("Seçilecek koltuk kalmadı. çıkmak için exit yazınız");
                string cevap = Console.ReadLine().ToLower();
                if (cevap == "exit") Environment.Exit(0);

            }

        }
    }
}