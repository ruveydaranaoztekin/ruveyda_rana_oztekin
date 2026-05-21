using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCoreMVCCodeFirst._24._03._2023_22.Models
{
    public class Student
    {
        [Key]
        public int StudentdsID { get; set; }

        [MaxLength(50)]
        public string StudentdsNo { get; set; }

        [MaxLength(100)]
        public string StudentdsName { get; set; }

        [MaxLength(100)]
        public string StudentdsSurname { get; set; }

        [MaxLength(100)]
        public string EMail { get; set; }

        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
    }
}