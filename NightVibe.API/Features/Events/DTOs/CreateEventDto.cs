namespace NightVibe.API.Features.Events.DTOs;

public class CreateEventDto
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Location { get; set; }
     public DateTime DateTime { get; set; }
    public string ImageUrl { get; set; }
}