using Shared.Dtos;

namespace WebUI.Models
{
	public class HomeViewModel
	{
		public List<SlideDto> Slide { get; set; }
		public List<NewsDto> News { get; set; }
	}
}
