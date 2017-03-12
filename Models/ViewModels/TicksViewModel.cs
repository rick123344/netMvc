using System;
using System.ComponentModel.DataAnnotations;//do annotation , such as [Required]
using System.Linq;
using System.Threading.Tasks;
namespace ConsoleApplication.Models.ViewModels{
	
	public class TicksViewModel{
        [Required]
        public string id { get; set; }

		[Display(Name = "Tickssss")]
        public string tick { get; set; }
    }
	
}