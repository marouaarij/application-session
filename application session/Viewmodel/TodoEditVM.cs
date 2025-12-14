using System.ComponentModel.DataAnnotations;

namespace application_session.Viewmodel
{
    public class TodoEditVM
    {
        
        public string libelle {  get; set; }
        
        public string description { get; set; }
        
        public string datelimite { get; set; }
        
        public string state { get; set; }
    }
}
