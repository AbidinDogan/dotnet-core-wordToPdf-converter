using DocXToPdfConverter;
using RestApiExample.Interfaces;
using RestApiExample.Model;
using System;
using System.IO;

namespace RestApiExample.Services
{
    public class ConverterService: IConverterService
    {
        public Document ConvertToPdf(Document document)
        {
            string filename = Guid.NewGuid().ToString();
            string filenameDocx = $"{filename}.docx";
            string filenamePdf = $"{filename}.pdf";

            var inputData = Convert.FromBase64String(document.WordBase64);
            var inputFileLocation = Path.Combine(Environment.CurrentDirectory, filenameDocx);
            var outputFileLocation = Path.Combine(Environment.CurrentDirectory, filenamePdf);
            File.WriteAllBytes(inputFileLocation, inputData);

            var reportGenerator = new ReportGenerator("libreoffice");
            //var reportGenerator = new ReportGenerator(@"C:\Libre Office Portable\LibreOfficePortable\LibreOfficePortable.exe");
            reportGenerator.Convert(inputFileLocation, outputFileLocation, null);
            document.PdfBase64 = Convert.ToBase64String(File.ReadAllBytes(outputFileLocation));
            document.WordBase64 = null;

            File.Delete(inputFileLocation);
            File.Delete(outputFileLocation);

            return document;
        }
    }
}
