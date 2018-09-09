using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Constants.Apis
{
    public static class SendGrid
    {
        public const string ApiKey = "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";

        public static class From
        {
            public const string EmailAddress = "do-not-reply@themarucagroup.com";
            public const string Name = "The Maruca Group";
        }
        public static class To
        {
            public const string EmailAddress = "cesar@themarucagroup.com";
        }

        public static class EndPoints
        {
            public const string PostMail = "https://api.sendgrid.com/v3/mail/send";
        }

        public static class Templates
        {
            public const string AccountConfirmation = "79e06e51-5efc-4ea5-85f7-ffe3fb69af16";
            public const string CustomPaymentOrder = "fbb58456-bd13-4102-9a96-001dbf903053";
        }
    }
}
