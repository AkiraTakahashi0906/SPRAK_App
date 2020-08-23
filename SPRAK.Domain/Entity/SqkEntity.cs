using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Domain.Entity
{
    public sealed class SqkEntity
    {
        public SqkEntity(int sqkId ,string sqkContent)
        {
            SqkId = sqkId;
            SqkContent = sqkContent;
        }
        public int SqkId { get; }
        public string SqkContent { get; }
    }
}
