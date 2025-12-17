using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Model;
using Portfolio.Service;
using Xunit;

namespace Portfolio.Tests.Services;

public class ProfileServiceTests
{
    private static AppDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // parallel-safe
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task CreateAsync_ShouldCreateProfile()
    {
        using var context = CreateDbContext();
        var service = new ProfileService(context);

        var profile = new Profile
        {
            FullName = "Sonu Renake",
            Title = "Backend Developer",
            Summary = "ASP.NET Core",
            Location = "India"
        };

        var result = await service.CreateAsync(profile);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Single(context.Profiles);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnProfile()
    {
        using var context = CreateDbContext();
        var service = new ProfileService(context);

        var profile = new Profile
        {
            FullName = "Test",
            Title = "Dev",
            Summary = "Test",
            Location = "IN"
        };

        context.Profiles.Add(profile);
        await context.SaveChangesAsync();

        var result = await service.GetByIdAsync(profile.Id);

        Assert.NotNull(result);
        Assert.Equal(profile.Id, result!.Id);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateProfile()
    {
        using var context = CreateDbContext();
        var service = new ProfileService(context);

        var profile = new Profile
        {
            FullName = "Old Name",
            Title = "Old",
            Summary = "Old",
            Location = "Old"
        };

        context.Profiles.Add(profile);
        await context.SaveChangesAsync();

        profile.FullName = "New Name";

        var updated = await service.UpdateAsync(profile);

        Assert.NotNull(updated);
        Assert.Equal("New Name", updated!.FullName);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveProfile()
    {
        using var context = CreateDbContext();
        var service = new ProfileService(context);

        var profile = new Profile
        {
            FullName = "Delete",
            Title = "Dev",
            Summary = "Test",
            Location = "IN"
        };

        context.Profiles.Add(profile);
        await context.SaveChangesAsync();

        var result = await service.DeleteAsync(profile.Id);

        Assert.True(result);
        Assert.Empty(context.Profiles);
    }
}
