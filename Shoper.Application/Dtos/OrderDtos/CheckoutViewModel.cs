namespace ShoperApplication.Dtos.OrderDtos
{
    public class CheckoutViewModel
    {
        public int CartId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ShoperApplication.Dtos.CartDtos.GetByIdCartDto Cart { get; set; }
    }
} 