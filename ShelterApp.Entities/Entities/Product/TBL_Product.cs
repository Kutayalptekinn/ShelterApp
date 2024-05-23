using ShelterApp.Core.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Entities.Entities.Product
{
    public class TBL_Product:FullEntity
    {
        public string Baslik { get; set; }
        public string Foto { get; set; }
    }
}
