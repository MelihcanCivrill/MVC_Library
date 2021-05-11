using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Library.Models.DTO
{
    public class CreateBookDTO

    {
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Content { get; set; }
       
        [DataType(DataType.Text)]
        public string ImageUrl { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Genre { get; set; }
    }
}