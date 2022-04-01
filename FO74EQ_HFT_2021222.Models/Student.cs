using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.Models
{
    public class Student
    {
        public Student()
        {
            GradeBooks = new HashSet<GradeBook>();
        }

        public Student(string line)
        {
            string[] split = line.Split('#');
            this.NeptunId = split[0];
            this.FirstName = split[1];
            this.LastName = split[2];
            this.DateOfBirth = DateTime.Parse(split[3].Replace('*', '.'));
            this.Email = split[4];
        }

        [Key]
        [Range(6,6)]
        [Required]
        public string NeptunId { get; set; }
        
        [Required]
        [StringLength(240)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(240)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(240)]
        public string Email { get; set; }

        public virtual ICollection<GradeBook> GradeBooks { get; set; }
    }

}
