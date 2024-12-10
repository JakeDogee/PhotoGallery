using PhotoGalery.Entities;

namespace PhotoGalery.Repositories;

public interface IUserRepository
{
    Task<User> GetByUsernameAsync(string username);
}