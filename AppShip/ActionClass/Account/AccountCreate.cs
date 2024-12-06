using System.ComponentModel.DataAnnotations;
namespace AppShip.ActionClass.Account
{
    public class AccountCreate
    {
        [Required]
        public string Name { get; set; } 
        [Required]
        public string PhoneNumber { get; set; }
    }
}
