using System.Security;
using System.ComponentModel.DataAnnotations;
namespace NightVibe.API.Features.Events.DTOs;

public class CreateEventDto
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
     public DateTime DateTime { get; set; }
    public string ImageUrl { get; set; }
}