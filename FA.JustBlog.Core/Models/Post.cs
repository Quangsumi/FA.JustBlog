using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} name is required")]
        [StringLength(255, ErrorMessage = "The {0} must be greater than {2} characters and less than {1} characters", MinimumLength = 3)]
        public string Title { get; set; }

        [Column("Short Description")]
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(1024, ErrorMessage = "The {0} must be greater than {2} characters and less than {1} characters", MinimumLength = 3)]
        public string ShortDescription { get; set; }

        [MaxLength(510, ErrorMessage ="The {0} must be less than {1} characters")]
        public string Meta { get; set; }

        [Display(Name = "Url Slug")]
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must be greater than {1} characters and less than {1} characters", MinimumLength = 3)]
        public string UrlSlug { get; set; }

        [DefaultValue(false)]
        [Required(ErrorMessage = "The {0} is required")]
        public bool Published { get; set; }

        [Display(Name = "Posted On")]
        [DataType(DataType.Time, ErrorMessage = "The {0} is not correct")]
        public DateTime PostedOn { get; set; }

        [DataType(DataType.Time, ErrorMessage = "The {0} format is not correct")]
        public DateTime Modified { get; set; }

        public int CategoryId { get; set; }

        [DefaultValue(0)]
        public int ViewCount { get; set; }

        [DefaultValue(0)]
        public int RateCount { get; set; }

        [DefaultValue(0)]
        public int TotalRate { get; set; }

        [NotMapped]
        public decimal Rate { get => TotalRate / RateCount; }

        [Display(Name = "Post Content")]
        [Required(ErrorMessage = "The {} is required")]
        [StringLength(5120, ErrorMessage = "The {} must be greater than {2} characters and less than {1} characters", MinimumLength = 3)]
        public string PostContent { get; set; }

        public virtual IList<Tag> Tags { get; set; }
        public virtual IList<Comment> Comments { get; set; }
    }
}
