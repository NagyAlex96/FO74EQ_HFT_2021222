using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConcept.Models
{
    public class GradeBook
    {
        public GradeBook()
        {

        }

        public GradeBook(string line)
        {
            string[] split = line.Split('#');
            this.GradeBookId = int.Parse(split[0]);
            this.NeptunId = split[1];
            this.TeacherId = int.Parse(split[2]);
            this.CourseId = int.Parse(split[3]);
            this.Grade = int.Parse(split[4]);
            this.Rating = int.Parse(split[5]);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int GradeBookId { get; set; }

        [Range(6, 6)]
        [Required]
        public string NeptunId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int TeacherId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CourseId { get; set; }

        [Range(1,5)]
        public int Grade { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Neptun { get; set; }
        public virtual Teacher Teacher { get; set; }
    }

}
