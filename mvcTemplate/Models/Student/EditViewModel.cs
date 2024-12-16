using System.ComponentModel.DataAnnotations;

namespace mvc.Models.Student
{
    public class EditViewModel
    {
        public string Id { get; set; } // Nécessaire pour identifier l'étudiant à modifier

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "Nom")]
        public string Lastname { get; set; }

        [Range(16, 100, ErrorMessage = "L'âge doit être compris entre 16 et 100 ans.")]
        [Required(ErrorMessage = "L'âge est obligatoire.")]
        [Display(Name = "Âge")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une spécialité.")]
        [Display(Name = "Spécialité")]
        public string Major { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une date d'admission.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date d'Admission")]
        public DateTime AdmissionDate { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse email valide.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Range(0, 4, ErrorMessage = "Le GPA doit être compris entre 0.0 et 4.0.")]
        [Display(Name = "Moyenne (GPA)")]
        public double GPA { get; set; }
    }
}
