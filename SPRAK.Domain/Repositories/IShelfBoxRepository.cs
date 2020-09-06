using SPRAK.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Domain.Repositories
{
    public interface IShelfBoxRepository
    {
        List<ShelfDataEntity> GetSheflAll();
        List<BoxDataEntity> GetBoxAll();
        int GetLatestBoxId();
        void AddNewBox(BoxDataEntity boxDataEntity);
    }
}
