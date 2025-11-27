using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManage
{
    internal class Library
    {
        public string Isim { get; set; }
        public string Yazar { get; set; }

        public Library(string isim, string yazar)
        {
            Isim = isim;
            Yazar = yazar;
        }
    }
}
