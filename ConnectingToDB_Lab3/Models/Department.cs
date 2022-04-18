using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectingToDB_Lab3.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptId { get; set; }
        public String Name { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public Department()
        {
            Students = new HashSet<Student>();
        }


    }
}
