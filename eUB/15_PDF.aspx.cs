using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Drawing;
using System.Xml.Serialization;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Globalization;
 //using itextsharp.text.pdf;
//using itextsharp.text;

public partial class ePoll_eUB_15_PDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // D:\Project\Production_Backup\iems\ePoll\eUB

            string strHtml = string.Empty;
            //HTML File path -http://aspnettutorialonline.blogspot.com/
            string htmlFileName = Server.MapPath("~") + "\\ePoll\\eUB\\" + "15_PDF.aspx";
            //pdf file path. -http://aspnettutorialonline.blogspot.com/
            string pdfFileName = Request.PhysicalApplicationPath + "\\ePoll\\eUB\\" + "ConvertHTMLToPDF.pdf";

            //reading html code from html file
            FileStream fsHTMLDocument = new FileStream(htmlFileName, FileMode.Open, FileAccess.Read);
            StreamReader srHTMLDocument = new StreamReader(fsHTMLDocument);
            strHtml = srHTMLDocument.ReadToEnd();
            srHTMLDocument.Close();

            strHtml = strHtml.Replace("\r\n", "");
            strHtml = strHtml.Replace("\0", "");

            //CreatePDFFromHTMLFile(strHtml, pdfFileName);

            //Response.Write("pdf creation successfully with password -http://aspnettutorialonline.blogspot.com/");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }

    protected void btBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("./PO_HOME.aspx");

    }

}

/*
   string strPath = Server.MapPath("~");
          //  DIST_id = base64Decode(Session["DistrictId"].ToString());
            string dir = System.IO.Path.Combine("" + strPath + "\\APP_DOCS\\Pan\\" + lblDst_Name.Text.ToString() + "\\");

            Directory.CreateDirectory(dir);

            DIST_id = lblid.Text.Trim();


            string filename = DIST_id + "_RODEO.pdf";

            string path = Server.UrlDecode(lblBLOCK_ID.Text.ToString());
            if (!(new FileInfo(path).Exists))
                return;
            using (FileStream fs3 = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                SetStream1(fs3, filename);
            }



 */



