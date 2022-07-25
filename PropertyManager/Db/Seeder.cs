using Microsoft.EntityFrameworkCore;

namespace PropertyManager.Db
{
    public static class Seeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                if(context.Database.CanConnect())
                {
                    return;
                } else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
