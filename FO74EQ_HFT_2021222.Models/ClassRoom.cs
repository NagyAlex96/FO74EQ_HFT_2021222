using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConcept.Models
{
    public class ClassRoom
    {
        public ClassRoom()
        {
            Courses = new HashSet<Course>();
        }

        public ClassRoom(string line)
        {
            string[] split = line.Split('#');
            this.ClassRoomId = int.Parse(split[0]);
            this.Capacity = int.Parse(split[1]);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ClassRoomId { get; set; }

        [Range(1,500)]
        public int Capacity { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
