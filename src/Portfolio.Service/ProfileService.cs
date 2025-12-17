using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Interface;
using Portfolio.Model;

namespace Portfolio.Service;

public class ProfileService : IProfileService
{
    private readonly AppDbContext _context;

    public ProfileService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Profile>> GetAllAsync()
        => await _context.Profiles.AsNoTracking().ToListAsync();

    public async Task<Profile?> GetByIdAsync(int id)
        => await _context.Profiles.FindAsync(id);

    public async Task<Profile> CreateAsync(Profile profile)
    {
        _context.Profiles.Add(profile);
        await _context.SaveChangesAsync();
        return profile;
    }

    public async Task<Profile?> UpdateAsync(Profile profile)
    {
        var existing = await _context.Profiles.FindAsync(profile.Id);
        if (existing == null)
            return null;

        existing.FullName = profile.FullName;
        existing.Title = profile.Title;
        existing.Summary = profile.Summary;
        existing.Location = profile.Location;

        await _context.SaveChangesAsync();
        return existing; // ✅
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var profile = await _context.Profiles.FindAsync(id);
        if (profile == null)
            return false;

        _context.Profiles.Remove(profile);
        await _context.SaveChangesAsync();
        return true;
    }
}
