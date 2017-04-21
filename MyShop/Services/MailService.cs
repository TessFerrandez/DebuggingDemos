using System;
using System.Text.RegularExpressions;

namespace MyShop.Services
{
    public class MailService
    {
        public void SendMail(string message, string email)
        {
            try
            {
                if (IsValidEmail(email) && IsValidMessage(message))
                {
                    //TODO: Send email
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
            }
        }

        private bool IsValidMessage(string message)
        {
            Regex slowRegex = new Regex("([a - z] +)*=");
            Match m = slowRegex.Match(message);
            return m.Success;
        }

        private bool IsValidEmail(string email)
        {
            if (!Regex.IsMatch(email, "^([a-zA-Z0-9_]+)@([a-zA-Z0-9]+).([a-zA-Z]{2,5})$"))
            {
                throw new System.Exception("The email entered is not a valid email address");
            }
            else
                return true;
        }

    }
}