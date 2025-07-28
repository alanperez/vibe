using NightVibe.API.Data;
using NightVibe.API.Features.Events.Models;
using NightVibe.API.Features.Venues.Models;
namespace NightVibe.API.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Venues.Any())
        {
            // Clear existing
            context.Events.RemoveRange(context.Events);
            context.Venues.RemoveRange(context.Venues);
            context.SaveChanges();

            // Create venues
            var venues = new List<Venue>
            {
                new Venue
                {
                    Id = Guid.NewGuid(),
                    Name = "The Factory in Deep Ellum",
                    Address = "2727 Elm St, Dallas, TX 75226",
                    Latitude = 32.785031,
                    Longitude = -96.783913,
                    Description = "Multi-purpose music venue in the heart of Deep Ellum.",
                    ImageUrl = "https://images.discovery-prod.axs.com/2025/03/uploadedimage_67e1d3ba73bf5.jpg"
                },
                new Venue
                {
                    Id = Guid.NewGuid(),
                    Name = "Addison Circle Stage",
                    Address = "4180 Belt Line Rd, Addison, TX 75001",
                    Latitude = 32.953768,
                    Longitude = -96.819403,
                    Description = "Outdoor venue at Addison Circle Park with weekend country shows.",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQ3sobjj02VFTnpazO3wc0La0WFT6zpTdmRy0sosyDfpp12AO57bV0IANMB65a8dZRqyDUZr9ncE_p1Hc"
                },
                new Venue
                {
                    Id = Guid.NewGuid(),
                    Name = "Fusion Vibes Lounge",
                    Address = "100 S Central Expy #50, Richardson, TX 75080",
                    Latitude = 32.949287,
                    Longitude = -96.736114,
                    Description = "Upscale Afrobeat and Latin nightlife lounge.",
                    ImageUrl = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSwjkr7gqStLNg2G4EciZRBw9cqCQhSwd_31szkR_BOj-fCD6osdtlWt0ImfN4iRKnER5yc8Q4mWRVNZkM"
                },
                new Venue
                {
                    Id = Guid.NewGuid(),
                    Name = "Legacy Hall Box Garden",
                    Address = "7200 Bishop Rd, Plano, TX 75024",
                    Latitude = 33.077200,
                    Longitude = -96.821221,
                    Description = "Massive outdoor stage with Latin and reggaeton nights.",
                    ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSxHPjsmgUA-YUcm_Ys6MNswCAjk7kNIYPyy2RN503Ikv0U1wZxx1l_sTpSRXEmSGhZ_S_P_n5kkSOsSj4"
                }
            };

            context.Venues.AddRange(venues);
            context.SaveChanges();

            // Create events linked to venues
            var events = new List<Event>
            {
                new Event
                {
                    Title = "Deep Ellum EDM Takeover",
                    Genre = "EDM",
                    Address = venues[0].Address,
                    Latitude = venues[0].Latitude,
                    Longitude = venues[0].Longitude,
                    DateTime = DateTime.UtcNow.AddDays(2).AddHours(21),
                    ImageUrl = venues[0].ImageUrl,
                    VenueId = venues[0].Id
                },
                new Event
                {
                    Title = "Addison Country & Whiskey Night",
                    Genre = "Country",
                    Address = venues[1].Address,
                    Latitude = venues[1].Latitude,
                    Longitude = venues[1].Longitude,
                    DateTime = DateTime.UtcNow.AddDays(5).AddHours(19),
                    ImageUrl = venues[1].ImageUrl,
                    VenueId = venues[1].Id
                },
                new Event
                {
                    Title = "Afrobeats Lounge Party",
                    Genre = "Afrobeats",
                    Address = venues[2].Address,
                    Latitude = venues[2].Latitude,
                    Longitude = venues[2].Longitude,
                    DateTime = DateTime.UtcNow.AddDays(3).AddHours(22),
                    ImageUrl = venues[2].ImageUrl,
                    VenueId = venues[2].Id
                },
                new Event
                {
                    Title = "Latin Night @ Legacy Hall",
                    Genre = "Reggaeton",
                    Address = venues[3].Address,
                    Latitude = venues[3].Latitude,
                    Longitude = venues[3].Longitude,
                    DateTime = DateTime.UtcNow.AddDays(7).AddHours(20),
                    ImageUrl = venues[3].ImageUrl,
                    VenueId = venues[3].Id
                }
            };

            context.Events.AddRange(events);
            context.SaveChanges();
        }
    }
}