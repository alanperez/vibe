namespace NightVibe.API.Features.Events.DTOs;

// The output is sesnt to the frontend
public class EventDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Address { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime DateTime { get; set; }
    public string ImageUrl { get; set; }
}