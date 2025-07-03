var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ExtracttaTest_WebApi>("extracttatest-webapi");

builder.Build().Run();
