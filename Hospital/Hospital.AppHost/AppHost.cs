var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddMongoDB("mongo").AddDatabase("db");

var rabbitMqQueue = builder.AddParameter("RabbitMQQueue");
var rabbitUserName = builder.AddParameter("RabbitMQLogin");
var rabbitPassword = builder.AddParameter("RabbitMQPassword");
var rabbitMq = builder.AddRabbitMQ("hospital-rabbitmq", userName: rabbitUserName, password: rabbitPassword)
    .WithManagementPlugin();

builder.AddProject<Projects.Hospital_Api_Host>("hospital-api-host")
    .WithReference(db, "hospital")
    .WithReference(rabbitMq)
    .WithEnvironment("RabbitMq:QueueName", rabbitMqQueue)
    .WaitFor(db)
    .WaitFor(rabbitMq);

builder.AddProject<Projects.Hospital_Generator_RabbitMq_Host>("hospital-generator-rabbitmq-host")
    .WithReference(rabbitMq)
    .WaitFor(rabbitMq)
    .WithEnvironment("RabbitMq:QueueName", rabbitMqQueue);

builder.Build().Run();