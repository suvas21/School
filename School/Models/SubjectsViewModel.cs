using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class StudentsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public string SubjectName { get; set; }
        public decimal Marks { get; set; }
        public int TotalRecords { get; set; }
    }
}