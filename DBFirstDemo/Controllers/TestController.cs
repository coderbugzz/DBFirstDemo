using DBFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBFirstDemo.Controllers
{
    public class TestController : Controller
    {
        Service.Services services = new Service.Services();
        public ActionResult Index()
        {
            UserViewModel model = new UserViewModel();
            model.user_list = services.GetUsers();
            ViewBag.Method = "Register";
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserViewModel _user)
        {
            if (_user.user_data != null)
            {
                user data = new user()
                {
                    FirstName = _user.user_data.FirstName,
                    LastName = _user.user_data.LastName,
                    MiddleName = _user.user_data.MiddleName,
                    Contact = _user.user_data.Contact
                };

                var result = services.Insert_data(data);

                return RedirectToAction("Index");


            }

            ModelState.AddModelError("","");

            ViewBag.Method = "Register";

            return View(_user);
        }

        [HttpGet]
        public ActionResult EditUser(int Id)
        {
            
            
            UserViewModel model = new UserViewModel();
            model.user_list = services.GetUsers();
            model.user_data = services.GetUserById(Id);

            ViewBag.Method = "Edit";

            return View("Index",model);
        }
        [HttpPost]
        public ActionResult EditUser(UserViewModel _user)
        {

            if (_user.user_data != null)
            {
                user data = new user()
                {
                    ID = _user.user_data.ID,
                    FirstName = _user.user_data.FirstName,
                    LastName = _user.user_data.LastName,
                    MiddleName = _user.user_data.MiddleName,
                    Contact = _user.user_data.Contact
                };

                var result = services.UpdateUser(data);

                return RedirectToAction("Index");
            }

            

            ViewBag.Method = "Register";

            return View("Index");
        }

        [HttpGet]
        public ActionResult DeleteUser(int Id)
        {
             services.Delete(Id);
            
            return RedirectToAction("Index");
        }
    }
}
