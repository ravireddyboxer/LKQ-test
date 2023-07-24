using Test.API.Interfaces;
using Test.API.Models;

namespace Test.API.BusinessLogic
{
    public class InvoiceAndPaymentsComparer : IInvoiceAndPaymentsComparer
    {

        public List<Invoice> GetFulfilledInvoices(List<Invoice> invoices, List<Payment> payments)
        {
            // Now compare the invoices and payments for reconcilation
            List<Invoice> fulfilledInvoices = new List<Invoice>();


            foreach (var invoice in invoices)
            {
                // Get all the payments done for a specific project
                decimal? paymentSumForProject = payments.Where(x => x.ProjectId == invoice.ProjectId).Sum(x => x.PaymentAmount);
                fulfilledInvoices.Add(invoice);

            }
            return fulfilledInvoices;
        }
    }
}
