
using GameHUB.Models;

namespace GameHUB.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        public DbSet<Game>Games { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Cateogry> Cateogries { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cateogry>()
                .HasData(new Cateogry[] { 

                    new Cateogry{Id= 1 ,Name="Sports" },
                    new Cateogry{Id= 2 ,Name="Adventure" },
                    new Cateogry{Id= 3 ,Name="Action" },
                    new Cateogry{Id= 4 ,Name="Film" },
                    new Cateogry{Id= 5 ,Name="Racing" },
                    new Cateogry{Id= 6 ,Name="Fighting" }
                });

           

            modelBuilder.Entity<GameDevice>()
                .HasKey(e => new { e.gameId, e.deviceId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
