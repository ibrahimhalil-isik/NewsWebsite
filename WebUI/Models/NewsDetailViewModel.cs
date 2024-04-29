using Shared.Dtos;

namespace WebUI.Models
{
	public class NewsDetailViewModel
	{
        public NewsDto News { get; set; }
        public List<CategoryDto> Category { get; set; }
        public List<CommentDto> Comment { get; set; } = new List<CommentDto>();
    }
}
