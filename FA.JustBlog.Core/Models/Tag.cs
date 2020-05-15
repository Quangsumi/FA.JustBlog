using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tag Name")]
        [Required(ErrorMessage = "The {0} is required.")]
        [StringLength(255, ErrorMessage = "The {} must be greater than {2} characters and less than {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Url Slug")]
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must be greater than {2} characters and less than {1} characters", MinimumLength = 3)]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(1024, ErrorMessage = "The {0} must be greater than {2} characters and less than {1} characters", MinimumLength = 3)]
        public string Description { get; set; }

        [DefaultValue(0)]
        public int Count { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}
