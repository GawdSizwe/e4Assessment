using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Data.Entites
{
    /// <summary>
    /// A Student with Id, Name, Surname and Grade fields
    /// </summary>
    public class Student
    {
        /// <summary>
        /// The id of a student 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Name(s) of a student
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        /// <summary>
        /// The Surname of a student
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Surname { get; set; }

        /// <summary>
        /// The Grade of a student
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Grade { get; set; }
    }
}
