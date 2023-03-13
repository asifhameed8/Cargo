using AutoMapper;
using Cargo.Core.Context;
using Cargo.Core.Factory;
using Cargo.Core.Repositories;
using Cargo.Service.HttpClientSrv;
using Cargo.Service.QuotesSrv;
using Cargo.Service.ShipperSrv;
using Cargo.Service.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace Cargo.Service
{
    public static class ServiceModule
    {
        public static void Register(IServiceCollection services)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<IDatabaseContext, DatabaseContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IContextFactory, ContextFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IApiHttpClient, ApiHttpClient>();
            services.AddTransient<IQuotesServices, QuotesServices>();
            services.AddTransient<IShipperService, ShipperService>();
            services.AddHttpClient();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
