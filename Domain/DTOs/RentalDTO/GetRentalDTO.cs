namespace Domain.DTOs.RentalDTO;

public class GetRentalDTO : CreateRentalDTO
{
    public int Id { get; set; }
    public decimal TotalCost { get; set; }
}
