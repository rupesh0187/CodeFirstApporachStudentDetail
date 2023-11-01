using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentDetail.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("FirstName", TypeName = "varchar(15)")]
        [Required]
        public string? FirstName { get; set; }

        [Column("LastName", TypeName = "varchar(15)")]
        [Required]
        public string? LastName { get; set; }

        [Column("Email", TypeName = "varchar(50)")]
        [Required]
        public string? EmailAddress { get; set; }

        [Column("MobileNo", TypeName = "varchar(10)")]
        
        public string? PhoneNumber { get; set; }

        [Column("Gender", TypeName = "varchar(5)")]
        [Required]
        public string? Gender { get; set; }
    }
}
