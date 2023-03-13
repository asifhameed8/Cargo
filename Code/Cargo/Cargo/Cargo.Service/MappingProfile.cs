using AutoMapper;
using Cargo.Models.Entities;
using Cargo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shipper, ShipperVM>();
        }
    }
}
