using ShelterApp.Core.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Entities.Entities.Product.dtos
{
    public class ListProductDtoForAPI : FullEntityDto
    {
        public List<ListProductDto> TR { get; set; }
        public List<ListProductDto> GB { get; set; }
        public List<ListProductDto> RU { get; set; }
    }
}
