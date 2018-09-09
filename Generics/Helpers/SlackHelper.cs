using System;
using System.Net;

namespace Generics.Helpers
{
    public class SlackHelper
    {
        public const string Notifier = "https://hooks.slack.com/services/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";
        public static void NotifySlack(string message)
        {
            PushToSlackUsingWebhook(Notifier, message);
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
