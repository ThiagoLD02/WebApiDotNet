namespace WebApplicationExercise.DTO.Orders
{
    public class OrderDTO
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public short CustomerID { get; set; }
    }
}
