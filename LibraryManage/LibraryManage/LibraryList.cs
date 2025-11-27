using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManage
{
    internal class LibraryList
    {
        public List<Library> Kitaplar = new List<Library>();


        public void KitapEkle()
        {
            Console.Write("Eklemek istediğiniz kitabı giriniz ");
            string kitapisim = Console.ReadLine();


            Console.Write("Girdiğiniz kitabin yazarini giriniz : ");
            string yazargiris = Console.ReadLine();

            bool KitapDenetim = Kitaplar.Any(x => x.Isim.Equals(kitapisim, StringComparison.OrdinalIgnoreCase) && x.Yazar.Equals(yazargiris, StringComparison.OrdinalIgnoreCase));
            if (KitapDenetim)
            {
                Console.WriteLine("Ekletmek istediğiniz kitap zaten bulunmaktadır ");
                return;
            }


            Kitaplar.Add(new Library(kitapisim, yazargiris));
            Console.WriteLine("Kitap eklenmistir ");
        }
        public void KitapSorgular()
        {
            Console.Write("Aratmak istediğiniz kitabin ismini girin : ");
            string arat = Console.ReadLine();
            var kitaparat = Kitaplar.Where(x => x.Isim.Contains(arat, StringComparison.OrdinalIgnoreCase));
            bool kitapbulundumu = false;
            foreach(var kitap in kitaparat)
            {
                Console.WriteLine($"Kitap ismi : {kitap.Isim}  -- Yazar : {kitap.Yazar}");
                kitapbulundumu = true;
            }
            if (!kitapbulundumu)
            {
                Console.WriteLine("Aradiğiniz kitap bulunmamaktadır");
            }
        }


        public void BilgiDegisim()
        {
            Console.WriteLine("Bilgisini degistirmek istediginiz kitabin ismini ve yazarini giriniz");
            Console.Write("Kitap isim : ");
            string kitapisim = Console.ReadLine();
            Console.Write("Yazar giris : ");
            string yazarisim = Console.ReadLine();
            bool KitapDenetim = Kitaplar.Any(x => x.Isim.Equals(kitapisim, StringComparison.OrdinalIgnoreCase) &&  x.Yazar.Equals(yazarisim, StringComparison.OrdinalIgnoreCase));

            if (!KitapDenetim)
            {
                Console.WriteLine("Kütüphanemizde arattiginiz kitap bulunmamaktadir");
                return;
            }

            var kitap = Kitaplar.FirstOrDefault(x =>
        x.Isim.Equals(kitapisim, StringComparison.OrdinalIgnoreCase) &&
        x.Yazar.Equals(yazarisim, StringComparison.OrdinalIgnoreCase));


            Console.WriteLine("Degistirmek istediginiz kisimda bilgi girin degistirmek istemiyorsaniz 'q' tusuna basmanız yeterli");
            Console.Write("Yeni isim giris : ");
            string yenikitapisim = Console.ReadLine();
            Console.Write("Yeni yazar giris : ");
            string yeniyazar = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(yenikitapisim) && yenikitapisim.ToLower() != "q")
                kitap.Isim = yenikitapisim;

            if (!string.IsNullOrWhiteSpace(yeniyazar) && yeniyazar.ToLower() != "q")
                kitap.Yazar = yeniyazar;

            Console.WriteLine("Bilgiler başarıyla güncellendi!");



        }



        public void KitapGoster()
        {
            var kitaplistesi = Kitaplar.OrderBy(x => x.Isim);
            foreach(var kitaplar in kitaplistesi)
            {
                Console.WriteLine($"Kitap isim : {kitaplar.Isim} -- Yazar : {kitaplar.Yazar}");
            }

        }









        }
    }
