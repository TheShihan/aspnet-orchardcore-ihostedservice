using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using System;
using System.Threading.Tasks;

namespace TheShihan.Portal.Web.BackgroundServices
{
    public abstract class ScopedProcessor : PortalBackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ScopedProcessor(IServiceScopeFactory serviceScopeFactory) : base()
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task Process()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                await ProcessInScope(scope.ServiceProvider);
            }
        }

        public abstract Task ProcessInScope(IServiceProvider serviceProvider);
    }
}