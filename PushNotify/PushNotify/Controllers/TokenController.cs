using PushNotify.Models;
using PushNotify.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PushNotify.Controllers
{
    public class TokenController : ApiController
    {
        // GET: api/TokenRegister
        public void Get()
        {
            NotificationRepository.GetInstanse().SendNotification();
         //   return new string[] { "value1", "value2" };
        }

        // GET: api/TokenRegister/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TokenRegister
        /*        [HttpPost]
                public HttpResponseMessage Post([FromBody]String id_token)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.Created)
                    {
                        Content = new StringContent("Hello" + id_token)
                    };
                    return response;

                */

        [HttpPost]
        public HttpResponseMessage Post(TokenRegister tokenRegisterModel)
        {
            TokenRepository.GetInstanse().AddToken(tokenRegisterModel.Id_Token);

            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent("Added Token Id : " + tokenRegisterModel.Id_Token)
            };
            return response;
        }

        // PUT: api/TokenRegister/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TokenRegister/5
        public void Delete(int id)
        {
        }
     
    }
}
