﻿using ShelterApp.Core.Repositories.EntityFrameworkCore;
using ShelterApp.Entities.Entities.Privilege;
using ShelterApp.Entities.Entities.Sector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Privilege
{
    public interface IPrivilegeRepository : IEfCoreRepository<TBL_Privilege>
    {
    }
}
