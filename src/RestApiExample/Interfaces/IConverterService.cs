using RestApiExample.Model;

namespace RestApiExample.Interfaces
{
    public interface IConverterService
    {
        Document ConvertToPdf(Document document);
    }
}
