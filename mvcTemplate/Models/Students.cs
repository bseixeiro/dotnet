using System.ComponentModel.DataAnnotations;

namespace mvc.Models;

public class Student : Account
{
    public double GPA { get; set; }

    [Required(ErrorMessage = "Veuillez sélectionner une spécialité.")]
    [Display(Name = "Spécialité")]
    public string Major { get; set; }

    [Required(ErrorMessage = "Veuillez sélectionner une date d'admission.")]
    [DataType(DataType.Date)]
    [Display(Name = "Date d'Admission")]
    public DateTime AdmissionDate { get; set; }
}