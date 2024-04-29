using Shared.Dtos;

namespace WebUI.Models
{
	public class NewsViewModel
	{
		public List<CategoryDto> Category { get; set; }
        public List<NewsDto> News { get; set; }
    }
}
