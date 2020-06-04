using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TheShihan.Portal.Web.Scheduling;
using OrchardCore.ContentManagement;
using OrchardCore.Environment.Shell;
using OrchardCore.BackgroundTasks;
using System.Threading;

namespace TheShihan.Portal.Web.Synchronization
{
    [BackgroundTask(Schedule = "*/1 * * * *", Description = "Importing projects.")]
    public class ProjectImportBackgroundTask : IBackgroundTask
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        public ProjectImportBackgroundTask(ILogger<ProjectImportBackgroundTask> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public Task DoWorkAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting scheduled import of projects @ " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));

            //var projects = ProjectHanlder.FetchProjectsFromExternalAPI(...);

            var contentManager = serviceProvider.GetService<IContentManager>();

            // foreach (var project in projects)
            // {
            //     // Create content item for each project from external API
            //     // var newProject = contentManager.NewAsync("Project");
            //     // ...
            // }

            return Task.CompletedTask;
        }

    }
}