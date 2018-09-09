using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CustomModels;
using CustomModels.SendGridModels;
using SendGrid;
using SendGrid.Helpers.Mail;
using Personalization = CustomModels.SendGridModels.Personalization;

namespace Generics.Helpers
{
    public static class EmailHelper
    {
        public static SendEmailModel Email(string subject, string body, string to = "")
        {
            return new SendEmailModel()
            {
                Subject = subject,
                Body = body,
                To = to
            };
        }

        public static object SendMail(this SendEmailModel model)
        {
            try
            {
                return SendGridMail(model);
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public static object SendMailTemplated(this SendEmailModel model)
        {
            try
            {
                return SendGridMailTemplated(model);
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public static SendEmailModel GetEmailModel(this ErrorOccurModel model)
        {
            return new SendEmailModel()
            {
                To = "tagheir@gmail.com",
                Body = model.Exception,
                Subject = model.ErrorSubject
            };
        }
        public static object SendErrorMail(this ErrorOccurModel model)
        {

            var fromAddress = new MailAddress("tagheir@gmail.com", "Hisham Mughal");
            const string fromPassword = "dhhphqekjvginwle";
            var subject = model.ErrorSubject;
            var body = model.Exception;

            var smtp = new SmtpClient
            {
                Host = "relay-hosting.secureserver.net",
                Port = 25,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            //var toAddress = new MailAddress("tagheir@gmail.com", "Hisham Mughal");
            //SendMailMessageToEmailAddress(fromAddress, subject, body, smtp, toAddress);
            var message = $"Email Notifier - {subject} - {body}";
            SlackHelper.NotifySlack(message);
            var toAddress = new MailAddress("developer@themarucagroup.com", "Developer - The Maruca Group");
            return SendMailMessageToEmailAddress(fromAddress, subject, body, smtp, toAddress);
        }

        private static object SendMailMessageToEmailAddress(MailAddress fromAddress, string subject, string body, SmtpClient smtp, MailAddress toAddress)
        {
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                try
                {

                    smtp.Send(message);
                    return true;
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
        }

        private static bool SendGridMail(SendEmailModel model)
        {
            var client = new SendGridClient(Constants.Apis.SendGrid.ApiKey);
            var from = new EmailAddress(Constants.Apis.SendGrid.From.EmailAddress, Constants.Apis.SendGrid.From.Name);
            var to = new EmailAddress(String.IsNullOrWhiteSpace(model.To) ? Constants.Apis.SendGrid.To.EmailAddress : model.To);
            var msg = MailHelper.CreateSingleEmail(@from, to, model.Subject, "", model.Body);
            var response = client.SendEmailAsync(msg);
            return response != null;
        }
        private static async Task<bool> SendGridMailTemplated(SendEmailModel model)
        {
            if (model.TemplateName == EmailTemplate.AccountConfirmation)
            {
                var emailModel = GetAccountConfirmationModel(model);
                return await SendGridApiMail(emailModel);
            }
            else if (model.TemplateName == EmailTemplate.CustomPaymentOrder)
            {
                var emailModel = GetCustomOrderModel(model);
                return await SendGridApiMail(emailModel);
            }
            else
            {
                var client = new SendGridClient(Constants.Apis.SendGrid.ApiKey);
                var from = new EmailAddress(Constants.Apis.SendGrid.From.EmailAddress, Constants.Apis.SendGrid.From.Name);
                var to = new EmailAddress(string.IsNullOrWhiteSpace(model.To) ? Constants.Apis.SendGrid.To.EmailAddress : model.To);
                var msg = MailHelper.CreateSingleEmail(from, to, model.Subject, "", model.Body);

                var response = client.SendEmailAsync(msg);
                return response != null;
            }
        }

        private static BaseModel GetAccountConfirmationModel(SendEmailModel model)
        {
            var accountModel = (AccountEmailModel) model;
            var emailModel = new CustomModels.SendGridModels.BaseModel()
            {
                @from = new PersonEmail()
                {
                    email = Constants.Apis.SendGrid.From.EmailAddress,
                    name = Constants.Apis.SendGrid.From.Name
                },
                template_id = Constants.Apis.SendGrid.Templates.AccountConfirmation,
                personalizations = new List<Personalization>()
                {
                    new Personalization()
                    {
                        to = new List<PersonEmail>()
                        {
                            new PersonEmail()
                            {
                                email = string.IsNullOrWhiteSpace(model.To) ? Constants.Apis.SendGrid.To.EmailAddress : model.To
                            }
                        },
                        subject = model.Subject,
                        substitutions = new AccountConfirmationSubstitution()
                        {
                            tmg_link = accountModel.Link,
                            tmg_subject = model.Subject
                        }
                    }
                }
            };
            return emailModel;
        }

        private static async Task<bool> SendGridApiMail(BaseModel emailModel)
        {
            var reuqestJson = Newtonsoft.Json.JsonConvert.SerializeObject(emailModel);
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Constants.Apis.SendGrid.ApiKey);
                    var response = await client.PostAsync(
                        Constants.Apis.SendGrid.EndPoints.PostMail,
                        new StringContent(reuqestJson, Encoding.UTF8, "application/json"));
                    return response != null;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        private static BaseModel GetCustomOrderModel(SendEmailModel model)
        {
            var accountModel = (CustomPaymentOrderModel) model;
            return new BaseModel()
            {
                @from = new PersonEmail()
                {
                    email = Constants.Apis.SendGrid.From.EmailAddress,
                    name = Constants.Apis.SendGrid.From.Name
                },
                template_id = Constants.Apis.SendGrid.Templates.CustomPaymentOrder,
                personalizations = new List<Personalization>()
                {
                    new Personalization()
                    {
                        to = new List<PersonEmail>()
                        {
                            new PersonEmail()
                            {
                                email = string.IsNullOrWhiteSpace(model.To)
                                    ? Constants.Apis.SendGrid.To.EmailAddress
                                    : model.To
                            }
                        },
                        subject = model.Subject,
                        substitutions = new CustomPaymentOrderSubstitution()
                        {
                            tmg_link = accountModel.Link,
                            tmg_subject = model.Subject,
                            tmg_description = model.Body,
                            tmg_name = model.ToName,
                        }
                    }
                }
            };
        }
    }
}
