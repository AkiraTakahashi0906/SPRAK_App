using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Domain.Entity
{
    public sealed  class PartsListEtity
    {
        public PartsListEtity(int id ,int sqkId, string partsNumber , string partsName, int partsQuantity)
        {
            Id = id;
            SqkId = sqkId;
            PartsNumber = partsNumber;
            PartsName = partsName;
            PartsQuantity = partsQuantity;
        }

        public int Id { get; }
        public int SqkId { get; }
        public string PartsNumber { get; }
        public string PartsName { get; }
        public int PartsQuantity { get; }

    }
}
