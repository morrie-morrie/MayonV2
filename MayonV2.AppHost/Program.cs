var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Mayon_Blazor>("mayon-blazor");

builder.Build().Run();
