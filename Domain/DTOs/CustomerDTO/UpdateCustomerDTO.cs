using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.CustomerDTO;

public class UpdateCustomerDTO
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; } = null!;

    [Required, Phone]
    public string Phone { get; set; } = null!;

    [Required, EmailAddress]
    public string Email { get; set; } = null!;
}
