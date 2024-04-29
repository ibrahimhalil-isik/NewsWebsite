using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminUI.Models
{
	public class SlideViewModel
	{
		public int SlideId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public int NewsId { get; set; }
		public string Image { get; set; }
		public IFormFile? ImageFile { get; set; }
		public bool SlideStatus { get; set; }

		public List<SelectListItem>? News { get; set; }
	}
}
