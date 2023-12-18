using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
//using System.Net.Mail.SmtpException;



public partial class ePoll_eUB_15A : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        email_send();
    }

    public void email_send()
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("bhupenlearn@gmail.com");
        mail.To.Add("ios.bhupen@gmail.com");
        mail.Subject = "Test Mail - 1";
        mail.Body = "mail with attachment";

        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment("C:/Users/hp/Desktop/TESTPDF/SAMIDHA_letter.pdf");
        mail.Attachments.Add(attachment);

        SmtpServer.Port = 587;
        SmtpServer.Credentials = new System.Net.NetworkCredential("bhupenlearn@gmail.com", "wggt hllm umps wtwv");
        SmtpServer.EnableSsl = true;

        SmtpServer.Send(mail);

    }
}