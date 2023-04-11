using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using TestSqlSugar.Models;

namespace TestSqlSugar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Test()
        {
            TestDB.createDB();
            return View();
        }
        [HttpGet]
        public IActionResult TestList()
        {
            return View("TestList",TestDB.admin());
        }


        [HttpGet]
        public IActionResult Index()
        {
            var list = SqlDB.admins().ToList();
            return View("index",list);
        }

        [HttpPost]
        public IActionResult Index(string id,string name,string password)
        {
            Admins admin = SqlDB.admins().ToList().Where(a => a.id == id).First();
            admin.name = name;
            admin.Password = password;
            SqlDB.upadmin(admin,id) ;

            var list = SqlDB.admins().ToList();
            return View("index", list);
        }
    }
}