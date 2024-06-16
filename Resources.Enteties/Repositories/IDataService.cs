using Resources.Enteties.Models;

namespace Resources.Enteties.Repositories
{
    public interface IDataService
    {
        Task<IEnumerable<Machine>> GetAllMachines();
        Task<Machine> GetMachineById(Guid machineId);
        Task UpdateOnlineStatus(Machine machine);
        Task AddMachine(Machine machine);
        Task UpdateMachine(Machine machine);
        Task DeleteMachine(Guid machineId);
    }
}
