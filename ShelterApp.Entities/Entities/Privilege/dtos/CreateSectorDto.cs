using ShelterApp.Core.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Entities.Entities.Privilege.dtos
{
    public class CreatePrivilegeDto : FullEntityDto
    {
        public string PrivilegeName { get; set; }
        public string TextInPicture { get; set; }
        public string Photo { get; set; }
    }
}
