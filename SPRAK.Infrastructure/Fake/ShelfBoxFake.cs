using SPRAK.Domain.Entity;
using SPRAK.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Infrastructure.Fake
{
    internal sealed class ShelfBoxFake : IShelfBoxRepository
    {
        public void AddNewBox(BoxDataEntity boxDataEntity)
        {
            throw new NotImplementedException();
        }

        public List<BoxDataEntity> GetBoxAll()
        {
            var list = new List<BoxDataEntity>();
            list.Add(new BoxDataEntity(1, 1, "C2P-1", "1-1", "SL1001-100"));
            list.Add(new BoxDataEntity(2, 1, "C2P-2", "1-2", "SL1002-100"));
            list.Add(new BoxDataEntity(3, 1, "C2P-3", "1-3", "SL1003-100"));
            list.Add(new BoxDataEntity(4, 1, "C2P-4", "1-4", "SL1004-100"));
            list.Add(new BoxDataEntity(5, 1, "C2P-5", "1-5", "SL1005-100"));

            return list;
        }

        public int GetLatestBoxId()
        {
            return 10;
        }

        public List<ShelfDataEntity> GetSheflAll()
        {
            var list = new List<ShelfDataEntity>();
            list.Add(new ShelfDataEntity(1, "棚1", "棚1番地", 1));
            list.Add(new ShelfDataEntity(2, "棚2", "棚2番地", 2));
            list.Add(new ShelfDataEntity(3, "棚3", "棚3番地", 3));
            list.Add(new ShelfDataEntity(4, "棚4", "棚4番地", 4));
            return list;
        }
    }
}
