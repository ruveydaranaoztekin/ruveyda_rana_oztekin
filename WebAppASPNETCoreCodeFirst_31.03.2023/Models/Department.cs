using System.ComponentModel.DataAnnotations;

namespace WebAppCoreMVCCodeFirst._24._03._2023_22.Models
{
    public class Department
    {
        [Key]
        public int DeptID { get; set; }

        [MaxLength(100)]
        public string DeptName { get; set; }

        public List<Student> Students { get; set; }
    }
}