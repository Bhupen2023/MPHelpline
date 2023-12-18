<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PO_HOME.aspx.cs" Inherits="ePoll_eUB_PO_HOME" %>


   <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Well Come</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }
        form {
            border: 3px solid #f1f1f1;
        }
        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }
        button:hover {
             background-color: #11c2cd;
            color: white;
           
           
        }
        .cnbtn {
            background-color: #ec3f3f;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width:70%;
            height:20%;
            border:1px solid black;
            border-radius:4px;
        }
        .lgnbtn {
            background-color: #11c2cd;
            color: black;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
            border:1px solid black;
            border-radius:4px;
            font-weight: bold;
        }
        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }
        img.avatar {
            width: 40%;
            border-radius: 50%;
        }
        .container {
            padding: 16px;
        }
        span.psw {
            float: right;
            padding-top: 16px;
        }
        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }
            .cnbtn {
                width: 100%;
            }
        }
        .frmalg {
            margin: auto;
            width: 70%;
        }


        .hero-image {
  background-image: url("bgImag.png"); /* The image used */
  background-color:  #ccc; /* Used if the image is unavailable */
  height: 600px;
  background-position: center; /* Center the image */
  background-repeat: no-repeat; /* Do not repeat the image */
  background-size: cover; /* Resize the background image to cover the entire container */
}
        .auto-style1 {
            width: 66px;
            height: 54px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" class="frmalg">

        <div class="container">
            
        <div class="hero-image">
       <img src="../../IMAGES/elect-logo1.png" alt="" class="auto-style1">
          
                <span style="font-size: 17px; font-weight: bold"> 
M.P. State Election Commission

 </span>
            </img>
                <table style="float:right; width:50%;" >
                    <tr>
                        <td>
                            Wellcome Mr 
                        </td>
                        <td>
                            <asp:Label ID="lblName"  style="   color:#ff0000; font-weight: bold; font-size:15px;"  runat="server"
                                 Text=" "  >

                  </asp:Label>  
                        </td>
                        <td>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            Polling Both..
                        </td>
                        <td>
                            <asp:Label ID="PS_NO_Name"  style="   color:#ff0000; font-weight: bold;  font-size:15px;"  runat="server"
                                 Text=""  >

                  </asp:Label>  
                        </td>
                        <td>
                             <asp:Button runat="server" ID="btnlogout"  OnClick="btLogout_Click" Width="100" Height="40" CssClass="cnbtn" Text="Logout"  />

                        </td>
                    </tr>
                </table>
               <h1>
                   <hr />

               </h1>
           

                    <div style=" width:100%;background-color:#ff0000; height:10px;">
                        
                          <asp:Label ID="Label1"  style="   background-color:#ff0000; height:10px;  "  runat="server"
                                 Text=""  />

                    </div>

                   
            <table>
                <tr>
                    <td>
 <asp:Button runat="server" ID="btn_Login" CssClass="lgnbtn" OnClick="btnVoterSearch_Click" Text="Voter Search" />
           
                    </td>

                     <td>
 <asp:Button runat="server" ID="Button3" CssClass="lgnbtn" OnClick="btnALLVoter_Click" Text="ALL Voter List" />
           
                    </td>
                    
                    <td>
                          <asp:Button runat="server" ID="btn_cancel" OnClick="btnReports_Click"  CssClass ="lgnbtn" Text="Poll Reports"  />
          
                    </td>
                    <td>
   <asp:Button runat="server" ID="Button1" CssClass="lgnbtn"  OnClick="btnPrarup15A_Click" Text="Prarup_15"  />

                    </td>
                    <td>
   <asp:Button runat="server" ID="Button4" CssClass="lgnbtn"  OnClick="btn15_PDF_Click" Text="PDF_Prarup-15"  />

                    </td>
                      <td>
   <asp:Button runat="server" ID="Button5" CssClass="lgnbtn"  OnClick="btnPDF_SendBy_EmailClick" Text="PDF_SendBy_Email"  />

                    </td>
                </tr>
            </table>
         
            <center>

                  <asp:Panel ID="pnlvoterSearch" Visible="false"   style="width:50%; margin-top:0%; height: 250px;"  runat="server" >
      <center>
          <div class="container">
            
       
                <h3> Voter Search  form </h3>
              <table>
                  <tr>
                      <td>
 <label for="uname"><b>EPIC Number</b></label>

                      </td>
                      <td>
  <asp:TextBox runat="server" ID="txt_searchEpic" style="   color:#006699; font-weight: bold;  font-size:15px;" placeholder="Enter Epic no."></asp:TextBox>
           
                      </td>
                      <td>
   <asp:Button runat="server" ID="Button2" OnClick="btnSearch_Click" CssClass="lgnbtn" Text="Search" />
         
                      </td>
                  </tr>
              </table>
           
            </div>
           </center>
                      <asp:Panel ID="pnlgrdvw"  style="width:100%; " ScrollBars="Auto"  runat="server" >	  
                         
              <asp:Label ID="lblNORecord" Visible="false" runat="server" Text=""   Style="color:red; font-size:medium;   width:30%; height: 10%;">
                       </asp:Label>                     
           


             <asp:GridView ID="grdPS"  runat="server"  CssClass="EU_DataTable" HeaderStyle-BackColor="#ff0000" AutoGenerateColumns="false" 
                           style="width:100%;  
                    -moz-box-shadow:    inset 0 0 10px #000000;
                    -webkit-box-shadow: inset 0 0 10px #000000;
                    box-shadow:         inset 0 0 10px #000000; color:black; height:80%;  ">

  <Columns>

<asp:TemplateField HeaderText="क्रमांक."  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px" >

<ItemTemplate>

	<asp:Label ID="lblSNO" runat="server" Text=" <%# Container.DataItemIndex + 1 %>"  ></asp:Label>

</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="EPIC NO"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" >

<ItemTemplate>

   <asp:Label ID="lblEPICNO" runat="server" Text='<%#Eval ("V_EPICNO")%>'></asp:Label>
	
</ItemTemplate>
</asp:TemplateField>
        
      <asp:TemplateField HeaderText="मतदाता क्र."  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" >

<ItemTemplate>

   <asp:Label ID="lblV_SNO" runat="server" Text='<%#Eval ("V_SNO")%>'></asp:Label>
	
</ItemTemplate>
</asp:TemplateField> 
         


          <asp:TemplateField HeaderText="नाम"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="180px" >

<ItemTemplate>

   <asp:Label ID="lblV_Name" runat="server" style="text-align: left !important; float:left; color:#006699;  font-size:medium; " Text='<%#Eval ("V_Name")%>'></asp:Label>
	
</ItemTemplate>
</asp:TemplateField>
        <asp:TemplateField HeaderText="पिता का नाम " ItemStyle-Width="150">
            <ItemTemplate>

                <asp:Label ID="lblV_Fname" runat="server" style="text-align: left !important; float:left; color:#006699;  font-size:medium; " Text='<%#Eval ("V_Fname")%>'></asp:Label>

               
                
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="लिंग" ItemStyle-Width="100">
            <ItemTemplate>
               <asp:Label ID="lblV_Gender" runat="server" style="text-align: left !important; float:left; color:#006699;  font-size:medium; " Text='<%#Eval ("V_Gender")%>'></asp:Label>
	           
            </ItemTemplate>
        </asp:TemplateField>
      
        <asp:TemplateField HeaderText="आयु" ItemStyle-Width="100">
            <ItemTemplate>
               <asp:Label ID="lblV_Age" runat="server" style="text-align: left !important; float:left; color:#006699;  font-size:medium; " Text='<%#Eval ("V_Age")%>'></asp:Label>
	           
            </ItemTemplate>
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Action" ItemStyle-Width="60">
            <ItemTemplate>                
           
                    <asp:Button ID="btnsave1" OnClick="btn_SelectToken" Text="Select" class="lgnbtn"  runat="server"                  
                   /> 
               
            </ItemTemplate>
        </asp:TemplateField>
       
</Columns>   
</asp:GridView>
</asp:Panel>
                      </asp:Panel>

                 

                 


                </center>
           </div>
    </form>
</body>
</html>