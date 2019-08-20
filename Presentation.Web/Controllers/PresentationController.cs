using System.IO;
using Microsoft.AspNetCore.Mvc;
using Presentation.Web.Models;
using Presentation.Web.Services;

namespace Presentation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentationController : ControllerBase
    {
        //This is just mine path to python, need to change for yours in order to work corectly
        private const string PythonPath = @"C:\Users\npc\AppData\Local\Programs\Python\Python37\python.exe"; 
        private readonly IPythonCaller _pythonCaller;

        public PresentationController(IPythonCaller pythonCaller)
        {
            _pythonCaller = pythonCaller;
        }

        [HttpGet("get-presentation")]
        public FileResult GetPresentation([FromBody] PresentationFile presentation)
        {
            _pythonCaller.callPython(PythonPath, presentation);

            byte[] fileBytes = System.IO.File.ReadAllBytes(@"Presentations\DemoPresentationWithPython.pptx");
            string fileName = "DemoPresentation.pptx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}