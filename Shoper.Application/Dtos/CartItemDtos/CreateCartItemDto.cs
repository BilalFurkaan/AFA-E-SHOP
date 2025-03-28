namespace ShoperApplication.Dtos.CartItemDtos;

public class CreateCartItemDto
{

    public int CartId { get; set; }
    public int ProductId { get; set; }
    //public Product Products { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}