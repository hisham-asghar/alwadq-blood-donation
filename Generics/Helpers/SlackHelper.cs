using System;
using System.Net;

namespace Generics.Helpers
{
    public class SlackHelper
    {
        public static void NotifySlack(string message)
        {
            PushToSlackUsingWebhook(Constants.Slack.Webhooks.Notifier, message);
        }

        protected static void PushToSlackUsingWebhook(string webhook, string message)
        {
            using (var cli = new WebClient { Headers = { [HttpRequestHeader.ContentType] = "application/json" } })
            {
                var obj = new { text = message };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                cli.UploadString(new Uri(webhook), json);
            }
        }
    }
}
