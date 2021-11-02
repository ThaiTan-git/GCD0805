using GCD0805.Models;
using GCD0805.Units;
using GCD0805.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GCD0805.Controllers
{
    [Authorize(Roles = Role.User)]
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
            var userId = User.Identity.GetUserId();
            var todos = _context.Todos
                .Include(t => t.Category)
                .Where(t => t.UserId == userId)
                .ToList();
            return View(todos);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new TodoCategoriesViewModel()
            {
                Categories = categories
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(TodoCategoriesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TodoCategoriesViewModel
                {
                    Todo = model.Todo,
                    Categories = _context.Categories.ToList()
                };
                return View(viewModel);
            }
            var userId = User.Identity.GetUserId();
            var newTodo = new Todo()
            {
                Description = model.Todo.Description,
                DueDate = model.Todo.DueDate,
                CategoryId = model.Todo.CategoryId,
                UserId = userId
            };

            _context.Todos.Add(newTodo);
            _context.SaveChanges();
            return RedirectToAction("Index", "Todos");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var todoInDb = _context.Todos
                .Include(t => t.Category)
                .SingleOrDefault(t => t.Id == id && t.UserId == userId);
            if (todoInDb == null)
            {
                return HttpNotFound();
            };

            _context.Todos.Remove(todoInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Todos");
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var userId = User.Identity.GetUserId();
            var todoInDb = _context.Todos
                .Include(t => t.Category)
                .SingleOrDefault(t => t.Id == id && t.UserId == userId);
            if (todoInDb == null)
            {
                return HttpNotFound();
            };
            return View(todoInDb);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id && t.UserId == userId);
            if (todoInDb == null)
            {
                return HttpNotFound();
            };
            var viewModel = new TodoCategoriesViewModel
            {
                Todo = todoInDb,
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(TodoCategoriesViewModel model)
        {
            var userId = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                var viewModel = new TodoCategoriesViewModel
                {
                    Todo = model.Todo,
                    Categories = _context.Categories.ToList()
                };
                return View(viewModel);
            }
            var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == model.Todo.Id && t.UserId == userId);
            if (todoInDb == null)
            {
                return HttpNotFound();
            }
            todoInDb.Description = model.Todo.Description;
            todoInDb.DueDate = model.Todo.DueDate;
            todoInDb.CategoryId = model.Todo.CategoryId;

            _context.SaveChanges();
            return RedirectToAction("Index", "Todos");
        }
        [HttpGet]
        public ActionResult Stats()
        {
            var userId = User.Identity.GetUserId();

            var stats = _context.Todos
                .Where(t => t.UserId == userId)
                .GroupBy(t => t.Category, (key, value) => new Stats { Category = key, Count = value.Count() })
                .ToList();

            return View(stats);
        }

    }
}