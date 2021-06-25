using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class SubjectMarksModel
    {
        public int StudentId { get; set; }
        public string SubjectName { get; set; }
        public decimal Marks { get; set; }
    }
}