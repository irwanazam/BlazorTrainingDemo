using System.ComponentModel.DataAnnotations;

namespace BlazorTrainingDemo.Modules.States
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public int QuotaTrainee { get; set; }
    }
}
