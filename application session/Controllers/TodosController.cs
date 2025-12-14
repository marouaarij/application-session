using application_session.Filters;
using application_session.mapper;
using application_session.Models;
using application_session.Service;
using application_session.Viewmodel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

[ServiceFilter(typeof(RequireLoginFilter))]
public class TodosController : Controller
{
    [HttpGet]
    public IActionResult Add()
    {
        return View(new TodoAddVM()); // formulaire vide
    }

    [HttpPost]
    public IActionResult Add(TodoAddVM vm)
    {
        if (vm != null && ModelState.IsValid)
        {
            // Récupérer liste depuis session
            var list = JsonSerializer.Deserialize<List<Todo>>(HttpContext.Session.GetString("todos") ?? "[]");

            // Ajouter le todo
            list.Add(TodoMapper.GetTodoFromTodoAddVM(vm));

            // Sauvegarder dans la session
            new SessionManagerService().add(list, HttpContext);

            ModelState.Clear();          // réinitialiser le formulaire
            return View(new TodoAddVM()); // formulaire vide
        }

        return View(vm); // formulaire avec erreurs si invalide
    }

    [HttpGet]
    public IActionResult List()
    {
        var list = JsonSerializer.Deserialize<List<Todo>>(HttpContext.Session.GetString("todos") ?? "[]");
        return View(list); // redirige vers List.cshtml
    }
}
