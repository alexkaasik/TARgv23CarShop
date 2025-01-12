using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using Microsoft.Extensions.Hosting;

using TARgv23CarShop.ApplicationService.Services;
using TARgv23CarShop.Core.ServiceInterface;
using TARgv23CarShop.Data;

using TARgv23CarShop.CarTest.Mock;
using TARgv23CarShop.CarTest.Macros;

namespace TARgv23CarShop.CarTest
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider { get; set; }
        
        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {

        }
        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }

        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<ICarServices, CarServices>();
            services.AddScoped<IHostEnvironment, IMockHostEnvironment>();

            services.AddDbContext<TARgv23CarShopContext>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
            RegisterMacros(services);
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface
                && !x.IsAbstract);

            foreach (var macro in macros)
            {
                {
                    services.AddSingleton(macro);
                }
            }
        }
    }
}
