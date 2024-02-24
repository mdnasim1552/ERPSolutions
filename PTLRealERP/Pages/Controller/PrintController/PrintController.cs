
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using Microsoft.ReportingServices.Interfaces;
using RealEntity.Account;
using RealERPLIB.ControllersRepository;
using RealERPLIB.Extensions;
using RealERPLIB.LoginRepository;
using RealERPRDLC;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PTLRealERP.Pages.Controller.PrintController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PrintController : ControllerBase
    {
        private IBackgroundJobClient _backgroundJobClient;
        private readonly IUserRepository _userRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PrintController(IBackgroundJobClient backgroundJobClient, IUserRepository userRepository,ILoginRepository loginRepository, IWebHostEnvironment webHostEnvironment)
        {
            _backgroundJobClient = backgroundJobClient;
            _userRepository = userRepository;
            _loginRepository = loginRepository;
            _webHostEnvironment = webHostEnvironment;

        }
        [HttpGet("RptRDLCPDF")]
        public async Task<IActionResult> GenerateReport()
        {
            try
            {
                //var isAuthenticated = User.Identity.IsAuthenticated;
                var username = User.Identity.Name ?? "Guest";
                var comcodClaim = User.Claims.FirstOrDefault(c => c.Type == "comcod");
                var comcod = comcodClaim?.Value ?? "3101";
                Company company = await _loginRepository.GetCompany(comcod);
                var userList = await _userRepository.GetUserList();
                //string ComLogo= new Uri(Server.MapPath(@"~\Image\LOGO" + comcod + ".jpg")).AbsoluteUri;
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Comp_Logo", $"{comcod}.jpg");
                string ComLogo = new Uri(imagePath).AbsoluteUri;
                string printdate = System.DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss tt");

                LocalReport Rpt1 = new LocalReport();
                DataTable dt = new DataTable();
                Rpt1.LoadReportDefinition(RealERPRDLC.RPTPathClass.GetReportFilePath("Control_Panel.UserLoginfrm"));
                Rpt1 = Rpt1.SetRDLCReportDatasets(new Dictionary<string, object> { { "DataSet1", userList } });
                //Rpt1.DataSources.Add(new ReportDataSource("DataSet1", userList));
                // Rpt1.EnableExternalImages = true;
                Rpt1.EnableExternalImages = true;
                
                Rpt1.SetParameters(new ReportParameter("comnam", company!=null? company.comnam : ""));//"/Images/Comp_Logo/3101.jpg"
                Rpt1.SetParameters(new ReportParameter("comadd", company!= null ? company.comadd1 : ""));
                Rpt1.SetParameters(new ReportParameter("ComLogo", ComLogo));
                Rpt1.SetParameters(new ReportParameter("RptTitle", "User's Login Credentials"));
                Rpt1.SetParameters(new ReportParameter("printFooter", ASTUtility.Concat(company != null ? company.comnam:"", username, printdate)));

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

                _backgroundJobClient.Schedule(() => DeleteFile(filePath), TimeSpan.FromMinutes(1)); // Adjust the duration as needed
                return Ok(new { fileUrl = "/" + foldername + "/" + fileName });
                //return File(bytes, "application/pdf", "Report.pdf");
                //byte[] reportBytes = reportViewer.LocalReport.Render("PDF", null, out string mimeType, out string encoding, out string fileNameExtension, out string[] streams, out Warning[] warnings);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
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
