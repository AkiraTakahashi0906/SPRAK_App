﻿using SPRAK.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Domain.Repositories
{
    public interface IPartsListRipository
    {
        IReadOnlyList<PartsListEtity> GetPartsList(int sqkId);
        void Save(PartsListEtity partsData);
        void Delete(PartsListEtity partsData);
    }
}
