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




public partial class ePoll_eUB_PO_Reports : System.Web.UI.Page
{

    string cs = ConfigurationManager.ConnectionStrings["conELMT"].ConnectionString;

    UBSERVICES Modelobj = new UBSERVICES();
    int dist;
    int type;
    int UB_ID;

    string RO_USER = "";
    string Election_id = "";
    string DIST_id = "";
    string DIST_NAME = "";
    string ROType = "";
    string ULB_ID = "";
    string Block_ID = "";
    string Block_NAME = "";
    string TOTAL_PS = "";
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
               // GetPercentage();
                lblName.Text = Session["PO_Name"].ToString();
                PS_NO_Name.Text = Session["PS_ID"].ToString() + "--" + Session["PS_Name"].ToString();
                // Session["PS_Name"] = dt.Rows[0]["PS_Name"];
                //Session["PO_Name"] = dt.Rows[0]["PO_Name"];
                // Session["PO_eMailID"] = dt.Rows[0]["PO_eMailID"];
                lblblockname.Text = Session["Block_Name"].ToString();
                btTotalVoter_Click();
                btPOLL_Click();
                GetPercentage();


            }

        }

    }

    protected void btBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("./PO_HOME.aspx");

    }

   

    protected void btTotalVoter_Click()
    {
        String PS_NO = Session["PS_ID"].ToString();
        SqlConnection con = new SqlConnection(cs);
        // SqlConnection con = newSqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT COUNT(V_Gender) as CountNO, V_Gender FROM [sys_admin].[eVoter_PAN]  where PS_ID=@PS_ID GROUP BY V_Gender", con);
        cmd.Parameters.AddWithValue("@PS_ID", PS_NO);
       // cmd.Parameters.AddWithValue("@PO_Password", txt_password.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        
        if (dt.Rows.Count > 2)
        {
            
                lblFemale.Text = dt.Rows[0]["CountNO"].ToString();
              
                lblMale.Text = dt.Rows[1]["CountNO"].ToString();
                lblOthers.Text = dt.Rows[2]["CountNO"].ToString();

                float female = float.Parse(lblFemale.Text.ToString());
                float male = float.Parse(lblMale.Text.ToString());
                float others = float.Parse(lblOthers.Text.ToString());

                float total = female + male + others;
                lblTotal.Text = total.ToString();

        }
        if (dt.Rows.Count < 3)
        {
            lblFemale.Text = dt.Rows[0]["CountNO"].ToString();

            lblMale.Text = dt.Rows[1]["CountNO"].ToString();
            lblOthers.Text = "0";

            float female = float.Parse(lblFemale.Text.ToString());
            float male = float.Parse(lblMale.Text.ToString());
            float others = 0;

            float total = female + male + others;
            lblTotal.Text = total.ToString();
        }
        
    }


    protected void btPOLL_Click()
    {
        String PS_NO = Session["PS_ID"].ToString();
        SqlConnection con = new SqlConnection(cs);
        // SqlConnection con = newSqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT COUNT(V_Gender) as CountNO, V_Gender FROM [sys_admin].[eVoter_PAN]  where PS_ID=@PS_ID and  isActive=0  GROUP BY V_Gender", con);
        cmd.Parameters.AddWithValue("@PS_ID", PS_NO);
        // cmd.Parameters.AddWithValue("@PO_Password", txt_password.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int row =  dt.Rows.Count;
        if (row==3)
        {

            lblFemale_Vote.Text = dt.Rows[0]["CountNO"].ToString();

            lblMale_Vote.Text = dt.Rows[1]["CountNO"].ToString();
            lblOthers_Vote.Text = dt.Rows[2]["CountNO"].ToString();

            float female = float.Parse(lblFemale_Vote.Text.ToString());
            float male = float.Parse(lblMale_Vote.Text.ToString());
            float others = float.Parse(lblOthers_Vote.Text.ToString());

            float total = female + male + others;
            lblTotal_Vote.Text = total.ToString();

        }
        if (row == 2)
        {

            lblFemale_Vote.Text = dt.Rows[0]["CountNO"].ToString();
            lblMale_Vote.Text = dt.Rows[1]["CountNO"].ToString();
            lblOthers_Vote.Text = "0";

            float female = float.Parse(lblFemale_Vote.Text.ToString());
            float male = float.Parse(lblMale_Vote.Text.ToString());
            float others = 0;

            float total = female + male + others;
            lblTotal_Vote.Text = total.ToString();
        }
        if (row == 1)
        {

            string V_gender = dt.Rows[0]["V_Gender"].ToString();

            if(V_gender=="F")
            {
                lblFemale_Vote.Text = dt.Rows[0]["CountNO"].ToString();

                lblMale_Vote.Text = "0";
                lblOthers_Vote.Text = "0";

                float female = float.Parse(lblFemale_Vote.Text.ToString());
                float male = 0;
                float others = 0;

                float total = female + male + others;
                lblTotal_Vote.Text = total.ToString();
            }
            if (V_gender == "M")
            {
                lblFemale_Vote.Text = "0";

                lblMale_Vote.Text = dt.Rows[0]["CountNO"].ToString(); ;
                lblOthers_Vote.Text = "0";

                float female = 0;
                float male = float.Parse(lblMale_Vote.Text.ToString());
                float others = 0;

                float total = female + male + others;
                lblTotal_Vote.Text = total.ToString();
            }

        }
    }


    // SAVE DATA 
    protected void SAVE_PER(object sender, EventArgs e)
    {
        try
        {
            String ddlTime = ddlTime_per.SelectedValue.ToString();
            
            if (ddlTime == "0")
            {
                MessageBox(" कृपया मतदान  के समय का चयन करे.");
                return;
            }
            
            else
            {
                // code 2023


                // code for 2021
                float m;
                float f;
                float t;
                float tot;
                m = Convert.ToInt32(lblMale.Text.ToString());
                f = Convert.ToInt32(lblFemale.Text.ToString());
                // t = Convert.ToInt32(lblTotal.Text.ToString());
                t = Convert.ToInt32(lblTotal.Text.ToString());
                tot = m + f;
                if (t >= tot)
                {

                    string StrPER_true = Exited_Per();

                    if (StrPER_true == "notexit")
                    {
                       // DIST_id = base64Decode(Session["DistrictId"].ToString());
                       // Block_ID = ddlTehsil.SelectedValue.ToString();
                        Election_id = "44";


                        Insert_PER_TIME();

                        GetPercentage();
                        ddlTime_per.Enabled = false;
                       
                        btnPer_SAVE.Enabled = false;
                     
                    }

                    if (StrPER_true == "exit")
                    {
                       
                        MessageBox("All Ready Exit..");
                        return;
                    }
                    if (StrPER_true == "error")
                    {
                        MessageBox("please try again...");
                        return;

                    }
                    // code for 2021
                }
                else
                {
                    MessageBox("");
                    return;
                }
            }
        }
        catch (Exception ex)
        {

        }

    }


    public string Exited_Per()
    {
        SqlConnection con = new SqlConnection(cs);

        DIST_id = Session["DST_ID"].ToString();
        DIST_NAME = Session["Dst_Name"].ToString();
        Block_ID = Session["Block_Id"].ToString();
        Block_NAME = Session["Block_Name"].ToString();

        String PS_ID= Session["PS_ID"].ToString();
        try
        {
            String Query;

            Query = "  SELECT distinct EleID  from  [sys_admin].[PAN_Percentage] where Electionid='" + Election_id + "' and PS_ID='" + PS_ID + "'  and Time_per='" + ddlTime_per.SelectedValue.ToString() + "'   and Status='i' ";

            SqlCommand cmd1 = new SqlCommand(Query, con);
            con.Open();
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                Session["EleID"] = "0";
                //  string strMOB = "true";
                string EleID = reader[0].ToString().ToUpper();
                EleID = EleID.ToString();

                Session["EleID"] = EleID;

                return "exit";
            }
            else
            {

                return "notexit";

            }
        }

        catch (Exception ex)
        {
            return "error";
        }

        finally
        {
            con.Close();

        }
    }


  
    public string Insert_PER_TIME()
    {

        DIST_id = Session["DST_ID"].ToString();
        DIST_NAME = Session["Dst_Name"].ToString();
        Block_ID = Session["Block_Id"].ToString();
        Block_NAME = Session["Block_Name"].ToString();
        String PS_ID = Session["PS_ID"].ToString();
        try
        {
            String RecordDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(RecordDate.ToString()));

            String Election_Year = datevalue.Year.ToString();
            String Election_Month = DateTime.Now.ToString("MMMM").ToUpper();
            String day = datevalue.Day.ToString();

            //string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;  //  sms.ZPPO_DETAILS
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd1 = new SqlCommand("Insert into [sys_admin].ePAN_Percentage (Electionid ,	Ele_Date,Ele_Month,	Ele_Year, Dst_ID,Dst_Name,   Block_ID,	Block_NAME, PS_ID,  Time_per,  Male_TOT,Male_Vot,Female_TOT,Female_Vot, Total,Total_Vot  , Created_By,Created_Date,Status ,Others_TOT,Others_Vot) values(  @Electionid ,	@Ele_Date,@Ele_Month,	@Ele_Year, @Dst_ID,@Dst_Name,@Block_ID,	@Block_NAME, @PS_ID,@Time_per,@Male_TOT,@Male_Vot,@Female_TOT,@Female_Vot, @Total,@Total_Vot,@Created_By,@Created_Date,@Status,@Others_TOT,@Others_Vot)", con);
                cmd1.Parameters.AddWithValue("@Electionid", Election_id);
              
                cmd1.Parameters.AddWithValue("@Ele_Date", day);
                cmd1.Parameters.AddWithValue("@Ele_Month", Election_Month);
                cmd1.Parameters.AddWithValue("@Ele_Year", Election_Year);
                cmd1.Parameters.AddWithValue("@DST_id", Convert.ToInt32(DIST_id));
                cmd1.Parameters.AddWithValue("@Dst_Name", DIST_NAME);
                cmd1.Parameters.AddWithValue("@Block_ID", Convert.ToInt32(Block_ID));
                cmd1.Parameters.AddWithValue("@Block_NAME", Block_NAME);
                cmd1.Parameters.AddWithValue("@PS_ID", PS_ID);

                //  Male_TOT,Male_Vot,Male_Per,Female_TOT,Female_Vot,Female_Per, Total,Total_Vot,Total_Per,

                cmd1.Parameters.AddWithValue("@Time_per", ddlTime_per.SelectedValue.ToString());             
                cmd1.Parameters.AddWithValue("@Male_TOT", lblMale.Text.ToString());
                cmd1.Parameters.AddWithValue("@Male_Vot", lblMale_Vote.Text.ToString());   
                cmd1.Parameters.AddWithValue("@Female_TOT", lblFemale.Text.ToString());
                cmd1.Parameters.AddWithValue("@Female_Vot", lblFemale_Vote.Text.ToString());
                cmd1.Parameters.AddWithValue("@Others_TOT", lblOthers.Text.ToString());
                cmd1.Parameters.AddWithValue("@Others_Vot", lblOthers_Vote.Text.ToString());
                cmd1.Parameters.AddWithValue("@Total", lblTotal.Text.ToString());
                cmd1.Parameters.AddWithValue("@Total_Vot", lblTotal_Vote.Text.ToString());
                cmd1.Parameters.AddWithValue("@Created_By", "PO");
                cmd1.Parameters.AddWithValue("@Created_Date", DateTime.Now.ToString());
                cmd1.Parameters.AddWithValue("@Status", "i");

                con.Open();
                int result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {

                    MessageBox("Data Saved Successfully...");
                    
                    return "True";

                }
                else
                {

                    MessageBox("Pls try again...");
                    return "Failed";
                }
                con.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox("Pls try again...");
            return " 0";
        }

        finally
        {

        }
    }


    public void GetPercentage()
    {
        DataSet Dist = new DataSet();
        DataTable dt = new DataTable();
        String Query;


        String PS_ID = Session["PS_ID"].ToString();

        Query = " Select EleID,Time_per,Male_Vot,Female_Vot,Others_Vot,Total_Vot ,Created_Date  from [sys_admin].ePAN_Percentage where    PS_ID = '" + PS_ID + "' and   Status = 'i'  order by EleID DESC";


        try
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(Dist, "List");
            }

            dt = Dist.Tables[0];

            int rows = Dist.Tables[0].Rows.Count;
            if (rows <= 0)
            {
                //lblHeader.Visible = true;
                // lblHeader.Text = "कोई रिकॉर्ड नहीं  है";

            }
            else
            {

                //  lblHeader.Visible = true;
                // lblHeader.Text = "कुल : " + " " + rows.ToString() + "  , " + " जिलो की जानकारी ";
            }


            grd_per.DataSource = dt;
            grd_per.DataBind();

            // Bind Gridview
        }
        catch (Exception ex)
        {


        }
    }


    public void MessageBox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Msg", "alert('" + msg + "')", true);
    }

    protected void btLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("./eUB/PS_Login.aspx");
    }


    // print 

   
}
