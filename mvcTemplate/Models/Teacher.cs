using System.ComponentModel.DataAnnotations;

namespace mvc.Models;

public class Teacher : Account
{
    public string Major { get; set; }
}
