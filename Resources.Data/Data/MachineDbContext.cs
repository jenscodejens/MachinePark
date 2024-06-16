using Microsoft.EntityFrameworkCore;
using Resources.Enteties.Models;

namespace Resources.Data.Data
{
    public class MachineDbContext : DbContext
    {
        public DbSet<Machine> Machines { get; set; }
        public MachineDbContext(DbContextOptions<MachineDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Machine>().HasData(new Machine
            {
                MachineId = Guid.NewGuid(),
                Model = "Model 1",
                Note = "Maintanence 2024-08-01",
                AcquisitionDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local),
                MachineStatus = MachineState.Online,
                LeaseStatus = LeaseState.Yes
            });
            modelBuilder.Entity<Machine>().HasData(new Machine
            {
                MachineId = Guid.NewGuid(),
                Model = "Model 2",
                Note = "<no notes>",
                AcquisitionDate = new DateTime(2024, 2, 2, 0, 0, 0, DateTimeKind.Local),
                MachineStatus = MachineState.Offline,
                LeaseStatus = LeaseState.No
            });
            modelBuilder.Entity<Machine>().HasData(new Machine
            {
                MachineId = Guid.NewGuid(),
                Model = "Model 3",
                Note = "Upgraded to BBX7 battery",
                AcquisitionDate = new DateTime(2024, 3, 3, 0, 0, 0, DateTimeKind.Local),
                MachineStatus = MachineState.Online,
                LeaseStatus = LeaseState.Other
            });
        }
    }
}
