using MyFirstWebApp.DataBase;
using MyFirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            if (ModelState.IsValid)
            {
                if (objectUserEntities.UsersTables.Where(m1 => m1.Email == objectuser.Email).FirstOrDefault() == null)
                {
                    UsersTable UserTable1 = new UsersTable();
                    UserTable1.CreatedOn = (DateTime.Now);
                    UserTable1.FirstName = objectuser.FirstName;
                    UserTable1.LastName = objectuser.LastName;
                    UserTable1.Email = objectuser.Email;
                    UserTable1.PassWord = objectuser.PassWord;
                    objectUserEntities.UsersTables.Add(UserTable1);
                    objectUserEntities.SaveChanges();
                    objectuser.successmessage = "User Registered successfully";

                    return RedirectToAction("Login", "Account");
                    
                }
                else
                {
                    ModelState.AddModelError("Error", "Email Already exists");
                    return View();
                }
                
            }

            return View();

        }

        public ActionResult Login()
        {
            UserLogin objectlogin = new UserLogin();
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin objectlogin)
        {
            if (ModelState.IsValid)
            {
                if (objectUserEntities.UsersTables.Where(m1=>m1.Email == objectlogin.Email && m1.PassWord == objectlogin.PassWord).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Email or Password Not correct");
                    return View();
                }
                else
                {
                    Session["Email"] = objectlogin.Email;
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}