﻿using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
		public ActionResult Index()
		{
			return View();
        }

        public ActionResult About()
        {

            return View();
        }
		
    }
}