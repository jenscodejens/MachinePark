using Resources.Enteties.Models;

namespace Resources.Enteties.State
{
    public class MachineStateService
    {
        private List<Machine> _machines = new List<Machine>();
        public List<Machine> Machines
        {
            get => _machines;
            private set
            {
                _machines = value;
                TotalMachines = _machines.Count;
                OnlineMachines = _machines.Count(m => m.MachineStatus == MachineState.Online);
                NotifyStateChanged();
            }
        }
        public int TotalMachines { get; private set; }
        public int OnlineMachines { get; private set; }

        public event Action OnChange;

        public void SetMachines(List<Machine> machines)
        {
            Machines = machines;
        }
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}