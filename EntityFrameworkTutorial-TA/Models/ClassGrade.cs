using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkTutorial_TA.Models
{
    public partial class ClassGrade
    {
        public ClassGrade()
        {
            StudentClasses = new HashSet<StudentClass>();
        }

        public string Grade { get; set; }
        public decimal Gpa { get; set; }

        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
