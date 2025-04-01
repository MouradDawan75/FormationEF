using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_DataAnnotations
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //OneToMany
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
