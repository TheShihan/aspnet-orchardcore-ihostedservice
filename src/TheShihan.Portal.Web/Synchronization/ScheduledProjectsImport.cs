using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TheShihan.Portal.Web.Scheduling;
using OrchardCore.ContentManagement;

namespace TheShihan.Portal.Web.Synchronization
{
    public class ScheduledProjectsImport : ScheduledProcessor
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        public ScheduledProjectsImport(IServiceScopeFactory serviceScopeFactory, ILogger<ScheduledProjectsImport> logger,
            IConfiguration config) : base(serviceScopeFactory)
        {
            _logger = logger;
            _config = config;
        }

        protected override string Schedule => "*/1 * * * *"; // Schedule runs every minute (for testing)

        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            _logger.LogInformation("Starting scheduled import of projects @ " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));

            //var projects = ProjectHanlder.FetchProjectsFromExternalAPI(...);

            try
            {
                var contentManager = serviceProvider.GetService<IContentManager>();
                var newProject = contentManager.NewAsync("Project");
            } catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception occured while getting Content manager");
            }
            

            // foreach (var project in projects)
            // {
            //     // ...
            // }

            return Task.CompletedTask;
        }
    }
}