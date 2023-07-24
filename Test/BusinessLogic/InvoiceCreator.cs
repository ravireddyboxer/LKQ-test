using Test.API.DataAccess;
using Test.API.Interfaces;
using Test.API.Models;
using Test.Models;

namespace Test.API.BusinessLogic
{
    public class InvoiceCreator : IInvoiceCreator
    {
        private readonly AppDbContext _context;

        public InvoiceCreator(AppDbContext context)
        {
            _context = context;
        }

        public List<Invoice> CreateInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();
            List<Customer> customerList = _context.Customers.ToList();

            foreach (Customer customer in customerList)
            {
                List<Project> projects = _context.Projects.ToList();
                foreach (Project project in projects)
                {
                    Invoice invoice = new Invoice();
                    invoice.Customerid = customer.CustomerId;
                    invoice.ProjectId = project.ProjectId;
                    if (project.ProjectBillingMode.Name == "Hourly")
                    {
                        decimal totalCost = project.ProjectBillingMode.TotalHoursCompleted * project.BillingRates.PricePerHour;
                        invoice.BillingType = "Hourly";
                        invoice.BillCost = totalCost;
                    }
                    if(project.ProjectBillingMode.Name == "MileStone")
                    {
                        decimal totalCost = project.ProjectBillingMode.TotalMileStonesCompleted * project.BillingRates.PricePerMilestone;
                        invoice.BillingType = "MileStone";
                        invoice.BillCost = totalCost;
                    }
                    invoices.Add(invoice);
                }
            }
            return invoices;
        }
    }
}
