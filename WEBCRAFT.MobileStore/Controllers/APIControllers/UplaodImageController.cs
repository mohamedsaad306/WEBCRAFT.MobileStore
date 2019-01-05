using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WEBCRAFT.MobileStore.Controllers.APIControllers
{
    [RoutePrefix("api/UplaodImage")]
    public class UplaodImageController : BaseController
    {



        [Route("PostUserImage")]
        [HttpPost]
        public string PostUserImage()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            var httpRequest = HttpContext.Current.Request;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            if (httpRequest.Files.Count > 1)
            {
                var message = string.Format("You can not Upload more than one image at the same time.");
                return message;
            }
            else
            {
                var postedFile = httpRequest.Files[0];
                var extension = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.')).ToLower();
                var generatedName = GenerateImageName(extension);
                var filePath = "~/Product_Image/" + generatedName;
                var fileFullPath = HttpContext.Current.Server.MapPath("~/Product_Image/" + postedFile.FileName);

                postedFile.SaveAs(fileFullPath);
                var message1 = string.Format("Image Uploaded Successfully.");
                return generatedName;
            }


        }

        private string GenerateImageName(string extension)
        {
            return string.Format(@"{0}{1}", DateTime.Now.Ticks, extension);

        }
    }
}
