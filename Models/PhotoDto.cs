namespace PhotoGalery.Models;

public class PhotoDto
{
    public int Id { get; set; }
    public string Url { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
}