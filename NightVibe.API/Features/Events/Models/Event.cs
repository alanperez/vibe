using System.ComponentModel.DataAnnotations;
using NightVibe.API.Features.Events.Models;

namespace NightVibe.API.Features.Events.Models;

// Event model represents single event in the system (EDM, DJ, Latin, etc.)
public class Event
{
    [Key]
    public int Id { get; set; } // auto increments primary key
    [Required]
    public string Title { get; set; } // Name of the event
    public string Genre { get; set; } // EDM, Latin, DJ, Hip hop, etc
    public string Address { get; set; } // Physical address or venue
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime DateTime { get; set; } // When it's happening
    public string ImageUrl { get; set; } // URL to a thumbnail or flyer image


    // Foreign Key + Navigation
    // ties Event to physical Venue object
    public Guid VenueId { get; set; }
    public Venue Venue { get; set; }

}