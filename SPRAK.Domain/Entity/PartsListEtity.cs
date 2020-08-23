using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Domain.Entity
{
    public sealed  class PartsListEtity
    {
        public PartsListEtity(int sqkId, string partsNumber , string partsName, string partsQuantity)
        {
            SqkId = sqkId;
            PartsNumber = partsNumber;
            PartsName = partsName;
            PartsQuantity = partsQuantity;

        }

        public int SqkId { get; }
        public string PartsNumber { get; }
        public string PartsName { get; }
        public string PartsQuantity { get; }

    }
}
