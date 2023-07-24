using Test.API.Models;

namespace Test.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }

        public ProjectBillingMode ProjectBillingMode { get; set; }

        public BillingRates BillingRates { get; set; }
    }
}
