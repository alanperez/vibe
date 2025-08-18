using System.ComponentModel.DataAnnotations;
using NightVibe.API.Features.Events.Models;
using NightVibe.API.Features.Neighborhoods.Models;

namespace NightVibe.API.Features.Venues.Models;

public class Venue
{
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        // Navigation property (1 venue has many events)
        public ICollection<Event> Events { get; set; } = new List<Event>();

        public Guid NeighborhoodId { get; set; }
        public Neighborhood Neighborhood { get; set; }
}