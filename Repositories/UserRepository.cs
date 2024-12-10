using Microsoft.EntityFrameworkCore;
using PhotoGalery.Data;
using PhotoGalery.Entities;

namespace PhotoGalery.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
    }
}