using application_session.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace application_session.Service
{
    public class SessionManagerService
    {
        public void add( List<Todo> list , HttpContext context)
        {
            string chaine = JsonSerializer.Serialize(list);
            context.Session.SetString("todos", chaine);
        }
    }
}
