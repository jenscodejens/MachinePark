using Microsoft.AspNetCore.Components;
using Resources.Enteties.Models;
using Resources.Enteties.Repositories;
using Resources.Enteties.State;

namespace MachinePark.Components.Pages
{
    public partial class MachineParkOverview
	{
		[SupplyParameterFromForm]
		public List<Machine> Machines { get; set; } = new List<Machine>();

		[Inject]
		public IDataService? DataService { get; set; }
        [Inject]
        public MachineStateService MachineStateService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (DataService != null && MachineStateService != null)
            {
                Machines = (await DataService.GetAllMachines()).ToList();
                MachineStateService.SetMachines(Machines);
            }
        }

        /// <summary>
        /// Checks the current status of the machine and toggle it to the opposite
        /// </summary>
        /// <param name="machineId">The <see cref="System.Guid"/> instance of machine currently being used.</param>
        /// <returns> If not <c>null</c>, toggles the machine status and update the database and MachineStateService with the new value</returns>
        private async Task UpdateOnlineStatus(Guid machineId)
		{           
			var machine = Machines.Find(m => m.MachineId == machineId);
			if (machine != null)
			{
				// Toggle the machine's status between Online and Offline
				machine.MachineStatus = machine.MachineStatus == MachineState.Online ? MachineState.Offline : MachineState.Online;

				await DataService.UpdateOnlineStatus(machine);
                MachineStateService.SetMachines(Machines);
			}
		}

		private async Task DeleteMachine(Guid machineId)
		{
			await DataService.DeleteMachine(machineId);
			Machines = (await DataService!.GetAllMachines()).ToList();
            MachineStateService.SetMachines(Machines);
        }
    }
}