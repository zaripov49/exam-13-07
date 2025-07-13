namespace Domain.Entities;

public class Branch
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    
    // navigation
    public List<Rental>? Rentals { get; set; }
}
