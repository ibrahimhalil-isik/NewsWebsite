namespace AdminUI.Models
{
	public class WriterViewModel
	{
		public int WriterId { get; set; }
		public string Name { get; set; }
		public string SurName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
        public string Image { get; set; }
        public IFormFile? ImageFile { get; set; }
		public bool WriterStatus { get; set; }
	}
}
