using ShelterApp.Core.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Entities.Entities.Blog.dtos
{
    public class ListBlogDtoForAPI : FullEntityDto
    {
        public List<ListBlogDto> TR { get; set; }
        public List<ListBlogDto> GB { get; set; }
        public List<ListBlogDto> RU { get; set; }
    }
}
