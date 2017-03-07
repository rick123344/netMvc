using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
namespace ConsoleApplication.controllers{
	//using ViewBag and View() , i need to inherit from Controller
	public class HomeController:Controller{
		//[HttpGet("home/first")]
		public ActionResult index(String param,String id){
			ViewBag.message = "hi Rick , (Get)first MVC. "+param ;
			ViewBag.Time = DateTime.Now;
			Console.Write(id+"\n");
			//Console.Write(Request.QueryString["id"]+"\n");
			return View(); // => v.cshtml "~/Views/home/index.aspx"
		}
		
		public ActionResult getJson(){
			Dictionary<String,String> dic = new Dictionary<String,String>();
			dic.Add("First","I'm First Element");
			dic.Add("Second","Yes Man");
			return Content(JsonConvert.SerializeObject(dic), "application/json");
		}
		public ActionResult getJson2(){
			ViewBag.msg = "IM MSG";
			ViewData["QQ"] = "QQQ";
			return Content(JsonConvert.SerializeObject(ViewBag), "application/json");
		}
	}
}