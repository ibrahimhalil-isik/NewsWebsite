using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class Slide
    {
        [Key]
        public int SlideId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int NewsId { get; set; }
        public string Image { get; set; }
        public bool SlideStatus { get; set; }
    }
}
