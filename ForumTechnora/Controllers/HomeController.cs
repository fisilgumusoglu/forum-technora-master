using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace ForumTechnora.Controllers
{
    public class HomeController : Controller
    {
        UserManager um = new UserManager();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Posts()
        {
            var postItems = um.GetPost(); 
            return View(postItems);
        }
        [HttpPost]
        public ActionResult Posts(Post p)
        {
            um.CreatePost(p);
            return Redirect("/Home/Index");
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User p)
        {
            um.UserCheck(p);
            return Redirect("/Home/Index");
        }

        public ActionResult News()
        {
            return View();
        }
    }
}