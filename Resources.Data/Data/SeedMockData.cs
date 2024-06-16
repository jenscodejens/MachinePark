using Resources.Enteties.Models;

namespace Resources.Data.Data
{
    public class SeedMockData
    {
        private static List<Machine>? _machines = default!;

        public static List<Machine>? Machines
        {
            get
            {
                _machines ??= LoadMockMachines();

                return _machines;
            }
        }

        private static List<Machine> LoadMockMachines()
        {
            var m1 = new Machine
            {
                MachineId = Guid.NewGuid(),
                Model = "Model 1",
                Note = "Maintanence 2024-08-01",
                AcquisitionDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local),
                MachineStatus = MachineState.Online,
                LeaseStatus = LeaseState.Yes
            };

            var m2 = new Machine
            {
                MachineId = Guid.NewGuid(),
                Model = "Model 2",
                Note = "<no notes>",
                AcquisitionDate = new DateTime(2024, 2, 2, 0, 0, 0, DateTimeKind.Local),
                MachineStatus = MachineState.Offline,
                LeaseStatus = LeaseState.No
            };

            var m3 = new Machine
            {
                MachineId = Guid.NewGuid(),
                Model = "Model 3",
                Note = "Upgraded to BBX7 battery",
                AcquisitionDate = new DateTime(2024, 3, 3, 0, 0, 0, DateTimeKind.Local),
                MachineStatus = MachineState.Online,
                LeaseStatus = LeaseState.Other
            };

            return [m1, m2, m3];
        }
    }
}