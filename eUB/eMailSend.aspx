<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eMailSend.aspx.cs" Inherits="ePoll_eUB_eMailSend" %>


   <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Send Email</title>

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
            color: black;
           
           
        }
        .cnbtn {
            background-color: #ec3f3f;
            color: black;
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
    <script lang="javascript" type="text/javascript">
    function ValidateRegForm() {
        var email = document.getElementById("<%=txt_email.ClientID%>");
        var filter = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
        if (!filter.test(email.value)) {
            alert('Please provide a valid email address');
            email.focus;
            return false;
        }
        return true;
    }
</script>
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

                   </td>
                    <td>
    <asp:Button runat="server" ID="btn_Login" CssClass="lgnbtn" style=" margin-top:5px; background-color:orangered;  "   OnClick="btBack_Click" Text="Back" />
                            </td>
                    <td>
   <asp:Button runat="server" ID="Button4" CssClass="lgnbtn"  OnClick="btn15_PDF_Click" Text="PDF_Prarup-15"  />

                    </td>
                     <td>
   <asp:Button runat="server" ID="btnsend" CssClass="lgnbtn"  OnClick="btnSendEmailpage" Text="Email Send"  />

                    </td>
                </tr>
            </table>
         
                  <center>

                  <asp:Panel ID="pnlvoterSearch" Visible="false"   style="width:900px; margin-top:0%; height: 100px;"  runat="server" >
               <table style="border:1px solid black; width:800px; height:60px; border-radius:4px;" >

                <tr style=" background-color:#ccc;  font-size:16px;" >
                     <td style=" text-align:center;    color:black; font-size:16px;"   >
                        <asp:Label ID="lblblock"  style="    color:black; font-size:16px;"  runat="server" Text="NAME"  />

                    </td>
                    <td style=" text-align:center;    color:black; font-size:16px;"   >
                            <asp:TextBox runat="server" ID="txt_Name" style="   color:#006699; font-weight: bold;  font-size:15px;" placeholder="Enter Name."></asp:TextBox>
                    </td>
                        <td style=" text-align:center;    color:black; font-size:16px;"   >
                        <asp:Label ID="Label2"  style="    color:black; font-size:16px;"  runat="server" Text="Email-ID"  />

                    </td>
                    <td style=" text-align:center;    color:black; font-size:16px;"   >
                            <asp:TextBox runat="server" ID="txt_email" style="   color:#006699; font-weight: bold;  font-size:15px;" placeholder="Enter Email-ID."></asp:TextBox>


                    </td>
                           
                 <td style=" text-align:center;    color:black; font-size:16px;"   >
                       
                     <asp:Button ID="btnPer_SAVE" OnClientClick="return ValidateRegForm();"   Onclick="Send"   style=" margin-top:5px; background-color:orangered; color:black; width:80px; height:30px; border-radius:4px; border:1px solid black;"  runat="server"    Text="Send"></asp:Button>
                    </td>
                </tr>

                      </table>



                  </asp:Panel>

                </center>
           </div>
    </form>
</body>
</html>
