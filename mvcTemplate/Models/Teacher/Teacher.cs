using System.ComponentModel.DataAnnotations;

namespace mvc.Models.Teacher;

public class Teacher : Account
{
    [Display(Name = "Spécialité")]
    public string Major { get; set; }
}
