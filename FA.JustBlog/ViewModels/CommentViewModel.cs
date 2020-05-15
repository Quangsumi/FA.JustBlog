using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels
{
    public class CommentViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must be greater than 3 characters and less than 255 characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "The {0} format is not correct!")]
        public string Email { get; set; }

        public int PostId { get; set; }

        [Display(Name = "Comment Header")]
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must be greater than {2} characters and less than {1} characters", MinimumLength = 3)]
        public string CommentHeader { get; set; }

        [Display(Name = "Comment Text")]
        [Required(ErrorMessage = "The {0} text is required")]
        [StringLength(1024, ErrorMessage = "The {0} text must be greater than {2} characters and less than {1} characters", MinimumLength = 3)]
        public string CommentText { get; set; }

        [DataType(DataType.Time)]
        public DateTime CommentTime { get; set; }
    }
}
