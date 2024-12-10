using Microsoft.EntityFrameworkCore;
using PhotoGalery.Data;
using PhotoGalery.Entities;

namespace PhotoGalery.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private readonly AppDbContext _context;

    public AlbumRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Album>> GetAllAsync() => await _context.Albums.Include(a => a.Photos).ToListAsync();

    public async Task<Album> GetByIdAsync(int id) => await _context.Albums.Include(a => a.Photos).FirstOrDefaultAsync(a => a.Id == id);

    public async Task AddAsync(Album album)
    {
        await _context.Albums.AddAsync(album);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var album = await _context.Albums.FindAsync(id);
        if (album != null)
        {
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
        }
    }
}