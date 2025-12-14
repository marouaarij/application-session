using application_session.emun;
using System.ComponentModel.DataAnnotations;

namespace application_session.Viewmodel
{
    public class TodoAddVM
    {

        [Required]
        public string Libelle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string DateLimite { get; set; }
        [Required]
        public state State { get; set; }
    }
}
