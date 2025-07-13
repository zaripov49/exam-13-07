namespace Domain.DTOs.CarDTO;

public class CreateCarDTO
{
    public string? Model { get; set; }
    public string? Manufacturer { get; set; }
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
}
