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
            : base("name=MySqlConnection")
        {
        }
        public DbSet<Students> students { get; set; }
        public DbSet<Students> subjects { get; set; }
        public DbSet<Students> courses { get; set; }
    }
}