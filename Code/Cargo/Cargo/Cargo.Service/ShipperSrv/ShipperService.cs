using AutoMapper;
using Cargo.Core.Repositories;
using Cargo.Models.Entities;
using Cargo.Models.ViewModel;
using Cargo.Service.QuotesSrv;
using Cargo.Service.UOW;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Service.ShipperSrv
{
    public class ShipperService : IShipperService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ShipperService> logger;
        private readonly IMapper _mapper;
        public ShipperService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ShipperService> _logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            logger = _logger;
        }
        public IGenericRepository<Shipper> GetRepository()
        {
            return _unitOfWork.GetRepository<Shipper>();
        }
        public IEnumerable<ShipperVM> GetAllShipper()
        {
            var shipperList = GetRepository().GetAllAsync().Result;
            return _mapper.Map<IEnumerable<ShipperVM>>(shipperList);
        }
        public IEnumerable<sp_Shipper_Shipment_Details> GetShipperDetails(int ShipperId) => _unitOfWork.GetRepository<sp_Shipper_Shipment_Details>()
                 .FromSqlRaw($"sp_Shipper_Shipment_Details @shipper_id = {ShipperId}").Result;
    }
}
