using SPRAK.Domain.Entity;
using SPRAK.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Infrastructure.Fake
{
    internal sealed class SqkFake : ISqkDataRepository
    {
        public SqkEntity GetSqkData(int sqkId)
        {
            return new SqkEntity(sqkId, "ID:" +sqkId + " test-test-test");
        }
    }
}
