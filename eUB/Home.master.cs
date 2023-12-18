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
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.Drawing.Imaging;

public partial class ePoll_eUB_Home : System.Web.UI.MasterPage


{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*  bool network = CheckForInternetConnection();
          if(network)
          {
             // MessageBox("Internet working ...");
          }
          else
          {
              MessageBox("Internet not working please connect with internet ");
          }*/
    }
    public void MessageBox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Msg", "alert('" + msg + "')", true);
    }
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
}

