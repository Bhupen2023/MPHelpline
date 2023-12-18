using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

using System;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
//using System.Net.WebException;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.UI;
public partial class ePoll_eUB_eMailSend : System.Web.UI.Page
{

    string cs = ConfigurationManager.ConnectionStrings["conELMT"].ConnectionString;

    UBSERVICES Modelobj = new UBSERVICES();
    int dist;
    int type;
    int UB_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        // sendSingleSMS();
        if (!IsPostBack)
        {


            if (Session["Action"] == null)
            {
                Response.Redirect("./PS_Login.aspx");
            }
            else
            {

                lblName.Text = Session["PO_Name"].ToString();
                PS_NO_Name.Text = Session["PS_ID"].ToString() + "--" + Session["PS_Name"].ToString();
                // Session["PS_Name"] = dt.Rows[0]["PS_Name"];
                //Session["PO_Name"] = dt.Rows[0]["PO_Name"];
                // Session["PO_eMailID"] = dt.Rows[0]["PO_eMailID"];


            }

        }

    }



    protected void btnSendEmailpage(object sender, EventArgs e)
    {
        pnlvoterSearch.Visible = true;
    }

    public bool IsValidEmailAddress(string email)
    {
        try
        {
            var emailChecked = new System.Net.Mail.MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void Send(object sender, EventArgs e)
    {

        try
        {

            email_send();
        }
        catch
        {
           
        }
       
    }

   
    protected void btBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("./eUB/PO_HOME.aspx");

    }
    public void email_send()
        {







        try
        {
   MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("bhupenlearn@gmail.com");

            // code for sent particuler member
            string emailID = txt_email.Text.ToString();
            mail.To.Add(emailID);

            mail.Subject = " प्ररूप - 15 भाग 1 - मतपत्र लेखा";


            string MESSAGE = "श्री मान " + txt_Name.Text.ToString() + " आपको मध्य प्रदेश  राज्य निर्वाचन के द्वारा पंचायत निर्वाचन नियम के अनुसार , प्ररूप -15 मतपत्र लेखा pdf फाइल रूप में  ईमेल के द्वारा भेजा जा रहा है   ";

            mail.Body = MESSAGE;

            System.Net.Mail.Attachment attachment;

            //C:\Users\hp\Downloads

            attachment = new System.Net.Mail.Attachment("C:/Users/hp/Downloads/_.pdf");
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("bhupenlearn@gmail.com", "wggt hllm umps wtwv");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            MessageBox("Email Send Successfully....");
            return;
        }

        catch( Exception ex)
        {
            MessageBox("Please try again......");
            return;
        }

   }
    public void MessageBox(string msg)
    {
        // lblsms.Text = msg;

        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Msg", "alert('" + msg + "')", true);
    }

    protected void btLogout_Click(object sender, EventArgs e)

    {
        Response.Redirect("./PS_Login.aspx");
    }
    
  
    protected void btnPrarup15A_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Prarup15A.aspx");
    }
    protected void btn15_PDF_Click(object sender, EventArgs e)
    {
        //  Response.Redirect("../eUB/15_PDF.aspx");

        string redirect = "<script>window.open('../eUB/15_PDF.aspx');</script>";
        Response.Write(redirect);
        // ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../eUB/15_PDF.aspx?Param=" + Param1.ToString() + "');", true);

    }

}

