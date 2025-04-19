namespace AccountManagementSystem.Models
{
    public class AddCustomerDto
    {
        // DTO (Data Transfer Object) for adding a new customer
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
}
