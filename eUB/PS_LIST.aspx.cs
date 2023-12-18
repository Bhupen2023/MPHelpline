using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using System.Threading;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.Drawing.Imaging;

public partial class ePoll_eUB_PS_LIST : System.Web.UI.Page
{

    string cs = ConfigurationManager.ConnectionStrings["conELMT"].ConnectionString;
    string ULB_Block_ID = "";
    string ULB_Type_ID = "";
    string Election_ID = "";
    string DIST_id;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            try
            {
               
                    GetUserDetails();

                
            }
            catch (Exception ex)
            {

                
            }
        }
    }

    public void GetUserDetails()
    {

        try
        {

            // start Print Details

            //  DIST_id = " जिला -" + base64Decode(Session["DistName"].ToString());
            ULB_Block_ID = base64Decode(Session["UBId"].ToString());
        
            GetPolling( ULB_Block_ID);

        }
        catch (Exception ex)
        {

        }

    }




    public void GetPolling(string UB_ID)
    {



        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        try
        {
            UBSERVICES distobj = new UBSERVICES();
            ds = GetpollingStation(UB_ID);
            dt = ds.Tables[0];

            int rows = ds.Tables[0].Rows.Count;
            if (rows <= 0)
            {
                // Status = 0;
                lblError.Visible = true;
                lblError.Text = "कोई रिकॉर्ड नहीं है.";
                //lblcount.Visible = false;
            }
            else
            {
                lblError.Text = " कुल पोलिंग बूथ की संख्या : " + rows.ToString();

            }
            //lblError.Visible = true;
            grdPS.DataSource = dt;
            grdPS.DataBind();


        }
        catch (Exception)
        {

        }


    }
    // Get Polling Station 
    public DataSet GetpollingStation(string UB_ID)
    {


        DataSet ds = new DataSet();
        String Query;
       
            Query = "select    W.[Ward_NO] as Ward_NO ,m.[PS_NO]  as PS_NO,m.[PS_Name] as PS_Name ,m.isActive as Active FROM [sys_admin].[M_PS_M]  m Right join    [sys_admin].[M_UBWARD] w  ON  m.Ward_ID=w.Ward_ID where  m.UB_ID='" + UB_ID + "'  and w.UB_ID='" + UB_ID + "'   and m.isActive='1' order by m.PS_ID ASC ";
       
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



    private string base64Encode(string sData)
    {
        try
        {
            byte[] encData_byte = new byte[sData.Length];

            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);

            string encodedData = Convert.ToBase64String(encData_byte);

            return encodedData;

        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Encode" + ex.Message);
        }
    }
    //--Decoding
    public string base64Decode(string sData)
    {

        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();

        System.Text.Decoder utf8Decode = encoder.GetDecoder();

        byte[] todecode_byte = Convert.FromBase64String(sData);

        int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);

        char[] decoded_char = new char[charCount];

        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

        string result = new String(decoded_char);

        return result;

    }
}

