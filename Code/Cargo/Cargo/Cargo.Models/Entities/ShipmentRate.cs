using System;
using System.Collections.Generic;

namespace Cargo.Models.Entities
{
    public partial class ShipmentRate
    {
        public ShipmentRate()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int ShipmentRateId { get; set; }
        public string ShipmentRateClass { get; set; } = null!;
        public string ShipmentRateDescription { get; set; } = null!;

        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
