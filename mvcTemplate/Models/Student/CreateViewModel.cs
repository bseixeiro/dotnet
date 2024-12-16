using System.ComponentModel.DataAnnotations;

namespace mvc.Models.Student
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Le prénom doit avoir entre 2 et 20 caractères.")]
        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Le nom doit avoir entre 2 et 20 caractères.")]
        [Display(Name = "Nom")]
        public string Lastname { get; set; }

        [Range(16, 100, ErrorMessage = "L'âge doit être compris entre 16 et 100 ans.")]
        [Required(ErrorMessage = "L'âge est obligatoire.")]
        [Display(Name = "Âge")]
        public int Age { get; set; }

        [Required(ErrorMessage = "L'adresse email est obligatoire.")]
        [EmailAddress(ErrorMessage = "Veuillez saisir une adresse email valide.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères.")]
        [Display(Name = "Mot de Passe")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Veuillez confirmer le mot de passe.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Le mot de passe et sa confirmation ne correspondent pas.")]
        [Display(Name = "Confirmation du Mot de Passe")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une spécialité.")]
        [Display(Name = "Spécialité")]
        public string Major { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une date d'admission.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date d'Admission")]
        public DateTime AdmissionDate { get; set; }
    }
}
