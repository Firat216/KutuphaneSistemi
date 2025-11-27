using System.Text.Json;

namespace LibraryManage
{
    internal class Program
    {
        static void Main(string[] args)
            {
                string dosyayolu = @"C:\Dosyalar\json";
                Directory.CreateDirectory(dosyayolu);
                string klasoryolu = Path.Combine(dosyayolu, "Kutuphanesistem.json");

                LibraryList Kitaplar = new LibraryList();


                if (File.Exists(klasoryolu))
                {
                    string mevcutJson = File.ReadAllText(klasoryolu);
                    if (!string.IsNullOrWhiteSpace(mevcutJson))
                        Kitaplar.Kitaplar = JsonSerializer.Deserialize<List<Library>>(mevcutJson);

                }
            
                bool dongu = false;
                while (!dongu) 
                { 
                Console.WriteLine("Kitap eklemek icin -- 1 ");
                Console.WriteLine("Kitap aratmak icin -- 2");
                    Console.WriteLine("Kitap Bilgi degisim icin -- 3");
                Console.WriteLine("Kitap Listesi icin -- 4");
                Console.WriteLine("Cıkıs yapmak icin -- 5");

                int secim = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (secim)
                    {
                        case 1:
                            Kitaplar.KitapEkle();
                        File.WriteAllText(klasoryolu, JsonSerializer.Serialize(Kitaplar.Kitaplar, new JsonSerializerOptions { WriteIndented = true }));

                        break;
                        case 2: 
                            Kitaplar.KitapSorgular();

                        break;

                        case 3:
                            Kitaplar.BilgiDegisim();
                        File.WriteAllText(klasoryolu, JsonSerializer.Serialize(Kitaplar.Kitaplar, new JsonSerializerOptions { WriteIndented = true }));

                        break;
                        case 4:
                            Kitaplar.KitapGoster();
                            break;
                        case 5:
                            dongu = true;
                            break;
                    }
                }
            
  






        }
    }
}
