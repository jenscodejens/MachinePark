using Microsoft.AspNetCore.Components;
using Resources.Enteties.Models;
using Resources.Enteties.Repositories;

namespace MachinePark.Components.Pages
{
    public partial class AddMachine
    {
        [Parameter]
        public Machine Machine { get; set; } = new Machine();

        [Inject]
        public IDataService DataService { get; set; }

        protected string Message = string.Empty;
        protected bool IsSaved = false;

        protected override void OnInitialized()
        {
            Machine = new Machine();
            if (Machine.Note == "<no notes>")
            {
                Machine.Note = string.Empty;
            }
        }

        private async Task OnSubmit()
        {
            await DataService.AddMachine(Machine);
            IsSaved = true;
            Message = "Machine added..";
        }

        public void MachineParkOverview()
        {
            NavigationManager.NavigateTo("/machineparkoverview");
        }
    }
}