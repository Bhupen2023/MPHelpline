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

public partial class ePoll_Prarup15A : System.Web.UI.Page
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
           // Session["Action"] = "Admin";

            if (Session["Action"] == null)
            {
                Response.Redirect("../PS_Login.aspx");
            }
            else
            {

                lblName.Text = Session["PO_Name"].ToString();
                PS_NO_Name.Text = Session["PS_ID"].ToString() + "--" + Session["PS_Name"].ToString();
                lblGP_Name.Text= "--"+Session["GP_Name"].ToString();
                lblGP_NameSAR.Text= "--" + Session["GP_Name"].ToString() + "--" ;
                lblBlockName.Text= Session["Block_Name"].ToString() + "--" ;

               // Session["Dst_Name"] = dt.Rows[0]["Dst_Name"];
               // Session["Block_Name"] = dt.Rows[0]["Block_Name"];
               // Session["GP_Name"] = dt.Rows[0]["GP_Name"];

            }

        }

    }

    protected void btBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("./eUB/PO_HOME.aspx");

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
    

    protected void btLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("./eUB/PS_Login.aspx");
    }

}


