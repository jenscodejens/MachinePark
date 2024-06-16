using Microsoft.EntityFrameworkCore;
using Resources.Data.Data;
using Resources.Enteties.Models;
using Resources.Enteties.Repositories;

namespace Resources.Data.Repositories
{
    public class MachineRepository : IMachineRepository, IDisposable // Read_up_on.txt
    {
        private readonly MachineDbContext _context;

        public MachineRepository(IDbContextFactory<MachineDbContext> dbFactory)
        {
            _context = dbFactory.CreateDbContext();
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Machine>> GetAllMachines()
        {
            return await _context.Machines.ToListAsync();
        }

        public async Task<Machine> GetMachineById(Guid machineId)
        {
            var machine = await _context.Machines.FirstOrDefaultAsync(m => m.MachineId == machineId);

            return machine ?? throw new InvalidOperationException($"No machine found with ID: {machineId}");
        }

        public async Task UpdateOnlineStatus(Machine machine)
        {
            _context.Machines.Attach(machine);
            await _context.SaveChangesAsync();
        }

        public async Task AddMachine(Machine machine)
        {
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();

            //return machine;
        }

        public async Task UpdateMachine(Machine machine)
        {
            _context.Machines.Attach(machine);

            _context.Entry(machine).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMachine(Guid machineId)
        {
            var machine = await _context.Machines.FindAsync(machineId);
            if (machine != null)
            {
                _context.Machines.Remove(machine);
                await _context.SaveChangesAsync();
            }
        }
        //public async Task<int> GetTotalMachines()
        //{
        //    return await _context.Machines.CountAsync();
        //}

        //public async Task<int> GetOnlineMachines()
        //{
        //    return await _context.Machines.CountAsync(m => m.MachineStatus == MachineState.Online);
        //}

    }
}

/* 
 * private void SeedMockDataToContext()
 * {
 *  
 *  _context.Machines.RemoveRange(_context.Machines);
 *
 *  _context.Machines.AddRange(SeedMockData.Machines);
 *  _context.SaveChanges();
 *  }
*/