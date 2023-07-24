namespace Test.API.Models
{
    public class BillingRates
    {
        public int Id { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal PricePerMilestone { get; set; }
    }
}
