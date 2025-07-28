using NightVibe.API.Features.Events.Models;

namespace NitghtVibe.API.Features.Events.Models;

public class Venue
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime DateTime { get; set; }

    public ICollection<Event> Events { get; set; }
}