using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Domain.Entity
{
    public sealed class PyrotechnicEntity
    {
        public PyrotechnicEntity(int number, string partsNumber,DateTime effectiveaDate)
        {
            Number = number;
            PartsNumber = partsNumber;
            EffectiveaDate = effectiveaDate;
        }
        public int Number { get; }
        public string PartsNumber { get; }
        public DateTime EffectiveaDate { get; }
    }
}
