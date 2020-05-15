using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must be greater than {2} characters and less than {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Url Slug")]
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must be greater than {2} characters and less than {1} characters", MinimumLength =3)]
        public string UrlSlug { get; set; }
        
        [StringLength(1024, ErrorMessage = "The {0} must be greater than {2} characters and less than {1} characters", MinimumLength = 3)]
        public string Description { get; set; }
    }
}
