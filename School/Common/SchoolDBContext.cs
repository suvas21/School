using School.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace School.Common
{
    public class SchoolDBContext: DbContext
    {
        public SchoolDBContext()
            : base("name=StudentdbContext")
        {
        }
        public DbSet<Students> students { get; set; }
        public DbSet<Subjects> subjects { get; set; }
        public DbSet<Course> courses { get; set; }
    }
}