using ShelterApp.Core.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Entities.Entities.Sector
{
    public class TBL_Service : FullEntity
    {
        public string ServiceName { get; set; }
        public string TextInPicture { get; set; }
        public string HeaderText { get; set; }
        public string ContentText { get; set; }
        public byte[] Foto { get; set; }
    }
}
