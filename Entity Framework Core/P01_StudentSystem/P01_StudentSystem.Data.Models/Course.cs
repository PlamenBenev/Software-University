using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models;

public class Course
{
    public Course()
    {
        this.StudentsCourses = new HashSet<StudentCourse>();
        this.Resources = new HashSet<Resource>();
        this.Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; } 

    public string? Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal Price { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
    public virtual ICollection<Resource> Resources { get; set; }
    public virtual ICollection<Homework> Homeworks { get; set; }
}
