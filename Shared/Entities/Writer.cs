using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Image { get; set; }        
        public string Email { get; set; }
        public string Password { get; set; }
        public bool WriterStatus { get; set; }

    }
}
