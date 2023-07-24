namespace Test.API.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int Customerid { get; set; }
        public int ProjectId { get;set; }
        public string BillingType { get; set; }
        public decimal BillCost { get;set; }
    }
}
