﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookModels.Models
{
    public class Category
    {
        //To explicitly define primary key using annotation
        [Key]
        public int Id { get; set; }
        //To make not nullable
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order range is 1-100")]
        public int DisplayOrder { get; set; }
    }
}
