using ShelterApp.Core.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Entities.Entities.Sector.dtos
{
    public class CreateSectorDto : FullEntityDto
    {
        public string SectorName { get; set; }
        public string TextInPicture { get; set; }
        public string HeaderText { get; set; }
        public string ContentText { get; set; }
        public string FrontPhoto { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
    }
}
