using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var keycloak = builder.AddKeycloak("keycloak", 6001)
    .WithDataVolume("keycloak-data");

var postgres = builder.AddPostgres("postgres", port: 5432)
    .WithDataVolume("postgres-data")
    .WithPgAdmin();

var podDb = postgres.AddDatabase("post-db");


var podService = builder.AddProject<PostService>("post-svc")
    .WithReference(keycloak)
    .WithReference(podDb)
    .WaitFor(keycloak)
    .WaitFor(podDb);


builder.Build().Run();