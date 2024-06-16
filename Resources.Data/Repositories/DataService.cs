using Resources.Enteties.Models;
using Resources.Enteties.Repositories;

namespace Resources.Data.Repositories
{
    public class DataService : IDataService
    {
        private readonly IMachineRepository _machineRepository;

        public DataService(IMachineRepository machineRepository) => _machineRepository = machineRepository;

        public async Task AddMachine(Machine machine)
        {
            await _machineRepository.AddMachine(machine);
        }

        public async Task<IEnumerable<Machine>> GetAllMachines()
        {
            return await _machineRepository.GetAllMachines();
        }

        public async Task<Machine> GetMachineById(Guid machineId)
        {
            return await _machineRepository.GetMachineById(machineId);
        }

        public async Task UpdateOnlineStatus(Machine machine)
        {
            await _machineRepository.UpdateOnlineStatus(machine);
        }

        public async Task UpdateMachine(Machine machine)
        {
            await _machineRepository.UpdateMachine(machine);
        }

        public async Task DeleteMachine(Guid machineId)
        {
            await _machineRepository.DeleteMachine(machineId);
        }
    }
}
