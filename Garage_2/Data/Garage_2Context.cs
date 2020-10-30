using Garage_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage_2.Data
{
    public class Garage_2Context : DbContext {
        public Garage_2Context(DbContextOptions<Garage_2Context> options)
            : base(options) {
        }

        public DbSet<ParkedVehicle> ParkedVehicle { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            //The seed entity for entity type 'ParkedVehicle' cannot be added because it has the navigation 'VehicleType' set. To seed relationships you need to add the related entity seed to 
            //'VehicleType' and spec
            // ify the foreign key values { 'VehicleTypeId'}. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the involved property values.
        }
    }
}









        
