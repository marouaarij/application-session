using application_session.emun;
using application_session.Viewmodel;
using System.ComponentModel.DataAnnotations;

namespace application_session.Models
{
    public class Todo
    {
      
        public string Libelle { get; set; }
       
        public string Description { get; set; }
        
        public string DateLimite { get; set; }
        
        public state State { get; set; }
    }
}
