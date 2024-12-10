using PhotoGalery.Entities;

namespace PhotoGalery.Repositories;

public interface IAlbumRepository
{
    Task<IEnumerable<Album>> GetAllAsync();
    Task<Album> GetByIdAsync(int id);
    Task AddAsync(Album album);
    Task DeleteAsync(int id);
}