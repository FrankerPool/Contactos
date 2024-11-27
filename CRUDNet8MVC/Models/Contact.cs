using System.ComponentModel.DataAnnotations;

namespace CRUDNet8MVC.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is REQUIRED")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone number is REQUIRED")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Mobile number is REQUIRED")]
        public string PhoneNumberMobile {  get; set; }
        [Required(ErrorMessage = "Email is REQUIRED")]
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
