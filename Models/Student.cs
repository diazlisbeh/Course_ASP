using System;
using System.Collections.Generic;

namespace ASP.NET.Models
{
    public partial class Student
    {
        public int IdStudent { get; set; }
        public int IdSchool { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? Age { get; set; }

        public virtual School IdSchoolNavigation { get; set; } = null!;
    }
}
