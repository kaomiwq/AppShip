using System.ComponentModel.DataAnnotations;

namespace AppShip.ActionClass.HelperClass.DTO
{
    public class ClientsDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
