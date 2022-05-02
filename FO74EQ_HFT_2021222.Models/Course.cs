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
    public class Course
    {
        public Course()
        {
            GradeBooks = new HashSet<GradeBook>();
            InverseRequirement = new HashSet<Course>();
        }

        public Course(string line)
        {
            string[] split = line.Split('#');
            this.CourseId = int.Parse(split[0]);
            this.Name = split[1];
            this.DateOfAnnounced = DateTime.Parse(split[2].Replace('*', '.'));
            this.Credit = int.Parse(split[3]);
            this.ClassRoomId = int.Parse(split[4]);
            this.RequirementId = int.Parse(split[5]);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CourseId { get; set; }

        [Required]
        [StringLength(240)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfAnnounced { get; set; }

        [Range(1,99)]
        public int Credit { get; set; }

        [Required]
        [ForeignKey(nameof(ClassRoom))]
        public int ClassRoomId { get; set; }

        [Required]
        [ForeignKey(nameof(Requirement))]
        public int? RequirementId { get; set; }

        [JsonIgnore]
        public virtual ClassRoom ClassRoom { get; set; }

        [JsonIgnore]
        public virtual Course Requirement { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<GradeBook> GradeBooks { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Course> InverseRequirement { get; set; }
    }

}
