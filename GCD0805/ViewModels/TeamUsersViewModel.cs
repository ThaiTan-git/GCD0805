using GCD0805.Models;
using System.Collections.Generic;

namespace GCD0805.ViewModels
{
    public class TeamUsersViewModel
    {
        public Team Team { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}