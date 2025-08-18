using System.ComponentModel.DataAnnotations;
using NightVibe.API.Features.Venues.Models;

namespace NightVibe.API.Features.Neighborhoods.Models;

public class Neighborhood
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Slug { get; set; }

    public ICollection<Venue> Venues { get; set; } = new List<Venue>();
}