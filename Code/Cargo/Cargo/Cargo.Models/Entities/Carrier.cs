using System;
using System.Collections.Generic;

namespace Cargo.Models.Entities
{
    public partial class Carrier
    {
        public Carrier()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int CarrierId { get; set; }
        public string CarrierName { get; set; } = null!;
        public string CarrierMode { get; set; } = null!;

        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
