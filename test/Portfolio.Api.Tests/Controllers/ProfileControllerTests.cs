using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Controllers;
using Portfolio.Data;
using Portfolio.Model;
using Portfolio.Service;
using Xunit;

namespace Portfolio.Tests.Controllers;

public class ProfileControllerTests
{
    private static ProfileController CreateController()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new AppDbContext(options);
        var service = new ProfileService(context);

        return new ProfileController(service);
    }

    [Fact]
    public async Task GetAll_ShouldReturnOk()
    {
        var controller = CreateController();

        var result = await controller.GetAll();

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Create_ShouldReturnCreatedAtAction()
    {
        var controller = CreateController();

        var profile = new Profile
        {
            FullName = "Sonu",
            Title = "Dev",
            Summary = "API",
            Location = "India"
        };

        var result = await controller.Create(profile);

        var created = Assert.IsType<CreatedAtActionResult>(result);
        var value = Assert.IsType<Profile>(created.Value);

        Assert.Equal(1, value.Id);
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenMissing()
    {
        var controller = CreateController();

        var result = await controller.GetById(999);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Delete_ShouldReturnNoContent()
    {
        var controller = CreateController();

        var profile = new Profile
        {
            FullName = "Delete",
            Title = "Dev",
            Summary = "Test",
            Location = "IN"
        };

        await controller.Create(profile);

        var result = await controller.Delete(1);

        Assert.IsType<NoContentResult>(result);
    }
}
