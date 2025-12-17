using Portfolio.Model;

namespace Portfolio.Interface;

public interface IProfileService
{
    Task<IEnumerable<Profile>> GetAllAsync();
    Task<Profile?> GetByIdAsync(int id);
    Task<Profile> CreateAsync(Profile profile);
    Task<Profile?> UpdateAsync(Profile profile);
    Task<bool> DeleteAsync(int id);
}
