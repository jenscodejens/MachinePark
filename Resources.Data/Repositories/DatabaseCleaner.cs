using Resources.Data.Data;
using Resources.Enteties.IRepositories;

namespace Resources.Data.Repositories
{
    public class DatabaseCleaner(MachineDbContext context) : IDatabaseCleaner
    {
        private readonly MachineDbContext _context = context;

        public async Task DeleteDbAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task CreateDbAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }
    }
}
