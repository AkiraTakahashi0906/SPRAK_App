using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Domain.Entity
{
    public sealed class ShelfDataEntity
    {
        public ShelfDataEntity(int shelfd,
                                         string sheifName,
                                         string installationLocation,
                                         int route)
        {
            Shelfd = shelfd;
            ShelfName = sheifName;
            InstallationLocation = installationLocation;
            Route = route;
        }
        public int Shelfd { get; }
        public string ShelfName { get; }
        public string InstallationLocation { get; }
        public int Route { get; }
    }
}
