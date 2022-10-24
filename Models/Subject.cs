using System;
using System.Collections.Generic;

namespace ASP.NET.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Exams = new HashSet<Exam>();
        }

        public int IdSubject { get; set; }
        public int IdCourse { get; set; }
        public string? Name { get; set; }
        public int? Calification { get; set; }

        public virtual Course IdCourseNavigation { get; set; } = null!;
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
