namespace Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public string? Model { get; set; }
    public string? Manufacturer { get; set; }
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }

    // navigation
    public List<Rental>? Rentals { get; set; }
}
