using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Northwind.Controllers
{
    public class EmployeeController : Controller
    {
        // this controller depends on the NorthwindRepository & the UserManager
        private NorthwindContext _northwindContext;
        private UserManager<AppUser> _userManager;
        public EmployeeController(NorthwindContext db, UserManager<AppUser> usrMgr)
        {
            _northwindContext = db;
            _userManager = usrMgr;
        }
        [Authorize(Roles = "northwind-employee")]
        //TODO: change Account() to route to Inventory Management
        public IActionResult Account() => View(_northwindContext.Employees.FirstOrDefault(c => c.Email == User.Identity.Name));

    }
}