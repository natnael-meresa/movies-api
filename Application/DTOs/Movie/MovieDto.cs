namespace Application.DTOs.Movie;

public class MovieDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public string? Description { get; set; }
    public int ReleaseYear { get; set; }
}
