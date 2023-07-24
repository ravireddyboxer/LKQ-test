using Test.API.Interfaces;
using Test.API.Models;

namespace Test.API.BusinessLogic
{
    public class PaymentsExtractorFromFile : IPaymentsExtractorFromFile
    {
        public List<Payment> ExtractAllPaymentsFromInputFile(byte[] file)
        {
            // Based on the type of file we have to write logic to extract the data from file
            // If the file type is excel, use excel data extractor libray
            // If pdf file use another library
            return new List<Payment> { };
        }
    }
}
