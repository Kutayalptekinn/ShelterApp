using System.ComponentModel.DataAnnotations;

namespace ShelterApp.Entities.Entities.Form
{
    public class Form
    {
        public string AdSoyad { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Numara { get; set; }
        public string Mesaj { get; set; }
    }
}
