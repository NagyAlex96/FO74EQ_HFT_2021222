using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.Models
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

        [Range(1,int.MaxValue)]
        public int Capacity { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
