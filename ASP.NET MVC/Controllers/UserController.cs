using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserManagementApp.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, FirstName = "Simon", LastName = "Anderson", Email = "john.doe@example.com", RegistrationDate = DateTime.Now },
            new User { Id = 2, FirstName = "Jane", LastName = "Lee", Email = "jane.smith@example.com", RegistrationDate = DateTime.Now } ,
            new User { Id=3, FirstName = "Mariia", LastName = "Elis", Email = "marymary123@example.com", RegistrationDate= DateTime.Now },
        };

        public IActionResult Index()
        {
            return View(users);
        }

        public IActionResult Details(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = users.Max(u => u.Id) + 1;
            user.RegistrationDate = DateTime.Now;
            users.Add(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            users.Remove(user);
            return RedirectToAction(nameof(Index));
        }

    }

}
