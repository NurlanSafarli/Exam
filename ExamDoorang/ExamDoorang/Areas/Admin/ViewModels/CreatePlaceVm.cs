using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDoorang.Areas.Admin.ViewModels
{
    public class CreatePlaceVm
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
    }
}
