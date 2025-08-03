using NightVibe.API.Data;
using NightVibe.API.Features.Events.Models;

namespace NightVibe.API.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
            context.Events.RemoveRange(context.Events);
            context.SaveChanges();
            context.Events.AddRange(
                new Event
                {
                    Title = "Deep Ellum EDM Takeover",
                    Genre = "EDM",
                    Address = "2727 Elm St, Dallas, TX 75226",
                    Latitude = 32.7850314100128,
                    Longitude = -96.78391306076537,
                    DateTime = DateTime.UtcNow.AddDays(2).AddHours(21),
                    ImageUrl = "https://images.discovery-prod.axs.com/2025/03/uploadedimage_67e1d3ba73bf5.jpg"
                },
                new Event
                {
                    Title = "Cumbia y Tequila",
                    Genre = "Latin",
                    Address = "4319 Main St, Dallas, TX 75226",
                    Latitude = 32.79113148865491,
                    Longitude = -96.76862644052363,
                    DateTime = DateTime.UtcNow.AddDays(4).AddHours(20),
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTRERBDYUzZJtBJJNwl-TxZKqUB3q3OtT8321lvSC0eDcr2WMm78hVX4ZPC9JzdtymYROPVRioihaRKfw0"
                },
                new Event
                {
                    Title = "Addison Country & Whiskey Night",
                    Genre = "Country",
                    Address = "4180 Belt Line Rd, Addison, TX 75001",
                    Latitude = 32.95376830456699,
                    Longitude = -96.81940355522066,
                    DateTime = DateTime.UtcNow.AddDays(5).AddHours(19),
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQ3sobjj02VFTnpazO3wc0La0WFT6zpTdmRy0sosyDfpp12AO57bV0IANMB65a8dZRqyDUZr9ncE_p1Hc"
                },
                new Event
                {
                    Title = "Fusion Vibes Kitchen + Lounge",
                    Genre = "Afrobeats",
                    Address = "100 S Central Expy #50, Richardson, TX 75080",
                    Latitude = 32.94928763643076,
                    Longitude = -96.73611480308966,
                    DateTime = DateTime.UtcNow.AddDays(3).AddHours(22),
                    ImageUrl = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSwjkr7gqStLNg2G4EciZRBw9cqCQhSwd_31szkR_BOj-fCD6osdtlWt0ImfN4iRKnER5yc8Q4mWRVNZkM"
                },
                new Event
                {
                    Title = "K-Pop Club Night",
                    Genre = "K-Pop",
                    Address = "3200 Commerce St, Dallas, TX 75226",
                    Latitude = 32.78410914257362,
                    Longitude = -96.77734353985795,
                    DateTime = DateTime.UtcNow.AddDays(6).AddHours(20),
                    ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQn1x0qd2GZFG4VeMytrdr8YJOF09Q-daeaZzf-YDeMqH9HyuqAasIA4MQeHiNTZ0d1XI75FguzGTSZq18"
                },
                new Event
                {
                    Title = "Jazz & Wine in Bishop Arts",
                    Genre = "Jazz",
                    Address = "2626-2630 Commerce St, Dallas, TX 75226",
                    Latitude = 32.78277008108563,
                    Longitude = -96.78496820674718,
                    DateTime = DateTime.UtcNow.AddDays(1).AddHours(18),
                    ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTCdJZNRvU24d4RvDHoxp6KZGPVSHwK-gCHKp21RZ2ZWVCTAnrjq0KdjWj8p4C5BpIdtWRMjNSmI5WhNa4"
                },
                new Event
                {
                    Title = "Kocktails & Karoake",
                    Genre = "Hip-Hop",
                    Address = "3094 N Stemmons Fwy, Dallas, TX 75247",
                    Latitude = 32.81289027407478,
                    Longitude = -96.86074367791198,
                    DateTime = DateTime.UtcNow.AddDays(3).AddHours(21),
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqItoGWJc5bBhwx9QZUfKY3VG1JIz3X_CL2-0dYxFyXp2FO39DcfS0sRWGy5mTb-oynOAuFLRs0fWcIHY"
                },
                new Event
                {
                    Title = "Latin Night @ Legacy Hall",
                    Genre = "Reggaeton",
                    Address = "7200 Bishop Rd Suite # 270, Plano, TX 75024",
                    Latitude = 33.077200491827035,
                    Longitude = -96.82122197791199,
                    DateTime = DateTime.UtcNow.AddDays(7).AddHours(20),
                    ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSxHPjsmgUA-YUcm_Ys6MNswCAjk7kNIYPyy2RN503Ikv0U1wZxx1l_sTpSRXEmSGhZ_S_P_n5kkSOsSj4"
                },
                new Event
                {
                    Title = "Rooftop Techno Session",
                    Genre = "Techno",
                    Address = "1340 Manufacturing St, Dallas, TX 75207",
                    Latitude = 32.797819698440165,
                    Longitude = -96.82954491534345,
                    DateTime = DateTime.UtcNow.AddDays(2).AddHours(22),
                    ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTad8X_FrdoVMz785mInANwH2bBMz1AGWLFLQz12o3NMaPkgh8FSBn8XtoCoI39r7PivT916dBhLVeruao"
                },
                new Event
                {
                    Title = "The Palace Salsa",
                    Genre = "Salsa",
                    Address = "2600 N Stemmons Fwy #188, Dallas, TX 75207",
                    Latitude = 32.80791292387629,
                    Longitude = -96.84095479999999,
                    DateTime = DateTime.UtcNow.AddDays(6).AddHours(20),
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSWANtmAm0WJgWwqnEOlUravHUacRvjDAGnusy4PwcW5lqPDcmAGhpLEsLar5XPIsi4QlNEIZKQ4Y01Mks"
                }
            );
            context.SaveChanges();
        
    }
}