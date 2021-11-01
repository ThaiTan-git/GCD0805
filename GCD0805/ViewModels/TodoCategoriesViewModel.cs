using GCD0805.Models;
using System.Collections.Generic;

namespace GCD0805.ViewModels
{
    public class TodoCategoriesViewModel
    {
        public Todo Todo { get; set; }
        public List<Category> Categories { get; set; }
    }
}