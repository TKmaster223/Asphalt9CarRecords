using Microsoft.EntityFrameworkCore;

namespace Asphalt9CarRecords.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CarClass> CarClasses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarClass>().HasData(
                new CarClass { Id = 1, Name = "D Class" },
                new CarClass { Id = 2, Name = "C Class" },
                new CarClass { Id = 3, Name = "B Class" },
                new CarClass { Id = 4, Name = "A Class" },
                new CarClass { Id = 5, Name = "S Class" }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Name = "Mitsubishi Lancer Evolution", Speed = 180, Acceleration = 60, Handling = 70, Nitro = 50, CarClassId = 1 },
                new Car { Id = 2, Name = "BMW Z4 LCI E89", Speed = 190, Acceleration = 65, Handling = 72, Nitro = 52, CarClassId = 1 },

                new Car { Id = 3, Name = "Chevrolet Camaro ZL1 50th Edition", Speed = 220, Acceleration = 75, Handling = 80, Nitro = 60, CarClassId = 2 },
                new Car { Id = 4, Name = "Nissan GT-R Nismo", Speed = 230, Acceleration = 78, Handling = 82, Nitro = 62, CarClassId = 2 },

                new Car { Id = 5, Name = "Aston Martin V12 Speedster", Speed = 250, Acceleration = 85, Handling = 88, Nitro = 70, CarClassId = 3 },
                new Car { Id = 6, Name = "Ferrari 488 GTB", Speed = 260, Acceleration = 88, Handling = 90, Nitro = 72, CarClassId = 3 },

                new Car { Id = 7, Name = "McLaren 570S", Speed = 280, Acceleration = 92, Handling = 95, Nitro = 78, CarClassId = 4 },
                new Car { Id = 8, Name = "Lamborghini Huracan Evo Spyder", Speed = 290, Acceleration = 95, Handling = 98, Nitro = 80, CarClassId = 4 },

                new Car { Id = 9, Name = "Bugatti Chiron", Speed = 300, Acceleration = 98, Handling = 99, Nitro = 85, CarClassId = 5 },
                new Car { Id = 10, Name = "Koenigsegg Jesko", Speed = 310, Acceleration = 100, Handling = 100, Nitro = 90, CarClassId = 5 }
            );
        }
    }
}
