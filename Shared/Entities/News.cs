using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public DateTime NewsDate { get; set; }
        public int ClicksNumber { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public int WriterId { get; set; }
        public int CategoryId { get; set; }
        public bool NewsStatus { get; set; }
    }
}
