using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class DetailsViewModel
    {

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }
    }
}
