using MVC_Library.Models.ORM.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Library.Models.ORM.Entities.Concrete
{
    public class Book:BaseEntity
    {
        
        public string Title { get; set; }
       
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        
        public string Genre { get; set; }
    }
}