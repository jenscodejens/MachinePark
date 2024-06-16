using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Resources.Enteties.Models;
using Resources.Enteties.Repositories;

namespace MachinePark.Components.Pages
{
    public partial class MachineInfo : ComponentBase
    {
        [Parameter]
        public Guid MachineId { get; set; }

        [Inject]
        public IDataService DataService { get; set; }

        private Machine? Machine;
        protected string Message = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Machine = await DataService.GetMachineById(MachineId);
        }

        private bool EditMode { get; set; } = false;

        private async Task HandleValidSubmit(EditContext context)
        {
            await DataService.UpdateMachine(Machine);

            var updatedMachines = await DataService.GetAllMachines();
            MachineStateService.SetMachines((List<Machine>)updatedMachines);

            EditMode = false;
        }

        protected void HandleInvalidSubmit()
        {
            Message = "There are some validation errors. Please try again.";
        }

        private void CancelEdit()
        {
            EditMode = false;
        }

        private void ToggleEditMode()
        {
            EditMode = !EditMode;
        }
        private void NavigateBack()
        {
            NavigationManager.NavigateTo("/machineparkoverview");
        }
    }
}
