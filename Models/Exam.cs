using System;
using System.Collections.Generic;

namespace ASP.NET.Models
{
    public partial class Exam
    {
        public int IdExam { get; set; }
        public int IdSubject { get; set; }
        public string? Tittle { get; set; }
        public int? Value { get; set; }

        public virtual Subject IdSubjectNavigation { get; set; } = null!;
    }
}
