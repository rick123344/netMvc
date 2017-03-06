using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
				.UseContentRoot(Directory.GetCurrentDirectory()) //access view
				.UseKestrel()	//services api
				.UseStartup<Startup>() //Startup class in startup.cs
				.UseUrls("http://localhost:5050") //base url
				.Build();
			Console.Write("Server Run~~\n");
			host.Run();
        }
    }
	
	// to be controller , two important point
	// 1. => call class name end by "Controller" ,eg.=>testController(called POCO)
	// 2. => class derive Controller ,eg.=> testClass : Controller
	/*public class ApiController{
		[HttpGet("api/home")]
		public object add_home(){
			return new{
				message = "hi rick , first MVC asp ",
				time = DateTime.Now
			};
		}
	}
	//using ViewBag and View() , i need to inherit from Controller
	public class HomeController:Controller{
		[HttpGet("home/first")]
		public ActionResult firstMvc(){
			ViewBag.message = "hi Rick , first MVC.";
			ViewBag.Time = DateTime.Now;
			Console.Write(Directory.GetCurrentDirectory());
			return View("~/Views/first.cshtml"); // => v.cshtml
		}
	}*/
}
