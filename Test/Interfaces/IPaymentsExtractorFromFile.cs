using Test.API.Models;

namespace Test.API.Interfaces
{
    public interface IPaymentsExtractorFromFile
    {
        List<Payment> ExtractAllPaymentsFromInputFile(byte[] file);
    }
}