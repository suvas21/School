﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School.Models
{
    [Table("TblSubjects")]
    public class Subjects
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}