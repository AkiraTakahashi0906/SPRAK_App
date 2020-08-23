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
        public IReadOnlyList<PartsListEtity> GetPartsList(int sqkId)
        {
            var lists = new List<PartsListEtity>();

            lists.Add(new PartsListEtity(12345, "test1", "test1", "test1"));
            lists.Add(new PartsListEtity(12345, "test2", "test2", "test2"));
            lists.Add(new PartsListEtity(12345, "test3", "test3", "test3"));

            return lists;
        }
    }
}
