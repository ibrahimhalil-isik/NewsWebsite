using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public string CommentTitle { get; set; }
        public DateTime CommentDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int NewsId { get; set; }
        public bool CommentStatus { get; set; }
    }
}
