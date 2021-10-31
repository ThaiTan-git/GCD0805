using GCD0805.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GCD0805.Controllers
{
    public class TodosController : Controller
    {
        // GET: Todos
        public ActionResult Index()
        {
            Todo todo = new Todo()
            {
                Id = 1,
                Description = "On air",
                DueDate = new DateTime(2021, 10, 30)
            };
            List<Todo> todos = new List<Todo>()
            {
                new Todo(){ Id = 1, Description = "On air", DueDate = new DateTime(2021, 10, 30) },
                new Todo(){ Id = 2, Description = "On air 2", DueDate = new DateTime(2021, 10, 31) },
                new Todo(){ Id = 3, Description = "On air 3", DueDate = new DateTime(2021, 11, 1)}
        };
            return View(todos);
        }
    }
}