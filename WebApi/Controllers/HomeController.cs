﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
	public class HomeController : Controller
	{
		

		public HomeController()
		{

		}

		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
		}
	}
}
