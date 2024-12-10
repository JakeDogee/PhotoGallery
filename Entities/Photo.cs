namespace PhotoGalery.Entities;

public class Photo
{
    public int Id { get; set; }
    public string Url { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public int AlbumId { get; set; }
    public Album Album { get; set; }
}