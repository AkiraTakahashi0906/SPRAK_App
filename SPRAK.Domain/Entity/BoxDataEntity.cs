using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Domain.Entity
{
    public sealed class BoxDataEntity
    {
        public BoxDataEntity(int boxId,
                                        int shelfId,
                                        string boxBarcodeText,
                                        string boxInstallationLocation,
                                        string boxName)
        {
            BoxId = boxId;
            ShelfId = shelfId;
            BoxBarcodeText = boxBarcodeText;
            BoxInstallationLocation = boxInstallationLocation;
            BoxName = boxName;
        }
        public int BoxId { get; }
        public int ShelfId { get; }
        public string BoxBarcodeText { get; }
        public string BoxInstallationLocation { get; }
        public string BoxName { get; }
    }
}
