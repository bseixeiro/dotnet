using System.ComponentModel.DataAnnotations;

namespace mvc.Models.Teacher;

public class Teacher : Account
{
    [Display(Name = "Sp�cialit�")]
    public string Major { get; set; }
}
