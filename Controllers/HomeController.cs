using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
namespace ConsoleApplication.controllers{
	//using ViewBag and View() , i need to inherit from Controller
	public class HomeController:Controller{
		//[HttpGet("home/first")]
		public ActionResult index(String param,String id){
			ViewBag.message = "hi Rick , (Get)first MVC. "+param ;
			ViewBag.Time = DateTime.Now;
			Console.Write(id+"\n");
			//Console.Write(Request.QueryString["id"]+"\n");
			Console.Write(HttpContext.Request+"\n");
			return View("~/Views/index.cshtml"); // => v.cshtml "~/Views/first.cshtml"
		}
		
	}
}