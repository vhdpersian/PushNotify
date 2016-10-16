using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushNotify.Models
{
    public class Notification
    {
        public List<String> registration_ids { get; set; }
        public NotificationMessage data { get; set; }
    }

    public class NotificationMessage
    {
        public String message { get; set; }
    }
}