﻿using SPRAK.Domain.Entity;
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
            list.Add(new BoxDataEntity(1, 1, "C2P-1", "1-1","200A"));
            list.Add(new BoxDataEntity(2, 1, "C2P-2", "1-2", "200B"));
            list.Add(new BoxDataEntity(3, 1, "C2P-3", "1-3", "200C"));
            list.Add(new BoxDataEntity(4, 1, "C2P-4", "1-4", "200D"));
            list.Add(new BoxDataEntity(5, 1, "C2P-5", "1-5", "200E"));

            return list;
        }

        public int GetLatestBoxId()
        {
            return 10;
        }

        public List<ShelfDataEntity> GetSheflAll()
        {
            var list = new List<ShelfDataEntity>();
            list.Add(new ShelfDataEntity(1, "棚A", "棚1番地", 1));
            list.Add(new ShelfDataEntity(2, "棚B", "棚2番地", 2));
            list.Add(new ShelfDataEntity(3, "棚C", "棚3番地", 3));
            list.Add(new ShelfDataEntity(4, "棚D", "棚4番地", 4));
            return list;
        }
    }
}
