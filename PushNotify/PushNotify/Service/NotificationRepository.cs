using Newtonsoft.Json;
using PushNotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace PushNotify.Service
{
    public class NotificationRepository
    {
        private static NotificationRepository notificationRepository;
        public static NotificationRepository GetInstanse()
        {
            if (notificationRepository == null)
            {
                notificationRepository = new NotificationRepository();

            }
            return notificationRepository;
        }

        public async void SendNotification()
        {
            var ctx = HttpContext.Current;
            using (var client = new HttpClient())
            {
                var list_token = (List<TokenRegister>)ctx.Cache["token"];
                var request_data = new Notification();
                request_data.registration_ids = TokenRepository.GetInstanse().GetToken();
                NotificationMessage notificationMessage = new NotificationMessage();
                notificationMessage.message = "Hello From Firebase";
                request_data.data = notificationMessage;

                 client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=" + "AIzaSyAx7W0P5F6l58muel_1Qk60TUONKUkLxrY");
                /* var response = client.PostAsync("https://fcm.googleapis.com/fcm/send",
                                new StringContent(JsonConvert.SerializeObject(request).ToString(),
                                System.Text.Encoding.UTF8, "application/json"))
                               .Result;*/

                using (StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(request_data)))
                {
                    jsonContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    using (HttpResponseMessage response = await client.PostAsync("https://fcm.googleapis.com/fcm/send", jsonContent))
                    {
                        var reponseString = await response.Content.ReadAsStringAsync();
                    }
                }


            }
        }
    }
}