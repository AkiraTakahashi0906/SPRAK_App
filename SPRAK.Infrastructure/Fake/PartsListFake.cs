using SPRAK.Domain.Entity;
using SPRAK.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Infrastructure.Fake
{
    internal sealed class PartsListFake : IPartsListRipository
    {
        public void Delete(PartsListEtity partsData)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<PartsListEtity> GetPartsList(int sqkId)
        {
            var lists = new List<PartsListEtity>();

            lists.Add(new PartsListEtity(1,12345, "test1", "tessft1", 1));
            lists.Add(new PartsListEtity(2,12345, "test2", "tesfst2", 2));
            lists.Add(new PartsListEtity(3,12345, "testfsf3", "test3", 3));
            lists.Add(new PartsListEtity(3, 12345, "test354", "test3", 3));
            lists.Add(new PartsListEtity(3, 12345, "test3", "te545st3", 3));
            lists.Add(new PartsListEtity(3, 12345, "tesfasft3", "test3", 3));

            return lists;
        }

        public void Save(PartsListEtity partsData)
        {
            throw new NotImplementedException();
        }
    }
}
