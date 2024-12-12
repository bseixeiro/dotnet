using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models;

public class Teacher : IdentityUser
{
    // [Required]
    // public int Id { get; set; }

    [Required(ErrorMessage = "Le prénom est obligatoire.")]
    [StringLength(20, MinimumLength = 2)]
    [Display(Name = "Prénom")]
    public string Firstname { get; set; }

    [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
    [StringLength(20, MinimumLength = 2)]
    [Display(Name = "Nom")]
    public string Lastname { get; set; }

    [Range(16, 100, ErrorMessage = "L'âge doit être compris entre 16 et 100 ans..")]
    [Required]
    [Display(Name = "Âge")]
    public int Age { get; set; }


    public Major Major { get; set; }
}
