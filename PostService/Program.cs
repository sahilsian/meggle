using CommunityService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.AddServiceDefaults();
builder.Services.AddAuthentication()
    .AddKeycloakJwtBearer(serviceName: "keycloak", realm: "meggle", options =>
    {
        options.RequireHttpsMetadata = false;
        options.Audience = "meggle";
    });
builder.AddNpgsqlDbContext<PostDbContext>("postDb");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.MapDefaultEndpoints();

app.Run();
