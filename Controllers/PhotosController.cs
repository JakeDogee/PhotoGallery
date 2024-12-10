using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGalery.Models;
using PhotoGalery.Services;

namespace PhotoGalery.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhotosController : ControllerBase
{
    private readonly PhotoService _photoService;

    public PhotosController(PhotoService photoService)
    {
        _photoService = photoService;
    }

    [HttpGet("{albumId}")]
    public async Task<IActionResult> GetPhotosByAlbum(int albumId)
    {
        var photos = await _photoService.GetPhotosByAlbumAsync(albumId);
        return Ok(photos);
    }

    [HttpPost("{albumId}")]
    [Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> AddPhoto(int albumId, [FromBody] PhotoDto photoDto)
    {
        await _photoService.AddPhotoAsync(photoDto, albumId);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeletePhoto(int id)
    {
        await _photoService.DeletePhotoAsync(id);
        return NoContent();
    }

    [HttpPost("{id}/like")]
    [Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> LikePhoto(int id)
    {
        await _photoService.LikePhotoAsync(id);
        return Ok();
    }

    [HttpPost("{id}/dislike")]
    [Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> DislikePhoto(int id)
    {
        await _photoService.DislikePhotoAsync(id);
        return Ok();
    }
}