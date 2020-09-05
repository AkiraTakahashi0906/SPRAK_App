using SPRAK.Domain.Repositories;
using SPRAK.Infrastructure.Fake;
using SPRAK.Infrastructure.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Infrastructure
{
    public static class Factories
    {
        public static ISqkDataRepository CreateSqkData()
        {
            return new SqkFake();
        }

        public static IPartsListRipository CreatePartsList()
        {
            //return new PartsListFake();
            return new PartsListSQLServer();
        }

    }
}
