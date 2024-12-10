using PhotoGalery.Entities;
using PhotoGalery.Models;
using PhotoGalery.Repositories;

namespace PhotoGalery.Services;

public class AlbumService
{
    private readonly IAlbumRepository _albumRepository;

    public AlbumService(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task<IEnumerable<AlbumDto>> GetAllAlbumsAsync()
    {
        var albums = await _albumRepository.GetAllAsync();
        return albums.Select(a => new AlbumDto
        {
            Id = a.Id,
            Title = a.Title,
            CoverPhotoUrl = a.Photos.FirstOrDefault()?.Url
        });
    }

    public async Task AddAlbumAsync(AlbumDto albumDto, int userId)
    {
        var album = new Album { Title = albumDto.Title, UserId = userId };
        await _albumRepository.AddAsync(album);
    }

    public async Task DeleteAlbumAsync(int id)
    {
        await _albumRepository.DeleteAsync(id);
    }
}