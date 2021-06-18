using DocXToPdfConverter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApiExample.Model;
using System;
using System.IO;
using System.Net;
using Document = RestApiExample.Model.Document;

namespace RestApiExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JudgementController : Controller
    {
        private readonly ILogger<JudgementController> _logger;
        public JudgementController(ILogger<JudgementController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public string Get()
        {
            return "Hello Mate";
        }
        [HttpPost]
        public string Post(string name, bool isBeliver)
        {
            if (isBeliver)
            {
                return "Welcome " + name;
            }
            else
                return "Go back!";
        }
        [HttpPost(nameof(Filankes))]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public string Filankes(string name)
        {
            Person person = new Person(name);
            try
            {
                return person.Name;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost(nameof(ConvertToPdf))]
        [ProducesResponseType(typeof(Document), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Document), (int)HttpStatusCode.BadRequest)]
        public Document ConvertToPdf(Document document)
        {
            try
            {
                string filename = Guid.NewGuid().ToString();
                string filenameDocx = $"{filename}.docx";
                string filenamePdf = $"{filename}.pdf";

                var inputData = Convert.FromBase64String(document.WordBase64);
                var inputFileLocation = Path.Combine(Environment.CurrentDirectory, filenameDocx);
                var outputFileLocation = Path.Combine(Environment.CurrentDirectory, filenamePdf);
                System.IO.File.WriteAllBytes(inputFileLocation, inputData);
                var test = new ReportGenerator("libreoffice");
                test.Convert(inputFileLocation, outputFileLocation, null);
                document.PdfBase64= Convert.ToBase64String(System.IO.File.ReadAllBytes(outputFileLocation));
                document.WordBase64 = null;

                System.IO.File.Delete(inputFileLocation);
                System.IO.File.Delete(outputFileLocation);

                return document;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
