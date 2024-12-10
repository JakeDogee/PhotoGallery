using PhotoGalery.Entities;
using PhotoGalery.Models;
using PhotoGalery.Repositories;

namespace PhotoGalery.Services;

public class PhotoService
{
    private readonly IPhotoRepository _photoRepository;

    public PhotoService(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<IEnumerable<PhotoDto>> GetPhotosByAlbumAsync(int albumId)
    {
        var photos = await _photoRepository.GetAllByAlbumIdAsync(albumId);
        return photos.Select(p => new PhotoDto
        {
            Id = p.Id,
            Url = p.Url,
            Likes = p.Likes,
            Dislikes = p.Dislikes
        });
    }

    public async Task AddPhotoAsync(PhotoDto photoDto, int albumId)
    {
        var photo = new Photo
        {
            Url = photoDto.Url,
            AlbumId = albumId,
            Likes = 0,
            Dislikes = 0
        };
        await _photoRepository.AddAsync(photo);
    }

    public async Task DeletePhotoAsync(int id)
    {
        await _photoRepository.DeleteAsync(id);
    }

    public async Task LikePhotoAsync(int photoId)
    {
        var photo = await _photoRepository.GetByIdAsync(photoId);
        if (photo != null)
        {
            photo.Likes++;
            await _photoRepository.UpdateAsync(photo);
        }
    }

    public async Task DislikePhotoAsync(int photoId)
    {
        var photo = await _photoRepository.GetByIdAsync(photoId);
        if (photo != null)
        {
            photo.Dislikes++;
            await _photoRepository.UpdateAsync(photo);
        }
    }
}