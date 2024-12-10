using Microsoft.EntityFrameworkCore;
using PhotoGalery.Data;
using PhotoGalery.Entities;

namespace PhotoGalery.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private readonly AppDbContext _context;

    public PhotoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Photo>> GetAllByAlbumIdAsync(int albumId)
    {
        return await _context.Photos.Where(p => p.AlbumId == albumId).ToListAsync();
    }

    public async Task<Photo> GetByIdAsync(int id)
    {
        return await _context.Photos.FindAsync(id);
    }

    public async Task AddAsync(Photo photo)
    {
        await _context.Photos.AddAsync(photo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var photo = await GetByIdAsync(id);
        if (photo != null)
        {
            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Photo photo)
    {
        _context.Photos.Update(photo);
        await _context.SaveChangesAsync();
    }
}