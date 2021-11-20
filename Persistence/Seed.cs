using Domain;

namespace Persistence
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context)
        {
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
