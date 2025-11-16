using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var keycloak = builder.AddKeycloak("keycloak", 6001)
    .WithDataVolume("keycloak-data");

var postgres = builder.AddPostgres("postgres", port: 5432)
    .WithDataVolume("postgres-data")
    .WithPgAdmin();

var communityDb = postgres.AddDatabase("community-db");


var communityService = builder.AddProject<CommunityService>("community-svc")
    .WithReference(keycloak)
    .WithReference(communityDb)
    .WaitFor(keycloak)
    .WaitFor(communityDb);


builder.Build().Run();