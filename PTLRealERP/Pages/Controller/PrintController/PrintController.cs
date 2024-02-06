
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using RealERPRDLC;

namespace PTLRealERP.Pages.Controller.PrintController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PrintController : ControllerBase
    {
        private IBackgroundJobClient _backgroundJobClient;
        public PrintController(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }
        [HttpGet("RptRDLCPDF")]
        public async Task<IActionResult> GenerateReport()
        {
            LocalReport Rpt1 = new LocalReport();
            Rpt1.LoadReportDefinition(RealERPRDLC.RPTPathClass.GetReportFilePath("Control_Panel.UserLoginfrm"));
            //Rpt1 = RPTPathClass.SetRDLCReportDatasets();
            // Rpt1.EnableExternalImages = true;
            string reportType = "PDF";
            string deviceInfo =
                  @"<DeviceInfo><EmbedFonts>Full</EmbedFonts>" +
                  "  <OutputFormat>" + reportType + "</OutputFormat>" +
                  "</DeviceInfo>";
            byte[] bytes = Rpt1.Render("PDF", deviceInfo);//RptRDLCPDF(Rpt1);//
            //return bytes;
            string foldername = "generated";
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", foldername);

            // Ensure the folder exists; create it if it doesn't
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Specify the file name for the generated PDF
            Random random = new Random();
            int randomNumber = random.Next(1000, 9999); // Change the range as needed
            string fileName = $"Report_{DateTime.Now.ToString("yyyyMMddHHmmss")}_{randomNumber}.pdf";

            // Combine the folder path and file name
            string filePath = Path.Combine(folderPath, fileName);

            // Save the PDF file to the specified path
            System.IO.File.WriteAllBytes(filePath, bytes);

            //await System.Threading.Tasks.Task.Run(() =>
            //{
            //     Task.Delay(TimeSpan.FromSeconds(10));
            //    //await System.Threading.Thread.Sleep(10000); // Delay for 10 seconds
            //    System.IO.File.Delete(filePath);
            //});
            _backgroundJobClient.Schedule(() => DeleteFile(filePath), TimeSpan.FromMinutes(1)); // Adjust the duration as needed
            return Ok(new { fileUrl = "/"+foldername+"/"+ fileName });
            //return File(bytes, "application/pdf", "Report.pdf");
            //byte[] reportBytes = reportViewer.LocalReport.Render("PDF", null, out string mimeType, out string encoding, out string fileNameExtension, out string[] streams, out Warning[] warnings);

        }
        public void DeleteFile(string filePath)
        {
            System.IO.File.Delete(filePath);
        }
        public byte[] RptRDLCPDF(LocalReport report)
        {
            LocalReport rt = report;
            string reportType = "PDF";
            string deviceInfo =
                   @"<DeviceInfo><EmbedFonts>Full</EmbedFonts>" +
                   "  <OutputFormat>" + reportType + "</OutputFormat>" +
                   "</DeviceInfo>";
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension = string.Empty;
            byte[] bytes = rt.Render(reportType, deviceInfo, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            return bytes;

        }
    }
}
