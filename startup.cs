using System;
using System.IO;
using System.Linq;//union
using System.Collections.Generic;//IEnumerable
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft​.AspNetCore​.Mvc​.Razor;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
namespace ConsoleApplication{
	public class Startup{
		public void ConfigureServices(IServiceCollection services){
			
			services.AddMvc();
			services.Configure<RazorViewEngineOptions>(options => {
				options.ViewLocationExpanders.Add(new ViewLocationExpander());
			});
			Console.Write("Add Path\n");
		}
		public void Configure(IApplicationBuilder app){
			//app.UseDeveloperExceptionPage();
			app.UseMvc(routes=>{
				routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=index}/{param?}"
				);
			});
		}
		
	}
	//View Engine
	public class ViewLocationExpander: IViewLocationExpander {

		/// <summary>
		/// Used to specify the locations that the view engine should search to 
		/// locate views.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="viewLocations"></param>
		/// <returns></returns>
		public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations) {
			//{2} is area, {1} is controller,{0} is the action
			string[] locations = new string[] { "/Views/{2}/{1}/{0}.aspx"};
			return locations.Union(viewLocations);          //Add mvc default locations after ours
		}
		
		public void PopulateValues(ViewLocationExpanderContext context) {
			context.Values["customviewlocation"] = nameof(ViewLocationExpander);
		}
	}
	
}