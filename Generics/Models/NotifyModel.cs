using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Models
{
    public class NotifyModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }

        public NotifyModel()
        {

        }
        public NotifyModel(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }
        public NotifyModel(string subject)
        {
            Subject = subject;
            Body = "";
        }

        public NotifyModel(Exception e)
        {
            Body = e.ToString();
            Subject = (e.TargetSite != null ? e.TargetSite.ToString() : "") + e.GetType().ToString();
        }
        public NotifyModel(Exception e, string details)
        {
            Subject = e.ToString();
            Body = details + "<br />" + (e.TargetSite != null ? e.TargetSite.ToString() : "") + e.GetType().ToString();
        }
    }

}
