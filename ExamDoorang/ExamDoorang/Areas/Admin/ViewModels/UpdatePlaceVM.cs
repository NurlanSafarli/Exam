namespace ExamDoorang.Areas.Admin.ViewModels
{
    public class UpdatePlaceVM
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }

        public IFormFile Photo { get; set; }
        public string PhotoUrl { get; set; }
    }
}
