using System;
using System.Collections.Generic;

namespace ConsoleCRUD.Models
{
    public partial class Student
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }
    }
}
