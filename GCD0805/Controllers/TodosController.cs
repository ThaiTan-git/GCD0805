﻿using GCD0805.Models;
using System.Linq;
using System.Web.Mvc;

namespace GCD0805.Controllers
{
    public class TodosController : Controller
    {
        private ApplicationDbContext _context;
        public TodosController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Todos
        [HttpGet]
        public ActionResult Index()
        {
            /*Todo todo = new Todo()
            {
                Id = 1,
                Description = "On air",
                DueDate = new DateTime(2021, 10, 30)
            };*/
            /*List<Todo> todos = new List<Todo>()
            {
                new Todo(){ Id = 1, Description = "On air", DueDate = new DateTime(2021, 10, 30) },
                new Todo(){ Id = 2, Description = "On air 2", DueDate = new DateTime(2021, 10, 31) },
                new Todo(){ Id = 3, Description = "On air 3", DueDate = new DateTime(2021, 11, 1)}
        };*/
            var todos = _context.Todos.ToList();
            return View(todos);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            var newTodo = new Todo()
            {
                Description = todo.Description,
                DueDate = todo.DueDate
            };

            _context.Todos.Add(newTodo);
            _context.SaveChanges();
            return RedirectToAction("Index", "Todos");
        }
    }
}