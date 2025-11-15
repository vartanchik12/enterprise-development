var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddMongoDB("mongo").AddDatabase("db");

builder.AddProject<Projects.Hospital_Api_Host>("hospital-api-host")
    .WithReference(db, "hospital")
    .WaitFor(db);

builder.Build().Run();