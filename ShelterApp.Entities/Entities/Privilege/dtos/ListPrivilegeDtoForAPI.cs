using ShelterApp.Core.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Entities.Entities.Privilege.dtos
{
    public class ListPrivilegeDtoForAPI : FullEntityDto
    {
        public List<ListPrivilegeDto> TR { get; set; }
        public List<ListPrivilegeDto> GB { get; set; }
        public List<ListPrivilegeDto> RU { get; set; }
    }
}
