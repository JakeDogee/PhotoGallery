using Moq;
using PhotoGalery.Entities;
using PhotoGalery.Models;
using PhotoGalery.Repositories;
using PhotoGalery.Services;
using Xunit;

namespace PhotoGalery.Tests;

public class AlbumServiceTests
{
    [Fact]
    public async Task GetAllAlbumsAsync_ShouldReturnAlbumDtos()
    {
        // Arrange
        var mockRepo = new Mock<IAlbumRepository>();
        mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Album>
        {
            new Album
            {
                Id = 1,
                Title = "Test Album",
                Photos = new List<Photo>
                {
                    new Photo { Id = 1, Url = "photo1.jpg" },
                    new Photo { Id = 2, Url = "photo2.jpg" }
                }
            }
        });

        var service = new AlbumService(mockRepo.Object);

        // Act
        var result = await service.GetAllAlbumsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Test Album", result.First().Title);
        Assert.Equal("photo1.jpg", result.First().CoverPhotoUrl);
    }

    [Fact]
    public async Task AddAlbumAsync_ShouldCallAddMethodOnce()
    {
        // Arrange
        var mockRepo = new Mock<IAlbumRepository>();
        var service = new AlbumService(mockRepo.Object);

        var albumDto = new AlbumDto { Title = "New Album" };

        // Act
        await service.AddAlbumAsync(albumDto, 1);

        // Assert
        mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Album>()), Times.Once);
    }
}