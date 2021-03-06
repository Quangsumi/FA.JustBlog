﻿using System;
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

        [Display(Name = "Short Description")]
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
        [DataType(DataType.DateTime, ErrorMessage = "The {0} is not correct")]
        public DateTime PostedOn { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "The {0} format is not correct")]
        public DateTime Modified { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [DefaultValue(1)]
        public int ViewCount { get; set; }

        [DefaultValue(1)]
        public int RateCount { get; set; }

        [DefaultValue(1)]
        public int TotalRate { get; set; }

        [NotMapped]
        public decimal Rate { get => TotalRate / (RateCount == 0 ? 1 : RateCount); }

        [Display(Name = "Post Content")]
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(5120, ErrorMessage = "The {0} must be greater than {2} characters and less than {1} characters", MinimumLength = 3)]
        public string PostContent { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
