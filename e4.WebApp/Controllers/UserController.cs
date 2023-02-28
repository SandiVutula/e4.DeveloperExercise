using e4.WebApp.Model;
using e4.WebApp.Service;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;

namespace e4.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly IWebHostEnvironment _environment;

        public UserController(IWebHostEnvironment environment)
        {
            _environment = environment;
            string xmlFilePath = Path.Combine(_environment.ContentRootPath, "App_Data", "Users.xml");
            _userService = new UserService(xmlFilePath);
        }

        public ActionResult Index()
        {
            List<User> users = _userService.GetAllUsers();
            return View(users);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(User user)
        {
            _userService.AddUser(user);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string cellphone)
        {
            User user = _userService.GetAllUsers().FirstOrDefault(u => u.Cellphone == cellphone);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            _userService.EditUser(user);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string cellphone)
        {
            _userService.DeleteUser(cellphone);
            return RedirectToAction("Index");
        }
    }

}
