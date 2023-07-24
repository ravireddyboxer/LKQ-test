using Test.API.Models;

namespace Test.API.Interfaces
{
    public interface IInvoiceAndPaymentsComparer
    {
        List<Invoice> GetFulfilledInvoices(List<Invoice> invoices, List<Payment> payments);
    }
}