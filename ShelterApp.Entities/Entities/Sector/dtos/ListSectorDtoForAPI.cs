using ShelterApp.Core.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Entities.Entities.Sector.dtos
{
    public class ListSectorDtoForAPI : FullEntityDto
    {
        public List<ListSectorDto> TR { get; set; }
        public List<ListSectorDto> GB { get; set; }
        public List<ListSectorDto> RU { get; set; }
    }
}
