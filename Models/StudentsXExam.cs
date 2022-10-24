using System;
using System.Collections.Generic;

namespace ASP.NET.Models
{
    public partial class StudentsXExam
    {
        public int? IdExam { get; set; }
        public int? IdStudent { get; set; }

        public virtual Exam? IdExamNavigation { get; set; }
        public virtual Student? IdStudentNavigation { get; set; }
    }
}
