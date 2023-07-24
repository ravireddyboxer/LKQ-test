using Microsoft.AspNetCore.Mvc;
using Test.API.DataAccess;
using Test.API.Interfaces;
using Test.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IInvoiceCreator _invoiceCreator; // Creates invoices for each project by getting the data from the database
        private readonly IPaymentsExtractorFromFile _paymentsExtractorFromFile; // Create payments by extracting the data from the uploaded file
        private readonly IInvoiceAndPaymentsComparer _invoiceAndPaymentsComparer; // Compared both the invoices and payments and return the fulfilled invoices

        public TransactionController(AppDbContext context, IInvoiceCreator invoiceCreator, IPaymentsExtractorFromFile paymentsExtractorFromFile, IInvoiceAndPaymentsComparer invoiceAndPaymentsComparer)
        {
            _context = context;
            _invoiceCreator = invoiceCreator;
            _paymentsExtractorFromFile = paymentsExtractorFromFile;
            _invoiceAndPaymentsComparer = invoiceAndPaymentsComparer;
        }


        // POST api/<TransactionController>
        [HttpPost]
        public  IActionResult OnFileUploadAsync([FromBody] IFormFile uploadedFile)
        {
            // Create invoices for each project based on the billing type and the billing rates
            List<Invoice> invoices = _invoiceCreator.CreateInvoices();

            // Extract all the payments from the input file to Payment objects
            MemoryStream byteArray = new MemoryStream();
            uploadedFile.CopyTo(byteArray);
            List<Payment> paymentsExtractedFromInputFile = _paymentsExtractorFromFile.ExtractAllPaymentsFromInputFile(byteArray.ToArray());


            // Now compare the invoices and payments for reconcilation
            List<Invoice> fulfilledInvoices = _invoiceAndPaymentsComparer.GetFulfilledInvoices(invoices, paymentsExtractedFromInputFile);
            return  Ok(fulfilledInvoices);
        }


    }
}
