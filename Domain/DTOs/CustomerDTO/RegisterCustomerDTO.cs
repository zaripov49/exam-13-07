using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.CustomerDTO;

public class RegisterCustomerDTO
{
    [Required]
    public string FullName { get; set; } = null!;

    [Required]
    public string Phone { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required, MinLength(4)]
    public string Password { get; set; } = null!;
}
