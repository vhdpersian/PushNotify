using PushNotify.Models;
using PushNotify.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace PushNotify.Controllers
{
    public class UploadController : ApiController
    {
        // GET: api/Upload
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Upload/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Upload
        [HttpPost]
        public  void Post(UploadImage uploadImage)
        {
            var uploadFolderPath = HostingEnvironment.MapPath("~/App_Data/1.jpg");
            byte[] decodedByteArray = Convert.FromBase64String(uploadImage.image);
            using (var imageFile = new FileStream(uploadFolderPath, FileMode.Create))
            {
                imageFile.Write(decodedByteArray, 0, decodedByteArray.Length);
                imageFile.Flush();
            }


        }

        // PUT: api/Upload/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Upload/5
        public void Delete(int id)
        {
        }
    }

}
