using CommunityService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityService.Data;

public class PostDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Tag>()
            .HasData(
                new Tag
                {
                    Id = "csharp", Name = "C#", Slug = "csharp",
                    Description =
                        "C# is a general-purpose, multi-paradigm programming language encompassing strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines."
                },
                new Tag
                {
                    Id = "dotnet", Name = ".NET", Slug = "dotnet",
                    Description =
                        " .NET is a cross-platform, general-purpose development platform maintained by Microsoft."
                },
                new Tag
                {
                    Id = "aspnetcore", Name = "ASP.NET Core", Slug = "aspnetcore",
                    Description =
                        "ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern cloud-based web applications on Windows, Mac, or Linux."
                },
                new Tag
                {
                    Id = "blazor", Name = "Blazor", Slug = "blazor",
                    Description = "Blazor is a web framework for building interactive client web apps with C# or F#."
                }
            );
    }
}