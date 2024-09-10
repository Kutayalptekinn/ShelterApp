using ShelterApp.Core.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Entities.Entities.Product.dtos
{
    public class UpdateProductDto:FullEntityDto
    {
        public string Baslik { get; set; }
        public string UstBaslik { get; set; }
        public string Isim { get; set; }
        public string Detay { get; set; }
        public string Icerik { get; set; }
        public string FrontPhoto { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Language { get; set; }

    }
}
