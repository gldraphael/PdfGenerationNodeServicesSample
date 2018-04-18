using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;

namespace PdfGenerationNodeServicesSample.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> Index(
            [FromServices]INodeServices nodeServices)
        {
            var options = new // pass any html-pdf options here
            {
                width = "50mm",
                height = "90mm"
            };

            var stream = await nodeServices.InvokeAsync<Stream>(
                "./Node/createPdf.js",
                HTML,
                options
            );
            return File(stream, "application/pdf");
        }

        private const string HTML = "<html>\r\n  <head>\r\n    <meta charset=\"utf8\">\r\n    <title>SuitArt Business Card</title>\r\n    <link href=\"https://fonts.googleapis.com/css?family=Carrois+Gothic+SC\" rel=\"stylesheet\" />\r\n    <style>\r\n      html, body {\r\n        margin: 0;\r\n        padding: 0;\r\n        font-family: 'Carrois Gothic SC';\r\n        font-weight: 500;\r\n        font-size: 7px;\r\n        background: rgb(241,241,241);\r\n        -webkit-print-color-adjust: exact;\r\n        box-sizing: border-box;\r\n      }\r\n      .page {\r\n        position: relative;\r\n        height: 90mm;\r\n        width: 50mm;\r\n        display: block;\r\n        background: black;\r\n        page-break-after: auto;\r\n        margin: 50px;\r\n        overflow: hidden;\r\n      }\r\n      @media print {\r\n        body {\r\n          background: black;\r\n        }\r\n        .page {\r\n          margin: 0;\r\n          height: 100%;\r\n          width: 100%;\r\n        }\r\n      }\r\n      .page.first {\r\n        border-left: 5px solid green;\r\n      }\r\n      .bottom {\r\n        position: absolute;\r\n        left: 5mm;\r\n        right: 5mm;\r\n        bottom: 5mm;\r\n      }\r\n      .group {\r\n        margin-top: 3mm;\r\n      }\r\n      .line {\r\n        color: white;\r\n        position: relative;\r\n      }\r\n      .center {\r\n        text-align: center;\r\n      }\r\n      .logo {\r\n        position: relative;\r\n        width: 80%;\r\n        left: 10%;\r\n        top: 15%;\r\n      }\r\n    </style>\r\n  </head>\r\n  <body>\r\n    <div class=\"page\">\r\n      <div class=\"bottom\">\r\n        <div class=\"line\">Marc Bachmann</div>\r\n        <div class=\"line\">cto</div>\r\n\r\n        <div class=\"group\">\r\n          <div class=\"line\">p: +41 00 000 00 00</div>\r\n          <div class=\"line\">github: marcbachmann</div>\r\n        </div>\r\n        <div class=\"group\">\r\n          <div class=\"line\">suitart ag</div>\r\n          <div class=\"line\">r\u00E4ffelstrasse 25</div>\r\n          <div class=\"line\">8045 z\u00FCrich</div>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <div class=\"page\">\r\n      <img class=\"logo\" src=\"{{image}}\">\r\n      <div class=\"bottom\">\r\n          <div class=\"line center\">8045 z\u00FCrich</div>\r\n      </div>\r\n    </div>\r\n  </body>\r\n</html>\r\n";
    }
}
