using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace ConsoleApplication.controllers{
	// to be controller , two important point
	// 1. => call class name end by "Controller" ,eg.=>testController(called POCO)
	// 2. => class derive Controller ,eg.=> testClass : Controller
	public class ApiController{
		//[HttpGet("api/home")]
		public object home(){
			return new{
				message = "hi rick , first MVC asp ",
				time = DateTime.Now
			};
		}
	}
}