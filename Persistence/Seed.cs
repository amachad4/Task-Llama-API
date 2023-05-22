using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName = "Bob", UserName = "bob", Email = "bob@test.com"},
                    new AppUser{DisplayName = "Tom", UserName = "tom", Email = "tom@test.com"},
                    new AppUser{DisplayName = "Jane", UserName = "jane", Email = "jane@test.com"},
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            if(context.status_lkp.Any() && context.category_lkp.Any() && context.activities.Any() && context.sub_activities.Any()) return;
            var statuses = new List<StatusLkp>
            {new StatusLkp
                {
                    Id = 1,
                    value = "Started"
                },
                new StatusLkp
                {
                    Id = 2,
                    value = "Completed"
                },
                new StatusLkp
                {
                    Id = 3,
                    value = "Canceled"
                }
            };
            

            var categories = new List<CategoryLkp>{
                new CategoryLkp{
                    Id = 1,
                    value = "Fitness"
                },
                new CategoryLkp{
                    Id = 2,
                    value = "Education"
                }
            };
            
            

            var activities = new List<Activity>{
                new Activity{
                    Id = Guid.NewGuid(),
                    title = "Go for a walk",
                    deadline = new DateTime(2023, 12, 5),
                    created_at = DateTime.UtcNow,
                    category_lkp_id = 1,
                    status_lkp_id = 1
                },
                new Activity{
                    Id = Guid.NewGuid(),
                    title = "Study C#",
                    deadline = new DateTime(2023, 9, 8),
                    created_at = DateTime.UtcNow,
                    category_lkp_id = 2,
                    status_lkp_id = 1
                }
            };

            var sub_activities = new List<SubActivity>{
                new SubActivity{
                    title = "Stretch my legs",
                    deadline = new DateTime(2023, 12, 1),
                    created_at = DateTime.UtcNow,
                    status_lkp_id = 1,
                    activity_id = activities[0].Id
                }
            };

            await context.status_lkp.AddRangeAsync(statuses);
            await context.category_lkp.AddRangeAsync(categories);
            await context.activities.AddRangeAsync(activities);
            await context.sub_activities.AddRangeAsync(sub_activities);

            await context.SaveChangesAsync();
        }
    }
}