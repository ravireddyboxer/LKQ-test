using System.Diagnostics;

namespace Test.API.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentType { get; set; } // Debit or Credit
        public decimal ? PaymentAmount { get; set; }
        public int ProjectId { get; set; }
    }
}
