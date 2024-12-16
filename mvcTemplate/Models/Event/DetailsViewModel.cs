using System.ComponentModel.DataAnnotations;

namespace mvc.Models.Event
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date de l'événement")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Nombre maximum de participants")]
        public int MaxParticipants { get; set; }

        public string Location { get; set; }

        [Display(Name = "Date de création")]
        public DateTime CreatedAt { get; set; }
    }
}
