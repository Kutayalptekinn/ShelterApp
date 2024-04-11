using ShelterApp.Core.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Entities.Entities.Blog
{
    public class TBL_Blog: FullEntity
    {
        public string Baslik { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public byte[] Foto { get; set; }
        public string Yazar { get; set; }
        public DateTime Tarih { get; set; }
    }
}
