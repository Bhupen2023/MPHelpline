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


public partial class ePoll_eUB_PO_HOME : System.Web.UI.Page
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


    protected void btLogout_Click(object sender, EventArgs e)

    {
        Response.Redirect("./PS_Login.aspx");
    }
    protected void btnVoterSearch_Click(object sender, EventArgs e)
    {
        pnlvoterSearch.Visible = true;
    }

    protected void btnALLVoter_Click(object sender, EventArgs e)
    {
        Response.Redirect("./PO_ALlVoter.aspx");
    }

    protected void btnReports_Click(object sender, EventArgs e)
    {
        Response.Redirect("./PO_Reports.aspx");
    }

    protected void btnPrarup15A_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Prarup15A.aspx");
    }

    protected void btnPDF_SendBy_EmailClick(object sender, EventArgs e)
    {
        Response.Redirect("../eUB/eMailSend.aspx");
    }
    protected void btn15_PDF_Click(object sender, EventArgs e)
    {
        //  Response.Redirect("../eUB/15_PDF.aspx");

        string redirect = "<script>window.open('../eUB/15_PDF.aspx');</script>";
        Response.Write(redirect);
       // ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../eUB/15_PDF.aspx?Param=" + Param1.ToString() + "');", true);

    }
    


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GETVoterLIST();
    }


    // code for search 
    public void GETVoterLIST()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        

        try
        {
            ds = GetEpicData();
            dt = ds.Tables[0];

            int rows = ds.Tables[0].Rows.Count;
            if (rows <= 0)
            {
                lblNORecord.Visible = true;
                lblNORecord.Text = "कोई रिकॉर्ड नहीं  है.";
                    }
            else
            {
                lblNORecord.Visible = false;
               
            }
            pnlgrdvw.Visible = true;

            grdPS.DataSource = dt;
            grdPS.DataBind();


        }
        catch (Exception)
        {

        }

    }


    public DataSet GetEpicData()
    {

        //    int DistrictNo =42;
        DataSet ds = new DataSet();
        String Query;
        

            Query = " SELECT   [V_EPICNO]  ,[V_SNO] ,[V_Name] ,[V_Fname]  ,[V_Gender]  ,[V_Age]  FROM [sys_admin].[eVoter_PAN] where [isActive]=1 and V_EPICNO='" + txt_searchEpic.Text + "'";
       
        try
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds, "PSLIST");
                con.Close();
            }
            return (ds);
        }
        catch (Exception ex)
        {

            return (ds);
        }

        finally
        {

        }
    }


    public void GETAllVoterLIST()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();


        try
        {
            ds = GetALLVoterData();
            dt = ds.Tables[0];

            int rows = ds.Tables[0].Rows.Count;
            if (rows <= 0)
            {
                lblNORecord.Visible = true;
                lblNORecord.Text = "कोई रिकॉर्ड नहीं  है.";
            }
            else
            {
                lblNORecord.Visible = false;

            }
            pnlgrdvw.Visible = true;

            grdPS.DataSource = dt;
            grdPS.DataBind();


        }
        catch (Exception)
        {

        }

    }

    public DataSet GetALLVoterData()
    {

        //    int DistrictNo =42;
        DataSet ds = new DataSet();
        String Query;
        
            Query = " SELECT   [V_EPICNO]  ,[V_SNO] ,[V_Name] ,[V_Fname]  ,[V_Gender]  ,[V_Age]  FROM [sys_admin].[eVoter_PAN] where [isActive]=1 ";

       
        try
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds, "PSLIST");
                con.Close();
            }
            return (ds);
        }
        catch (Exception ex)
        {

            return (ds);
        }

        finally
        {

        }
    }


    // select for TOken 
    protected void btn_SelectToken(object sender, EventArgs e)
    {

        //Get the button that raised the event
        Button btn = (Button)sender;

        //Get the row that contains this button
        GridViewRow row = (GridViewRow)btn.NamingContainer;

        // string ps_id = (String)grdPS.SelectedValue;
        if (row != null)
        {
            GridViewRow Grow = (GridViewRow)btn.NamingContainer;
            Label lblEPICNO = (Label)Grow.FindControl("lblEPICNO");


            string result = Update(lblEPICNO.Text);

            if (result == "true")
            {
                btn.Text = "succeed";
                btn.BackColor = Color.White;
                btn.Enabled = false;
            }
            else
            {
                // lblResult.Text = " Please Refresh Page and Try Again  .....";

            }

        }
    }
    private string Update(string lblEPICNO)
    {
        try
        {

            //SymbolImage ="";
            //SymbolImage = "/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBwgHBgkIBwgKCgkLDRYPDQwMDRsUFRAWIB0iIiAdHx8kKDQsJCYxJx8fLT0tMTU3Ojo6Iys/RD84QzQ5OjcBCgoKDQwNGg8PGjclHyU3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3N//AABEIAHkAwgMBIgACEQEDEQH/xAAYAAADAQEAAAAAAAAAAAAAAAAAAQMCB//EACsQAAMAAQMDAwMEAwEAAAAAAAABERICITFBUWFxgaGR8PFCscHRMlKSIv/EABUBAQEAAAAAAAAAAAAAAAAAAAAB/8QAFREBAQAAAAAAAAAAAAAAAAAAABH/2gAMAwEAAhEDEQA/AOkIzWib1NGlv+QNrcTcJvU198DW/wCQKLeeRNzcw20/ToC3Aondwbm5NuN/sFu9XuBtOjbnUm3GK0Clu43t1+TGrZitQG7Rv1+TD2FagN5ZOdDT45XmE3wugsk9gNZN7Pg305Xkk+BZdAKLV0Hv3Rj9IsunyBvKOD6Wr3Mfp6P3FlNgN5QaMdGxWMCn1/6EYvkAMLf74E9UJ5Qar6FFFvO3TwJuMnlH97DTvkCibf8AQm4Tyxf8dgTr7gUTvHD6DbnJKxv9gyvkCieXA22iTcYW8ICmV3Q3STcfYMk+AKLVeBupEm54B6k4kBTKvbkbv4ZJvbt5DJPgCmV2Q9yd2Fkp28gUWroPeE+gskBTLp+495/bJpucCy+oFMpz+Rq+CSru1DNrYCtf++oCW/cAJp0MoSyg7QiidDKenQllB2gUTvkLOeCWWI7WBS3yDc5WxLKeg7WBTKg3OVsTsYsqBVarwDq/kk3GGV4AqtV4DdErAepvqBXK/wCPPkL2UJ2CyoFc09laFm/D7k+mwsvqBXJeaG/UndhZsCuXcN5YTuws3IBV6pyHqia3osptQK/+u6+gid8/AATtDOE8oK0CtoZT0J5QVpYK2hlPQnlPQLRBTKhlCS1QMqIK5ULPQlYGVEFcqFhKwMr1EFcqDbRKwMr1IK59n9Qs4vuSsDLyWCufZuhe3sSsDMQVzXdhXyyQZeRBXPuwvV/BKhkQVynL+gJt8/BK3cMoWCt1eAJZP7YCCdoLVCeUC0CloZQnlAtAplX4DKE1qgZUCmVYZQmnAyoFMqFnp1JpwHqoFHqoWE7AyoFMvIWE7AyoFMuzvqFnF9yVg8gK5dnuK9vYlYPMCi1bcsL35JphmBRa+7C9/glR5AUz7sKTtDICmWvx9RE8n9sAJ2gtUMLVuFoG7R5QnlAboG7R2E1qgPVQKZUS1QwtUB6qBTKisMJwHqoFHqorOCdg3rvX4Apl5FYTpp6r1+ANvUKwnYaerbn4A3l+BUnRvVtz8AUy259hXqTvU1ltz8AbyF5J3qPLYCmQr1J0eQFMhGMgAnaOwwtQrQN5UdhjKCboG8vyOwmtUC0DeW/8jsJpwG6BR6hWGE4FA29W4LYwnAbA29QWGEwoFHqFYY4DICj1bCpOjyAplsKmAoFFqFTAUCmQvJjkMgN5PwBjIYGKCcM9vQOiCNUE4Z7B0QGmwTgui9RPj3A02CcM9PcHw/UDTYrBdGD/AFAaorBdGH9AaouBLh+gf0Bqi4EuV6B/qBq7CEuUHb1A1dhCXK9Q6e4GshC1cv1B9QNZCotQ+r9ADIBAB//Z";

            string cs = ConfigurationManager.ConnectionStrings["conELMT"].ConnectionString;
            //  sms.ZPPO_DETAILS
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd1 = new SqlCommand("update   [sys_admin].[eVoter_PAN]  set isActive=0   where   isActive=1 and   V_EPICNO='" + lblEPICNO + "'", con);

                // SeqId,  SymbolName,  SymbolImage,  Post,  Category

                // cmd1.Parameters.AddWithValue("@ps_id", ps_id);
                con.Open();
                int result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {

                    return "true";

                }
                else
                {
                    return "failed";
                }
                // con.Close();
            }
        }
        catch (Exception ex)
        {
            return "Something Went Wrong. Please Try After Sometime. Error Message: " + ex + "";
        }


    }

}

