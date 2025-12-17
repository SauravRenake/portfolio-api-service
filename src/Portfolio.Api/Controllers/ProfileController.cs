using Microsoft.AspNetCore.Mvc;
using Portfolio.Interface;
using Portfolio.Model;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/profile")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _service;

    public ProfileController(IProfileService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var profile = await _service.GetByIdAsync(id);
        return profile == null ? NotFound() : Ok(profile);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Profile profile)
    {
        var created = await _service.CreateAsync(profile);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Profile profile)
    {
        if (id != profile.Id)
            return BadRequest("ID mismatch");

        var updated = await _service.UpdateAsync(profile);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
