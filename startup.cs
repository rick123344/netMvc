using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApplication{
	public class Startup{
		public void ConfigureServices(IServiceCollection services){
			services.AddMvc();
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
}