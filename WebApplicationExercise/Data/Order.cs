namespace WebApplicationExercise.Data
{
    public class Order
    {
        public short ID { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public short CustomerID { get; set; }
    }
}
