using PhotoGalery.Entities;

namespace PhotoGalery.Repositories;

public interface IPhotoRepository
{
    Task<IEnumerable<Photo>> GetAllByAlbumIdAsync(int albumId);
    Task<Photo> GetByIdAsync(int id);
    Task AddAsync(Photo photo);
    Task DeleteAsync(int id);
    Task UpdateAsync(Photo photo);
}