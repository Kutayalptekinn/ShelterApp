using ShelterApp.Core.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Entities.Entities.Sector.dtos
{
    public class ListSectorDto : FullEntityDto
    {
        public string SectorName { get; set; }
        public string TextInPicture { get; set; }
        public string HeaderText { get; set; }
        public string ContentText { get; set; }
        public byte[] Photo1 { get; set; }
        public byte[] Photo2 { get; set; }
        public byte[] Photo3 { get; set; }
    }
}
