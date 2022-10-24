using System;
using System.Collections.Generic;

namespace ASP.NET.Models
{
    public partial class Tandum
    {
        public Tandum()
        {
            Courses = new HashSet<Course>();
        }

        public int IdTanda { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
