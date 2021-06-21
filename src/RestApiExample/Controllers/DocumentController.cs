using DocXToPdfConverter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApiExample.Interfaces;
using RestApiExample.Model;
using System;
using System.IO;
using System.Net;
using Document = RestApiExample.Model.Document;

namespace RestApiExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : Controller
    {
        private readonly IConverterService converterService;
        public DocumentController(IConverterService converterService)
        {
            this.converterService = converterService;
        }

        [HttpPost(nameof(ConvertToPdf))]
        [ProducesResponseType(typeof(Document), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Document), (int)HttpStatusCode.BadRequest)]
        public Document ConvertToPdf(Document document)
        {
            try
            {
                return converterService.ConvertToPdf(document);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
