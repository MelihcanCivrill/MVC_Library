using MVC_Library.Models.ORM.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Library.Models.ORM.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
            Database.Connection.ConnectionString = @"Server=.;Database=MVCLibrary;Integrated Security= True";
        }

        public DbSet<Book> Books { get; set; }

    }
}