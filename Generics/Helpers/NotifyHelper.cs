using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics.Constants;
using Generics.Models;

namespace Generics.Helpers
{
    public static class NotifyHelper
    {
        public static void Notify(this NotifyModel model, Notifications notifications = Notifications.Slack)
        {
            if (notifications == Notifications.Email || notifications == Notifications.Both)
            {
                //new ErrorOccurModel()
                //{
                //    ErrorSubject = model.Subject,
                //    Exception = model.Body
                //}.SendErrorMail();
            }
            if (notifications == Notifications.Slack || notifications == Notifications.Both)
            {
                var message = model.Subject + " ----- " + model.Body;
                SlackHelper.NotifySlack(message);
            }
        }
        public static void Notify(this ErrorOccurModel model, Notifications notifications = Notifications.Slack)
        {
            if (notifications == Notifications.Email || notifications == Notifications.Both)
            {
                //model.SendErrorMail();
            }
            if (notifications == Notifications.Slack || notifications == Notifications.Both)
            {
                var message = model.ErrorSubject + " ----- " + model.Exception;
                SlackHelper.NotifySlack(message);
            }
        }
    }
}
