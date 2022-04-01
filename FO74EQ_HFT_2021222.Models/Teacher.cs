using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.Models
{
    public class Teacher
    {
        public Teacher()
        {
            GradeBooks = new HashSet<GradeBook>();
        }

        public Teacher(string line)
        {
            string[] split = line.Split('#');
            this.TeacherId = int.Parse(split[0]);
            this.LastName = split[1];
            this.FirstName = split[2];
            this.Salary = int.Parse(split[3]);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int TeacherId { get; set; }

        [Required]
        [StringLength(240)]
        public string LastName { get; set; }

        [Required]
        [StringLength(240)]
        public string FirstName { get; set; }

        [Range(0,1000000)]
        public int Salary { get; set; }

        public virtual ICollection<GradeBook> GradeBooks { get; set; }
    }

}
