<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PO_Reports.aspx.cs" Inherits="ePoll_eUB_PO_Reports" %>



   <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>All Reports Send</title>

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

        .circle { 
            width: 50px; 
            height: 50px; 
            border: 1px solid black; 
            border-radius: 50%; 
            margin: auto; 
        } 
        .hero-image {
           
   height: 100%;
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
                                 Text="राजेश कुमार शर्मा "  >

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
                                 Text="45916 - शा.हाईस्कूल भवन हसनपुर तिनोनिया"  >

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
            <asp:Button runat="server" ID="btn_Login" CssClass="lgnbtn" Width="80px" OnClick="btBack_Click" Text="Back" />
 

            <center>
                 <h3> PO – द्वारा मतदान केंद्र से भेजे जाने वाली रिपोर्ट्स 
 </h3>
            </center>
          

            <center>

              <table>
                  <tr>
                      
                      <td>
   <asp:Button runat="server" ID="Button2"   CssClass="lgnbtn" BackColor="LightBlue"  Height="60px" Text="मतदान दल के सकुशल पहुचने की जानकारी - Click" />
         
                      </td>
                      <td>
   <asp:Button runat="server" ID="Button1"   CssClass="lgnbtn" BackColor="LightBlue" Height="60px"  Text=" MOCK Poll होने की जानकारी
 - Click" />
                      </td>
                      <td></td>
<td>
   <asp:Button runat="server" ID="Button3"   CssClass="lgnbtn" BackColor="LightBlue" Height="60px"  Text="  वास्तविक मतदान प्रारंभ होने की जानकारी- Click" />
         
                      </td>
                     

                  </tr>
              </table>
             </center>
          
             <center>
                 <h3> मतदान के  प्रतिशत की जानकारी

 </h3>
           
          
            <table style="border:1px solid black; width:100%; height:150px; border-radius:4px;" >

                <tr style="margin:10px; background-color:#095D82;  font-size:16px;" >
                     <td style=" text-align:center;    color:white; font-size:16px;"   >
                        <asp:Label ID="lblblock"  style="    color:white; font-size:16px;"  runat="server" Text="विकाशखंड का नाम"  />

                    </td>
                    <td style=" text-align:center;    color:white; font-size:16px;"   >
                            <asp:Label ID="Label2"   style="    color:white; font-size:16px;"   runat="server" Text=" समय-तक "  />
             
                    </td>
                         <td style=" text-align:center;    color:white; font-size:16px;"   >
               <p>
                      कुल  पुरुष मतदाताओ की संख्या 
       
               </p>
                     <asp:Label ID="lblMale"  style=" color:white; font-size:20px;"   runat="server" Text="34 "  />
                
                    </td>
                    <td style=" text-align:center;    color:white; font-size:16px;"   >
                 <p>
                         कुल   महिला मतदाताओ की संख्या  
                 </p>
                        
          <asp:Label ID="lblFemale"   style=" color:white; font-size:20px;"  runat="server" Text="45 "  />
                
                    </td>
                           <td style=" text-align:center;    color:white; font-size:16px;"   >
                 <p>
          कुल   अन्य मतदाताओ की संख्या  
                     </p>
          <asp:Label ID="lblOthers"   style=" color:white; font-size:20px;"  runat="server" Text="788 "  />
               
                    </td>
                  <td style=" text-align:center;    color:white; font-size:16px;"   >
                <p style=" text-align:center;    color:white; font-size:16px;"  >
                          कुल   मतदाताओ की संख्या     
        
                </p>
                    
          <asp:Label ID="lblTotal"  style="  text-align:center; color:white; font-size:20px;"   runat="server" Text="7888"  />
               
                    </td>
                 <td style=" text-align:center;    color:white; font-size:16px;"   >
                        सेव करे
                    </td>
                </tr>

                   <tr style="margin:10px; background-color:greenyellow;  font-size:16px;" >
                   <td style=" text-align:center;    color:white; font-size:16px;"   >
                           <asp:Label ID="lblblockname"  style="    color:red; font-size:16px;"  runat="server" Text="  "  />
                    </td>
                     <td>
                          <asp:DropDownList
                                 Style="width: 100px;  height: 40px;color:#095D82;border-radius:4px;  border:2px solid Blue; text-align:center; text-align:center;  font-size:medium; "
                                 
                                  ID="ddlTime_per" 
                                 runat="server"   CssClass="form-control"  >
                                              <asp:ListItem Text="चयन करे" Value="0">
                      </asp:ListItem>
                      <asp:ListItem Text="9AM" Value="9AM"> </asp:ListItem>
                           <asp:ListItem Text="11AM" Value="11AM"> </asp:ListItem>
                                <asp:ListItem Text="1PM" Value="1PM"> </asp:ListItem>
                                     <asp:ListItem Text="3PM" Value="3PM"> </asp:ListItem>
                                     <asp:ListItem Text="मतदान - समाप्ति" Value="5PM"> </asp:ListItem>
                                      
                </asp:DropDownList>
                    </td>
                     <td>
                 <span style="  color:red;  font-size:medium; ">
          कुल पुरुष मतदान  : 
          <asp:Label ID="lblMale_Vote"  style="   
  border-bottom-style: solid; color:black; font-size:20px;"  runat="server" Text="4 "  />
                 </span>  
                    </td>
                     <td>
                 <span style="  color:red;  font-size:medium; ">
          कुल   महिला मतदान   : 
          <asp:Label ID="lblFemale_Vote"   style=" 
  border-bottom-style: solid;   color:black; font-size:20px;"  runat="server" Text="5 "  />
                 </span>  
                    </td>
                      <td>
                 <span style="  color:red;  font-size:medium; ">
          कुल अन्य मतदान   : 
          <asp:Label ID="lblOthers_Vote"   style="  
  border-bottom-style: solid;   color:black; font-size:20px;"  runat="server" Text="5 "  />
                 </span>  
                    </td>

                     <td>
                 <span style="  color:red;  font-size:medium; ">
          कुल   मतदान   : 
          <asp:Label ID="lblTotal_Vote"   style=" 
  border-bottom-style: solid;   color:black; font-size:20px;" runat="server" Text="45454"  />
                 
                 
                 
                 </span>  
                    </td>
                   <td>
                          <asp:Button ID="btnPer_SAVE"    Onclick="SAVE_PER"   style=" margin-top:5px; background-color:orangered; color:white; width:80px; height:30px; border-radius:4px; border:1px solid black;"  runat="server"    Text="SAVE"></asp:Button>

                   </td>
                </tr>
                
            </table>
      <center>
          <h3> अभी तक के मतदान की जानकारी
         </h3>
  
</center>
                 <center>

                            <asp:GridView ID="grd_per"    AutoGenerateColumns="false"  runat="server" 
              style="  border-radius:4px;  text-align:center;
                    -moz-box-shadow:    inset 0 0 10px #000000;
                    -webkit-box-shadow: inset 0 0 10px #000000;
                    box-shadow:         inset 0 0 10px #000000; font-weight:bold; 
                                            font-size: 18px;background-color:#095D82; width:1000px;  color:white; font-size:14px;  ">
    <Columns>
<asp:TemplateField HeaderText=" S.No."  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px" >
<ItemTemplate>
	<asp:Label ID="lblSNO" runat="server" Text=" <%# Container.DataItemIndex + 1 %>"  ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

         <asp:TemplateField HeaderText="ID No."  Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px" >
<ItemTemplate>
	<asp:Label ID="lblEleID" runat="server" Text='<%#Eval ("EleID")%>'   ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
        
     
 <asp:TemplateField HeaderText="Reported Time"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" >
<ItemTemplate>
	<asp:Label ID="lblTime" runat="server" Text='<%#Eval ("Time_per")%>'   ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText=" MALE "  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" >
<ItemTemplate>
	<asp:Label ID="lblMale_Vot" runat="server" Text='<%#Eval ("Male_Vot")%>'   ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
 <asp:TemplateField HeaderText="Female"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" >
<ItemTemplate>
	<asp:Label ID="lblFemale_Vot" runat="server" Text='<%#Eval ("Female_Vot")%>'   ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
 <asp:TemplateField HeaderText="Others"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" >
<ItemTemplate>
	<asp:Label ID="lblFemale_Vot" runat="server" Text='<%#Eval ("Others_Vot")%>'   ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

         <asp:TemplateField HeaderText="Total "  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" >
<ItemTemplate>
	<asp:Label ID="lblTotal_Vot" runat="server" Text='<%#Eval ("Total_Vot")%>'   ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
        
               <asp:TemplateField HeaderText="Date Time"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" >
<ItemTemplate>
	<asp:Label ID="lblCreated_Date" runat="server" Text='<%#Eval ("Created_Date")%>'   ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
   
</Columns>
  
</asp:GridView>
                        </center>
               </center>
                
           </div>
    </form>
</body>
</html>
