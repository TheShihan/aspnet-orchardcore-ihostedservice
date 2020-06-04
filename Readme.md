# Readme - ASP.NET Core with Orchard Core using a scheduled background task

Demonstration of ASP.NET Core project with Orchard Core CMS using the `IBackgroundTask` interface (of Orchard Core) to run a scheduled import in the background.

Inside the `src/TheShihan.Portal.Web/Synchronization/ScheduledProjectsImport.cs` the example project import, using data from an external API is implemented (or better 'implied'), importing the external data into Orchard Content Items using the ContentManager.

Using an `IHostedService` for this scenario does not work, as the ContentManager is not in the same scope as the IHostedService background task.

The `IBackgroundTask` interface is defined as followed:

```
namespace OrchardCore.BackgroundTasks
{
    public interface IBackgroundTask
    {
        Task DoWorkAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken);
    }
}
```

Here is a different short example, from the Lucene Indexing service of Orchard Core:

```
[BackgroundTask(Schedule = "* * * * *", Description = "Update lucene indexes.")]
public class IndexingBackgroundTask : IBackgroundTask
{
    public Task DoWorkAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var indexingService = serviceProvider.GetService<LuceneIndexingService>();
        return indexingService.ProcessContentItemsAsync();
    }
}
```

By the way: yes, this means, that the name of the repo is a "bit" misleading :-)