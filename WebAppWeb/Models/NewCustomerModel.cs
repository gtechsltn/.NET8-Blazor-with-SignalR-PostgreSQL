using System.ComponentModel.DataAnnotations;

namespace WebAppWeb.Models
{
    public class NewCustomerModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
