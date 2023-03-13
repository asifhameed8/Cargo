using System;
using System.Collections.Generic;

namespace Cargo.Models.Entities
{
    public partial class Shipper
    {
        public Shipper()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int ShipperId { get; set; }
        public string ShipperName { get; set; } = null!;

        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
