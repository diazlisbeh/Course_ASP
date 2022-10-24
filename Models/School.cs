using System;
using System.Collections.Generic;

namespace ASP.NET.Models
{
    public partial class School
    {
        public School()
        {
            Students = new HashSet<Student>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Country { get; set; }
        public string? City { get; set; }
        public DateOnly? AnioCreacion { get; set; }
        public TypeSchool TypeSchool {get;set;}

        public virtual ICollection<Student> Students { get; set; }
    }

    public enum TypeSchool {
        Primaria,
        Secundaria,
        Tecnico
    }
}
