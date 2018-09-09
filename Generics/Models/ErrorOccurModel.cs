using System;

namespace Generics.Models
{
    public class ErrorOccurModel
    {
        public string ErrorSubject { get; set; }
        public string Exception { get; set; }

        public ErrorOccurModel()
        {

        }
        public ErrorOccurModel(Exception e)
        {
            Exception = e.ToString();
            ErrorSubject = (e.TargetSite != null ? e.TargetSite.ToString() : "") + e.GetType().ToString();
        }
        public ErrorOccurModel(Exception e,string details)
        {
            Exception = e.ToString();
            ErrorSubject = details + "<br />" + (e.TargetSite != null ? e.TargetSite.ToString() : "") + e.GetType().ToString();
        }
    }
}