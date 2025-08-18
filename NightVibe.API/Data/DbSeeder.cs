using NightVibe.API.Data;
using NightVibe.API.Features.Events.Models;
using NightVibe.API.Features.Venues.Models;
using NightVibe.API.Features.Neighborhoods.Models;
namespace NightVibe.API.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        // 1) Upsert Neighborhoods by Slug (idempotent)
        var neighborhoods = new[]
        {
            new Neighborhood { Id = Guid.NewGuid(), Name = "Deep Ellum",        Slug = "deep-ellum" },
            new Neighborhood { Id = Guid.NewGuid(), Name = "Addison",           Slug = "addison" },
            new Neighborhood { Id = Guid.NewGuid(), Name = "Richardson",        Slug = "richardson" },
            new Neighborhood { Id = Guid.NewGuid(), Name = "Plano Legacy",      Slug = "plano-legacy" },
            new Neighborhood { Id = Guid.NewGuid(), Name = "Design District",   Slug = "design-district" },
            new Neighborhood { Id = Guid.NewGuid(), Name = "Uptown",            Slug = "uptown" },
            new Neighborhood { Id = Guid.NewGuid(), Name = "Lower Greenville",  Slug = "lower-greenville" }
        };

        foreach (var n in neighborhoods)
        {
            var existing = context.Neighborhoods.FirstOrDefault(x => x.Slug == n.Slug);
            if (existing == null)
            {
                context.Neighborhoods.Add(n);
            }
            else
            {
                // optional: keep names fresh if you ever change them
                if (!string.Equals(existing.Name, n.Name, StringComparison.Ordinal))
                    existing.Name = n.Name;
            }
        }
        context.SaveChanges();

        Guid N(string slug) => context.Neighborhoods.First(x => x.Slug == slug).Id;

        // 2) Upsert Venues by Name (idempotent); create if missing, update fields if present
        UpsertVenueByName(context, new Venue
        {
            Name = "The Factory in Deep Ellum",
            Address = "2727 Elm St, Dallas, TX 75226",
            Latitude = 32.785031,
            Longitude = -96.783913,
            Description = "Multi-purpose music venue in the heart of Deep Ellum.",
            ImageUrl = "https://images.discovery-prod.axs.com/2025/03/uploadedimage_67e1d3ba73bf5.jpg",
            NeighborhoodId = N("deep-ellum")
        });

        UpsertVenueByName(context, new Venue
        {
            Name = "Addison Circle Stage",
            Address = "4180 Belt Line Rd, Addison, TX 75001",
            Latitude = 32.953768,
            Longitude = -96.819403,
            Description = "Outdoor venue at Addison Circle Park with weekend country shows.",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQ3sobjj02VFTnpazO3wc0La0WFT6zpTdmRy0sosyDfpp12AO57bV0IANMB65a8dZRqyDUZr9ncE_p1Hc",
            NeighborhoodId = N("addison")
        });

        UpsertVenueByName(context, new Venue
        {
            Name = "Fusion Vibes Lounge",
            Address = "100 S Central Expy #50, Richardson, TX 75080",
            Latitude = 32.949287,
            Longitude = -96.736114,
            Description = "Upscale Afrobeat and Latin nightlife lounge.",
            ImageUrl = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSwjkr7gqStLNg2G4EciZRBw9cqCQhSwd_31szkR_BOj-fCD6osdtlWt0ImfN4iRKnER5yc8Q4mWRVNZkM",
            NeighborhoodId = N("richardson")
        });

        UpsertVenueByName(context, new Venue
        {
            Name = "Legacy Hall Box Garden",
            Address = "7200 Bishop Rd, Plano, TX 75024",
            Latitude = 33.077200,
            Longitude = -96.821221,
            Description = "Massive outdoor stage with Latin and reggaeton nights.",
            ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSxHPjsmgUA-YUcm_Ys6MNswCAjk7kNIYPyy2RN503Ikv0U1wZxx1l_sTpSRXEmSGhZ_S_P_n5kkSOsSj4",
            NeighborhoodId = N("plano-legacy")
        });

        context.SaveChanges();

        // 3) Upsert Events by Title and link to Venues by Name (idempotent)
        UpsertEventByTitle(context, "Deep Ellum EDM Takeover", "EDM", "The Factory in Deep Ellum");
        UpsertEventByTitle(context, "Addison Country & Whiskey Night", "Country", "Addison Circle Stage");
        UpsertEventByTitle(context, "Afrobeats Lounge Party", "Afrobeats", "Fusion Vibes Lounge");
        UpsertEventByTitle(context, "Latin Night @ Legacy Hall", "Reggaeton", "Legacy Hall Box Garden");

        context.SaveChanges();
    }

    private static void UpsertVenueByName(AppDbContext context, Venue incoming)
    {
        var existing = context.Venues.FirstOrDefault(v => v.Name == incoming.Name);
        if (existing == null)
        {
            incoming.Id = Guid.NewGuid();
            context.Venues.Add(incoming);
        }
        else
        {
            // Update fields if they changed
            existing.Address       = incoming.Address;
            existing.Latitude      = incoming.Latitude;
            existing.Longitude     = incoming.Longitude;
            existing.Description   = incoming.Description;
            existing.ImageUrl      = incoming.ImageUrl;
            if (existing.NeighborhoodId == Guid.Empty || existing.NeighborhoodId == default)
                existing.NeighborhoodId = incoming.NeighborhoodId;
        }
    }

    private static void UpsertEventByTitle(AppDbContext context, string title, string genre, string venueName)
    {
        var venue = context.Venues.FirstOrDefault(v => v.Name == venueName);
        if (venue == null) return; // venue must exist

        var e = context.Events.FirstOrDefault(x => x.Title == title);
        if (e == null)
        {
            context.Events.Add(new Event
            {
                Title     = title,
                Genre     = genre,
                Address   = venue.Address,
                Latitude  = venue.Latitude,
                Longitude = venue.Longitude,
                DateTime  = DateTime.UtcNow.AddDays(2).AddHours(21),
                ImageUrl  = venue.ImageUrl,
                VenueId   = venue.Id
            });
        }
        else
        {
            // Update event linkage & fields (keeps existing time if you prefer)
            e.Address   = venue.Address;
            e.Latitude  = venue.Latitude;
            e.Longitude = venue.Longitude;
            e.ImageUrl  = venue.ImageUrl;
            e.VenueId   = venue.Id;
        }
    }
}