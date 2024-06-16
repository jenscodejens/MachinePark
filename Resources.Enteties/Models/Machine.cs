using System.ComponentModel.DataAnnotations;
using static Resources.Enteties.Models.LeaseState;
using static Resources.Enteties.Models.MachineState;

namespace Resources.Enteties.Models
{
    public class Machine
    {
        [Key]
        public Guid MachineId { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(25, ErrorMessage = "Model is required (up to 25 charaters")]
        public string Model { get; set; } = string.Empty;
        [StringLength(30, ErrorMessage = "No more than 30 charaters")]
        public string Note { get; set; } = "<no notes>";
        public DateTime AcquisitionDate { get; set; } = DateTime.Now;
        public MachineState MachineStatus { get; set; } = Online;
        public LeaseState LeaseStatus { get; set; } = No;
    }
}
