using SPRAK.Domain.Entity;
using SPRAK.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Infrastructure.Fake
{
    internal sealed class BomFake : IBomRepository
    {
        public List<BomEntity> GetBoms(string AssyNO)
        {
            var list = new List<BomEntity>();
            list.Add(new BomEntity(1, 1001, "SL1000", "MS1000", 10, 10,"test"));
            list.Add(new BomEntity(2, 1002, "SL1000", "MS1000", 10, 10,""));
            list.Add(new BomEntity(3, 1003, "SL1000", "MS1000", 10, 10,""));
            list.Add(new BomEntity(4, 1001, "SL2000", "MS1000", 5, 0,""));
            list.Add(new BomEntity(5, 1002, "SL2000", "MS1000", 5, 0,""));
            list.Add(new BomEntity(6, 1003, "SL2000", "MS1000", 5, 0,""));
            return list;
        }

        public void SaveBom(int id, int ReceivedQuantity)
        {
            throw new NotImplementedException();
        }
    }
}
