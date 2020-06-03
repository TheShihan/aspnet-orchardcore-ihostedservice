**Example project**

Demonstration of ASP.NET Core project with Orchard Core CMS using a IHostedService background service that runs on a schedule.

Inside the src/TheShihan.Portal.Web/Synchronization/ScheduledProjectsImport.cs a project import could be run, importing data from an external API into Orchard Content Items using the ContentManager.

Currently this does not work, as the ContentManager cannot be retrieved (ContentManager is null).
