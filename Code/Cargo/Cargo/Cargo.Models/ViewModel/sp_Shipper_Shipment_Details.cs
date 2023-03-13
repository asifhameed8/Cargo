using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Models.ViewModel
{
    public class sp_Shipper_Shipment_Details
    {
        [Key]
        public int ShipmentId { get; set; }
        public string ShipperName { get; set; }
        public string CarrierName { get; set; }
        public string ShipmentDescription { get; set; }
        public decimal ShipmentWeight { get; set; }
        public string ShipmentRateDescription { get; set; }

    }
}
