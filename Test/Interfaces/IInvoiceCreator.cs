using Test.API.Models;

namespace Test.API.Interfaces
{
    public interface IInvoiceCreator
    {
        List<Invoice> CreateInvoices();
    }
}