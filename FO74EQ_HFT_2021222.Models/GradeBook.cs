using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.Models
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
            this.NeptunId = int.Parse(split[1]);
            this.TeacherId = int.Parse(split[2]);
            this.CourseId = int.Parse(split[3]);
            this.Grade = int.Parse(split[4]);
            this.Rating = int.Parse(split[5]);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int GradeBookId { get; set; }

        [Required]
        [ForeignKey(nameof(Neptun))]
        [Range(1,10000)]
        public int NeptunId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        [Range(1,5)]
        public int Grade { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }

        [JsonIgnore]
        public virtual Course Course { get; set; }
        
        [JsonIgnore]
        public virtual Student Neptun { get; set; }

        [JsonIgnore]
        public virtual Teacher Teacher { get; set; }
    }

}
