using GCD0805.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View(todo);
        }
    }
}