using System.ComponentModel.DataAnnotations;

namespace WebAppWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
    }
}
