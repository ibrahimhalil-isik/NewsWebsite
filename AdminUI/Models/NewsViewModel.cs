using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminUI.Models
{
	public class NewsViewModel
	{
		public int NewsId { get; set; }
		public string Title { get; set; }
		public string Contents { get; set; }
		public DateTime? NewsDate { get; set; }
		public int ClicksNumber { get; set; }
		public string Image { get; set; }
		public IFormFile? ImageFile { get; set; }
		public string Video { get; set; }
		public IFormFile? VideoFile { get; set; }
		public int WriterId { get; set; }
		public int CategoryId { get; set; }
		public bool NewsStatus { get; set; }

		public List<SelectListItem>? Writer { get; set; }
		public List<SelectListItem>? Category { get; set; }
	}
}
