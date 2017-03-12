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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Diagnostics;//handle error message

namespace ConsoleApplication{
	public class Startup{
		public void ConfigureServices(IServiceCollection services){
			
			services.AddMvc();
			services.Configure<RazorViewEngineOptions>(options => {
				options.ViewLocationExpanders.Add(new ViewLocationExpander());
			});
			Console.Write("Add Path\n");
		}
		//public IConfigurationRoot Configuration { get; }
		public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory){
			
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            /*loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();*/
			app.UseStaticFiles();
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

		//Used to specify the locations that the view engine should search to 
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