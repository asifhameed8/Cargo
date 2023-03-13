using Cargo.Core.Repositories;
using Cargo.Models.Entities;
using Cargo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Service.ShipperSrv
{
    public interface IShipperService
    {
        IGenericRepository<Shipper> GetRepository();
        IEnumerable<ShipperVM> GetAllShipper();
        IEnumerable<sp_Shipper_Shipment_Details> GetShipperDetails(int ShipperId);
    }
}
