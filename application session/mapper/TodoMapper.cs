using application_session.Models;
using application_session.Viewmodel;

namespace application_session.mapper
{
    public class TodoMapper
    {
        public static Todo GetTodoFromTodoAddVM(TodoAddVM vm)
        {
            Todo Todo = new Todo();
            Todo.Libelle = vm.Libelle;
            Todo.Description = vm.Description;
            Todo.DateLimite = vm.DateLimite;
            Todo.State = vm.State;

            return Todo;

        }
    }
}
