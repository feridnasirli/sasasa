using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anray.Models
{
    public class Team
    {
        public int Id { get; set; }
        [StringLength(maximumLength:30)]
        public string FullName { get; set; }
        [StringLength(maximumLength: 300)]
        public string Title { get; set; }
        public string RedirectUrl { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
