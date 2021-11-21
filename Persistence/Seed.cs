using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser {UserName = "Bob",Email = "bob@test.com"},
                    new AppUser { UserName = "Goshko",Email = "goshe@test.com" },
                    new AppUser { UserName = "Milka", Email = "milka@test.com"},
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "ParoL@1");
                }


            }


            if (context.Events.Any())
            {
                return;
            }
            var events = new List<Event>
            {
                new Event
                {
                    Title ="Past Event 1",
                    Description = "Event 2 mounths Ago",
                    StartDate = DateTime.Now.AddMonths(-4),
                    EndDate = DateTime.Now.AddMonths(-2)
                    
                },
                new Event
                {
                    Title ="Past Event 2",
                    Description = "Event 1 mounths Ago",
                    StartDate = DateTime.Now.AddMonths(-2),
                    EndDate = DateTime.Now.AddMonths(-1)

                },
                new Event
                {
                    Title ="Future Event 1",
                    Description = "Event 2 mounths in the future",
                    StartDate = DateTime.Now.AddMonths(2),
                    EndDate = DateTime.Now.AddMonths(4)

                },
                new Event
                {
                    Title ="Future Event 2",
                    Description = "Event 1 mounth in the future",
                    StartDate = DateTime.Now.AddMonths(1),
                    EndDate = DateTime.Now.AddMonths(2)

                }
            };
            await context.Events.AddRangeAsync(events);
            await context.SaveChangesAsync();
        }
    }
}
