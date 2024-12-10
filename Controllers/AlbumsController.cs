using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGalery.Models;
using PhotoGalery.Services;

namespace PhotoGalery.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumsController : ControllerBase
{
    private readonly AlbumService _albumService;

    public AlbumsController(AlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlbums()
    {
        var albums = await _albumService.GetAllAlbumsAsync();
        return Ok(albums);
    }

    [HttpPost]
    [Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> AddAlbum([FromBody] AlbumDto albumDto)
    {
        var userId = int.Parse(User.FindFirst("UserId").Value);
        await _albumService.AddAlbumAsync(albumDto, userId);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAlbum(int id)
    {
        await _albumService.DeleteAlbumAsync(id);
        return NoContent();
    }
}