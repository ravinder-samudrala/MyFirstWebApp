using MyFirstWebApp.DataBase;
using MyFirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstWebApp.Controllers
{
    public class AccountController : Controller
    {
        UserDBEntities1 objectUserEntities = new UserDBEntities1();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
        UserModel objectuser=new UserModel();
            return View(objectuser);
        }
        [HttpPost]
        public ActionResult Register(UserModel objectuser)
        {
            UsersTable UserTable1 = new UsersTable();
            UserTable1.CreatedOn = (DateTime.Now);
            UserTable1.FirstName = objectuser.FirstName;
            UserTable1.LastName = objectuser.LastName;
            UserTable1.Email = objectuser.Email;
            UserTable1.PassWord = objectuser.PassWord;
            objectUserEntities.UsersTables.Add(UserTable1);
            objectUserEntities.SaveChanges();

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}