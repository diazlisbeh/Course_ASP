using System;
using System.Collections.Generic;

namespace ASP.NET.Models
{
    public partial class Course
    {
        public Course()
        {
            Subjects = new HashSet<Subject>();
        }

        public int IdCourse { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? IdTanda { get; set; }

        public virtual Tandum? IdTandaNavigation { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
