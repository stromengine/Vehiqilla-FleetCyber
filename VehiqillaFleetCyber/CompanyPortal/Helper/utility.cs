using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyPortal.Models;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace CompanyPortal.Helpers
{
    public class utility
    {
        //User Roles
        public const string supervisor = "Corporate User - Supervisor";
        public const string analyst = "Corporate User - Analyst";
        public const string soc = "Corporate User - Fleet SOC";
        /// <summary>
        /// General Method to send emails. credentials come from web.config
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="to"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool Email(string subject, string to, string body)
        {
            var message = new MailMessage();
            message.From = new MailAddress(ConfigurationManager.AppSettings.Get("email_from"));
            // message.To.Add(new MailAddress("info@vehiqilla.com")); //replace with valid value
            message.To.Add(new MailAddress(to)); //replace with valid value
            message.Subject = subject;
            message.Body = body;//string.Format(body);
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    // UserName = "info@vehiqilla.com",  // replace with valid value
                    UserName = ConfigurationManager.AppSettings.Get("email_username"),  // replace with valid value
                                                                                         //  Password = "qe1v1#N6"  // replace with valid value
                    Password = ConfigurationManager.AppSettings.Get("email_password")  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = ConfigurationManager.AppSettings.Get("email_host");//address webmail
                smtp.Port = int.Parse(ConfigurationManager.AppSettings.Get("email_port"));
                smtp.EnableSsl = bool.Parse(ConfigurationManager.AppSettings.Get("email_ssl"));
                smtp.Send(message);
            }
            return true;
        }

    }
}