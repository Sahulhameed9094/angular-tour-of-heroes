using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace test786api2.Controllers
{
    public class DefaultController : ApiController
    {


        [HttpPost]
        [Route("api/upload")]
        public IHttpActionResult Upload()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var httpRequest2= httpRequest.Form["file2"];
                // Check if files are present in the request
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        // Save the file to a folder on the server
                        var filePath = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + postedFile.FileName);
                        postedFile.SaveAs(filePath); // Save the file to the specified folder
                    }
                    return Ok("Files uploaded successfully.");
                }
                else
                {
                    return BadRequest("No files received.");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
