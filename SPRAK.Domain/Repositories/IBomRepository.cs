using SPRAK.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Domain.Repositories
{
    public interface IBomRepository
    {
        List<BomEntity> GetBoms(string AssyNO);
        void SaveBom(int id, int ReceivedQuantity);
    }
}
