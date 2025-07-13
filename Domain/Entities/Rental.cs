namespace Domain.Entities;

public class Rental
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public int BranchId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalCost { get; set; }

    // navigation
    public Car? Car { get; set; }
    public Customer? Customer { get; set; }
    public Branch? Branch { get; set; }
}
