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

using emasclient;
public partial class ePoll_eUB_PS_Login : System.Web.UI.Page

{
    public static bool CheckForInternetConnection()
    {
        try
        {
            using (var client = new WebClient())
            {
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
        }
        catch
        {
            return false;
        }
    }

    String SMSServerRes;
    protected void Page_Load(object sender, EventArgs e)
    {
        // sendSingleSMS();
        if (!IsPostBack)
        {

            //if (Session["Action"] == null)
            //{
            //    Response.Redirect("./MainHome.aspx");
            //}
            //else
            //{
            //    string strAction = Session["Action"].ToString();

            //    if (strAction == "Action_Reg")
            //    {
            //        pnlLogin.Visible = false;
            //        //pnlRegUser.Visible = true;
            //        pnlFCReg.Visible = false;
            //        pnlUserType.Visible = false;

            //    }
            //    else if (strAction == "Action_Log")
            //    {
            //        pnlLogin.Visible = true;
            //        //pnlRegUser.Visible = false;
            //        pnlFCReg.Visible = false;
            //        pnlUserType.Visible = false;
            //    }
            //}

            //try
            //{
            //    //GetDistrict();

            //}
            //catch
            //{

            //}
            //  GetUBType();
        }

    }

    // emasclient;
    public String sendUnicodeSMSUser(String message, String mobileNo, String Templetid)
    {
        try
        {
            emasclient.SMSHttpPostClient obj = new emasclient.SMSHttpPostClient();
            obj.sendUnicodeSMS(message, mobileNo, Templetid);
            // obj.sendSingleSMS(message,mobileNo );
            return "true";
        }
        catch (Exception ex)
        {
            return "False";
        }
    }
    /// <summary>

    /// Method to get Encrypted the password

    /// </summary>

    /// <param name="password"> password as String"



    protected String encryptedPasswod(String password)

    {



        byte[] encPwd = Encoding.UTF8.GetBytes(password);

        //static byte[] pwd = new byte[encPwd.Length];

        HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");

        byte[] pp = sha1.ComputeHash(encPwd);

        // static string result = System.Text.Encoding.UTF8.GetString(pp);

        StringBuilder sb = new StringBuilder();

        foreach (byte b in pp)

        {



            sb.Append(b.ToString("x2"));

        }

        return sb.ToString();



    }



    /// <summary>

    /// Method to Generate hash code 

    /// </summary>

    /// <param name="secure_key">your last generated Secure_key



    protected String hashGenerator(String Username, String sender_id, String message, String secure_key)

    {



        StringBuilder sb = new StringBuilder();

        sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);

        byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());

        //static byte[] pwd = new byte[encPwd.Length];

        HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");

        byte[] sec_key = sha1.ComputeHash(genkey);



        StringBuilder sb1 = new StringBuilder();

        for (int i = 0; i < sec_key.Length; i++)

        {

            sb1.Append(sec_key[i].ToString("x2"));

        }

        return sb1.ToString();

    }
    

    /*END CODE */

   
    // login 
  
    string cs = ConfigurationManager.ConnectionStrings["conELMT"].ConnectionString;

    UBSERVICES Modelobj = new UBSERVICES();
    int dist;
    int type;
    int UB_ID;
    
    protected void btLogin_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(cs);
       // SqlConnection con = newSqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from [sys_admin].[eVoter_User] where PO_MobileNo =@PO_MobileNo and PO_Password=@PO_Password", con);
        cmd.Parameters.AddWithValue("@PO_MobileNo", txt_Username.Text);
        cmd.Parameters.AddWithValue("@PO_Password", txt_password.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Session["PS_ID"] =   dt.Rows[0]["PS_ID"];
            Session["PS_Name"] = dt.Rows[0]["PS_Name"];
            Session["PO_Name"] = dt.Rows[0]["PO_Name"];
            Session["PO_eMailID"] = dt.Rows[0]["PO_eMailID"];

            Session["DST_ID"] = dt.Rows[0]["DST_ID"];
            Session["Dst_Name"] = dt.Rows[0]["Dst_Name"];
            Session["Block_Id"] = dt.Rows[0]["Block_Id"];
            Session["Block_Name"] = dt.Rows[0]["Block_Name"];
            Session["GP_Name"] = dt.Rows[0]["GP_Name"];

            String GP= dt.Rows[0]["GP_Name"].ToString();


            Session["Action"] = "Admin";


            Response.Redirect("./PO_HOME.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
        }
    }

    protected void btLogin_Click22(object sender, EventArgs e)
    {
        Response.Redirect("./PO_HOME.aspx");

    }












    //public void GetDistrict()
    //{

    //    try
    //    {
    //        DataSet Dist = new DataSet();

    //      //  UBSERVICES distobj = new UBSERVICES();
    //        Dist = GetUBDistrict();
    //        ddlDistrict.DataSource = Dist;
    //        ddlDistrict.DataTextField = "dst_name";
    //        ddlDistrict.DataValueField = "dst_id";
    //        ddlDistrict.DataBind();
    //        ListItem DistrictsDefault = new ListItem("जिला", "0");
    //        ddlDistrict.Items.Insert(0, DistrictsDefault);

    //        //GetUBType();

    //    }
    //    catch (Exception)
    //    {
    //        // Response.Redirect("./Home");
    //    }


    //}



    //public DataSet GetUBDistrict()
    //{
    //    DataSet Dist = new DataSet();
    //    String Query;
    //    // Query = "select  distinct dst_id, dst_name from sys_admin.M_District ";

    //    Query = "select distinct dst_id, dst_name from sys_admin.M_District where dst_id in (select distinct  Dst_CD from[elect_plan].[Nagriye_Notification]"
    //     + "where Election_Id in (select Election_Id from[sys_admin].[Election_Master] where isActive = '1'))";

    //    try
    //    {

    //        using (SqlConnection con = new SqlConnection(cs))
    //        {
    //            SqlCommand cmd = new SqlCommand(Query, con);
    //            con.Open();
    //            SqlDataAdapter sda = new SqlDataAdapter(cmd);
    //            sda.Fill(Dist, "Dist");
    //        }
    //        return (Dist);
    //    }
    //    catch (Exception ex)
    //    {

    //        return (Dist);
    //    }
    //}


    // select  distinct TYPE_ID, TYPE_NAME from sys_admin.M_UBType;



    //  nikay name 

    /* 
    public DataSet GetUBTypeName(int dst_id, int TYPE_ID)
    {

        //    int DistrictNo =42;
        DataSet ds = new DataSet();
        String Query;


        Query = "select  distinct  UB_ID, sys_admin.M_UBType.Type_Name + '-' + sys_admin.M_UBNAME.UB_Name as UB_Name from sys_admin.M_UBNAME INNER JOIN sys_admin.M_UBType ON sys_admin.M_UBNAME.Type_ID = sys_admin.M_UBType.Type_ID and sys_admin.M_UBNAME.Dst_ID= " + dst_id + " and sys_admin.M_UBNAME.Type_ID=" + TYPE_ID + "";

        //  Query = "select  distinct UB_ID, UB_Name from sys_admin.M_UBNAME where dst_id=" + dst_id + " and TYPE_ID=" + TYPE_ID + "";
        try
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds, "UBName");
            }
            return (ds);
        }
        catch (Exception ex)
        {

            return (ds);
        }
    }

      */
    //   protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    //   {

    //       ddlType.ClearSelection();
    //       ddlUBName.ClearSelection();
    //       ddlType.ClearSelection();
    //       ddlPost.ClearSelection();

    //       GetUBType();

    //   }

    //   public void GetUBType()
    //   {

    //       int i = Convert.ToInt32(ddlDistrict.SelectedValue.ToString());
    //      // ddlType.Items.Clear();
    //       DataSet Tehsils = new DataSet();
    //       try
    //       {
    //          // ddlType.Items.Clear();
    //         //UBSERVICES distobj = new UBSERVICES();
    //           Tehsils = GetUBTypeLIST();
    //           //  Tehsils = distobj.SearchTehsilByDistrict();
    //           ddlType.DataSource = Tehsils;
    //           ddlType.DataTextField = "TYPE_NAME";
    //           ddlType.DataValueField = "TYPE_ID";
    //           ddlType.DataBind();
    //           ListItem DistrictsDefault = new ListItem("निकाय का प्रकार", "0");
    //           ddlType.Items.Insert(0, DistrictsDefault);

    //          // TypeSetWord();

    //       }
    //       catch (Exception)
    //       {

    //       }

    //   }
    //   public DataSet GetUBTypeLIST()
    //   {
    //       DataSet ds = new DataSet();
    //       String Query;
    //       // Query = "select  distinct TYPE_ID, TYPE_NAME from sys_admin.M_UBType ";

    //       dist = Convert.ToInt32(ddlDistrict.SelectedValue.ToString());

    //       Query = "select  distinct TYPE_ID, TYPE_NAME from sys_admin.M_UBType "
    //      + " where TYPE_ID in (select distinct Nagriye_typeID from[elect_plan].[Nagriye_Notification]"
    //     + " where Dst_CD = '" + dist + "'  and  Election_Id in  (select Election_Id from[sys_admin].[Election_Master] where isActive = '1'))";

    //       try
    //       {

    //           using (SqlConnection con = new SqlConnection(cs))
    //           {
    //               SqlCommand cmd = new SqlCommand(Query, con);
    //               con.Open();
    //               SqlDataAdapter sda = new SqlDataAdapter(cmd);
    //               sda.Fill(ds, "UBType");
    //           }
    //           return (ds);
    //       }
    //       catch (Exception ex)
    //       {

    //           return (ds);
    //       }
    //   }

    //   protected void ddlblock_SelectedIndexChanged(object sender, EventArgs e)
    //   {
    //       ddlUBName.Items.Clear();       
    //       ddlPost.ClearSelection();

    //       UBTypeName();



    //   }

    //   public void UBTypeName()
    //   {

    //       DataSet ds = new DataSet();
    //       DataTable dt = new DataTable();
    //       try
    //       {

    //           dist = Convert.ToInt32(ddlDistrict.SelectedValue.ToString());
    //           type = Convert.ToInt32(ddlType.SelectedValue.ToString());



    //           ds = GetUBTypeName(dist, type);

    //           dt = ds.Tables[0];
    //           // lblCount.Text =dt; 
    //           int rows = ds.Tables[0].Rows.Count;
    //           if (rows <= 0)
    //           {
    //               //lbldistict.Text = "कोई रिकॉर्ड नहीं  है.";
    //               string strdist = ddlDistrict.SelectedItem.ToString();
    //               string strtype = ddlType.SelectedItem.ToString();
    //               // pnlward.Visible = false;

    //               lblError.Visible = true;
    //               lblError.Text = " निकाय में कोई  चुनाव  नोटिफाई नहीं हुआ है  ";
    //           }
    //           else
    //           {
    //               type = Convert.ToInt32(ddlType.SelectedValue.ToString());
    //               if (type == 2 || type == 3)
    //               {
    //                   //pnlward.Visible = false;
    //               }
    //               lblError.Visible = false;
    //               // pnlward.Visible = true;
    //               ddlUBName.DataSource = ds;
    //               ddlUBName.DataTextField = "UB_Name";
    //               ddlUBName.DataValueField = "UB_ID";
    //               ddlUBName.DataBind();
    //               ListItem DistrictsDefault = new ListItem("निकाय का नाम", "0");
    //               ddlUBName.Items.Insert(0, DistrictsDefault);

    //               //btnSubmit.Visible = true;
    //           }
    //       }

    //       catch (Exception)
    //       {

    //       }

    //       if (ddlUBName.SelectedIndex < 0)
    //       {
    //           // btnSubmit.Visible = false;
    //       }
    //       else
    //       {
    //           // btnSubmit.Visible = true;
    //       }

    //   }


    //   public DataSet GetUBTypeName(int dst_id, int TYPE_ID)
    //   {

    //       //    int DistrictNo =42;
    //       DataSet ds = new DataSet();
    //       String Query;


    //    //   Query = "select  distinct  UB_ID, sys_admin.M_UBType.Type_Name + '-' + sys_admin.M_UBNAME.UB_Name as UB_Name from sys_admin.M_UBNAME INNER JOIN sys_admin.M_UBType ON sys_admin.M_UBNAME.Type_ID = sys_admin.M_UBType.Type_ID and sys_admin.M_UBNAME.Dst_ID= " + dst_id + " and sys_admin.M_UBNAME.Type_ID=" + TYPE_ID + "";

    //     /*  Query = "select  distinct  UB_ID, sys_admin.M_UBType.Type_Name + '-' + sys_admin.M_UBNAME.UB_Name as UB_Name from sys_admin.M_UBNAME INNER JOIN sys_admin.M_UBType"
    //          + " "+"ON sys_admin.M_UBNAME.Type_ID = sys_admin.M_UBType.Type_ID"
    //           + " "+"where UB_ID in  (select UB_CD from[elect_plan].[Nagriye_Notification] where Dst_CD = '" + dst_id + "'"
    //         + "and Election_Id in (select Election_Id from[sys_admin].[Election_Master] where isActive = '1'))";
    //       */

    //       Query = "select  distinct  UB_ID, sys_admin.M_UBType.Type_Name + '-' + sys_admin.M_UBNAME.UB_Name as UB_Name from sys_admin.M_UBNAME INNER JOIN sys_admin.M_UBType ON sys_admin.M_UBNAME.Type_ID = sys_admin.M_UBType.Type_ID where UB_ID in  (select distinct UB_CD from[elect_plan].[Nagriye_Notification]"
    //       + " " + "where Dst_CD = '" + dst_id + "'  and Election_Id in (select Election_Id from[sys_admin].[Election_Master] where isActive = '1' "
    //+ " " + "and UB_CD in ( select  distinct  UB_ID  from sys_admin.M_UBNAME  where Dst_ID='" + dst_id + "' and Type_ID='" + TYPE_ID + "'))) ";



    //       try
    //       {

    //           using (SqlConnection con = new SqlConnection(cs))
    //           {
    //               SqlCommand cmd = new SqlCommand(Query, con);
    //               con.Open();
    //               SqlDataAdapter sda = new SqlDataAdapter(cmd);
    //               sda.Fill(ds, "UBName");
    //           }
    //           return (ds);
    //       }
    //       catch (Exception ex)
    //       {

    //           return (ds);
    //       }
    //   }


    //   public void TypeSetWord()
    //   {
    //       type = Convert.ToInt32(ddlType.SelectedValue.ToString());

    //       if (type == 1)
    //       {
    //           //   pnlward.Visible = true;
    //       }
    //       else if (type == 2 || type == 3)
    //       {
    //           // pnlward.Visible = false;

    //       }
    //   }

    //   protected void ddlUBName_SelectedIndexChanged(object sender, EventArgs e)
    //   {





    //       TypeSetWord();

    //       if (type == 1)
    //       {

    //           // WardList();
    //       }
    //       else
    //       {
    //           //GetPSByTypeName();
    //       }


    //   }


    //   protected void ddlPost_Click(object sender, EventArgs e)
    //   {
    //       ddlwARDnO.Items.Clear();
    //       //ddlPost.Items.Insert(0, "चयन करे");

    //       if (ddlPost.SelectedIndex == 0)
    //       {
    //           MessageBox(" पद का चयन करे");
    //           return;
    //       }
    //       else if (ddlPost.SelectedValue.ToString() == "1" || ddlPost.SelectedValue.ToString() == "2")
    //       {

    //           lblWard.Visible = false;
    //           lblWard1.Visible = false;
    //           ddlwARDnO.Visible = false;
    //       }
    //       else
    //       {
    //           WardList();
    //           lblWard.Visible = true;
    //           lblWard1.Visible = true;
    //           ddlwARDnO.Visible = true;

    //       }

    //   }


    //   public void WardListbyElectionID()
    //   {

    //      // select Ward_ID, Ward_NO from sys_admin.M_UBWARD where Ward_ID IN
    //     //(select WardNo from[elect_plan].[Nagriye_Notification] where ElectionStatus = '1' and  Election_Id in (select Election_Id from[sys_admin].[Election_Master] where isActive = '1') and Dst_CD = '13' and Nagriye_typeID = '3' and UB_CD = '97' );
    //   }
    //   public void WardList()
    //   {

    //       DataSet ds = new DataSet();
    //       DataTable dt = new DataTable();
    //       try
    //       {

    //           int dist = Convert.ToInt32(ddlDistrict.SelectedValue.ToString());
    //           int type = Convert.ToInt32(ddlType.SelectedValue.ToString());
    //           int UB_ID = Convert.ToInt32(ddlUBName.SelectedValue.ToString());
    //           ds = GetWardList(dist, type, UB_ID);
    //           ddlwARDnO.DataSource = ds;
    //           ddlwARDnO.DataTextField = "Ward_NO";
    //           ddlwARDnO.DataValueField = "Ward_ID";
    //           ddlwARDnO.DataBind();
    //           ListItem DistrictsDefault = new ListItem("वार्ड क्रमांक", "0");
    //           ddlwARDnO.Items.Insert(0, DistrictsDefault);


    //       }
    //       catch (Exception)
    //       {

    //       }

    //       if (ddlwARDnO.SelectedIndex < 0)
    //       {
    //           // btnSubmit.Visible = false;
    //       }
    //       else
    //       {
    //           // btnSubmit.Visible = true;
    //       }

    //   }



    //   public DataSet GetWardList(int dst_id, int TYPE_ID, int UB_ID)
    //   {

    //       //    int DistrictNo =42;
    //       DataSet ds = new DataSet();
    //       String Query;
    //       if (UB_ID == 0)
    //       {
    //           Query = "select  distinct Ward_ID, Ward_NO from sys_admin.M_UBWARD where  dst_id=" + dst_id + " and TYPE_ID=" + TYPE_ID + " ";

    //       }
    //       else
    //       {
    //           // code -786 Bhupen 19 April Code for Election Phase Based. " // Nagriye_typeID = '" + TYPE_ID + "' //"
    //        Query = "select Ward_ID, Ward_NO from sys_admin.M_UBWARD where Ward_ID IN"
    //     +"(select WardNo from[elect_plan].[Nagriye_Notification] where   Election_Id in (select Election_Id from[sys_admin].[Election_Master]" 
    //     + "where isActive = '1') and Dst_CD = '" + dst_id + "'  and UB_CD = '" + UB_ID + "' )";


    //           // Query = "select  distinct Ward_ID, Ward_NO from sys_admin.M_UBWARD where dst_id='" + dst_id + "' and TYPE_ID='" + TYPE_ID + "' and UB_ID='" + UB_ID + "'";

    //       }
    //       try
    //       {
    //           using (SqlConnection con = new SqlConnection(cs))
    //           {
    //               SqlCommand cmd = new SqlCommand(Query, con);
    //               con.Open();
    //               SqlDataAdapter sda = new SqlDataAdapter(cmd);
    //               sda.Fill(ds, "WardList");
    //           }
    //           return (ds);
    //       }
    //       catch (Exception ex)
    //       {

    //           return (ds);
    //       }
    //   }

    //   protected void ddlwARDnO_SelectedIndexChanged(object sender, EventArgs e)
    //   {
    //      // ddlNomiDate.Items.Clear();
    //    //   ddlNomiDate.Items.Insert(0, "चयन करे");
    //     //  if (ddlwARDnO.SelectedIndex == 0)
    //    //   {
    //      //     MessageBox("वार्ड का चयन करे");
    //          // return;
    //     //  }
    //     //  FillNomiDate(ddlwARDnO.SelectedItem.Value.Trim());
    //  }

    public void MessageBox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Msg", "alert('" + msg + "')", true);
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

    //Code For IN/DE  code

    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
    private string Decrypt(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }


}


