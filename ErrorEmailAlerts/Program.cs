using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorEmailAlerts
{
    class Program
    {
        static void emailAlert(Exception ex)
        {
            StringBuilder words = new StringBuilder();

            String toEmail = "";
            String fromEmail = "";
            String user = "";
            String pass = "";
                                   
            words.Append("Message: ");
            words.Append(ex.Message);
            words.Append("\n");
            words.Append("Source: ");
            words.Append(ex.Source);
            words.Append("\n");
            words.Append("Stack Trace: ");
            words.Append(ex.StackTrace);
            words.Append("\n");
            words.Append("Target: ");
            words.Append(ex.TargetSite);
            words.Append("\n");

            Console.WriteLine(words.ToString());

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(toEmail);
            message.Subject = "Error Alert";
            message.From = new System.Net.Mail.MailAddress(fromEmail);
            message.Body = words.ToString();
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential(user, pass);
            smtp.Send(message);

            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            int[] array = new int[10];
            int i = 0;

            while (true)
            {
                try { 
                    i++;
                    Console.WriteLine(i);
                    array[i] = i;
                }
                catch (IndexOutOfRangeException ex)
                {
                    emailAlert(ex);
                    break;
                }
            }
            
        }
    }
}
