<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Prarup15A.aspx.cs" Inherits="ePoll_Prarup15A" %>

   <!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
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
       
        .auto-style4 {
            width: 214px;
        }
        .auto-style5 {
            width: 1063px;
        }
        .auto-style6 {
            width: 437px;
        }
        .auto-style7 {
            width: 149px;
        }
        .auto-style8 {
            width: 119px;
        }

     

    </style>
    <script type = "text/javascript">
       
        function PrintPanel() {

            var panel = document.getElementById("<%=pnlResult.ClientID %>");
            panel.style.display = "block";
            var printWindow = window.open('', '', 'height=800,width=800');
            printWindow.document.write('<html><head><title> मध्य प्रदेश राज्य निर्वाचन आयोग   </title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);

            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="frmalg">

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
                            <asp:Label ID="lblName"  style="   color:#ff0000; font-weight: bold; font-size:12px;"  runat="server"
                                 Text=""  >

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
                            <asp:Label ID="PS_NO_Name"  style="   color:#ff0000; font-weight: bold;  font-size:12px;"  runat="server"
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
 <asp:Button runat="server" ID="btn_Login" CssClass="lgnbtn" OnClick="btBack_Click" Text="Back" />
           
                    </td>
                   
                </tr>
            </table>
         
              <asp:Panel ID="pnlgrdvw"  style="" ScrollBars="Auto"  runat="server" >	  
                          
   
             <asp:Panel ID="pnlResult"   style="   
  background-color:#FFFFFF; margin-bottom:20px;" runat ="server">

                

    <h4 style="text-align:center;">
        प्ररूप - 15 
        <p style="text-align:center;">
            (नियम 67 देखिए)
        </p>
        <h4 style="text-align:center;">
       भाग 1 - मतपत्र लेखा
    </h4>
        <h4></h4>
        <div style=" width:100%;background-color:#000000; height:2px;">
            <asp:Label ID="Label7" runat="server" style="   background-color:#000000; height:2px;  " Text="" />
        </div>
        <center>
            <div style="  border:1px solid black;">
                <table>
                    <tr>
                        <td>ग्राम पंचायत  </td>
                        <td class="auto-style4">
                         
                                 <asp:Label ID="lblGP_Name" runat="server" 
                                     style=" color:black; font-weight: bold;  font-size:12px;" Text="" />
       
                        </td>
                        <td class="auto-style3">के वार्ड क्रमांक.... </td>
                        <td style="width:100px;">
                            <asp:TextBox ID="txt_GramWardNO" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                        </td>
                        <td class="auto-style2">से पंच का निर्वाचन* </td>
                    </tr>
                    <tr>
                        <td>ग्राम पंचायत  </td>
                        <td class="auto-style4">
                           <asp:Label ID="lblGP_NameSAR" runat="server" 
                                     style=" color:black; font-weight: bold;  font-size:12px;" Text="" />
       
                        </td>
                        <td colspan="2">से सरपंच का निर्वाचन* </td>
                    </tr>
                    <tr>
                        <td>जनपद पंचायत .... </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txt_JAN" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                        </td>
                        <td class="auto-style3">के निर्वाचन क्षेत्र क्रमांक.. </td>
                        <td style="width:100px;">
                            <asp:TextBox ID="txt_JAN_SNO" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                        </td>
                        <td class="auto-style2">से सदस्य का निर्वाचन* </td>
                    </tr>
                    <tr>
                        <td>जिला पंचायत .... </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txt_ZP" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                        </td>
                        <td class="auto-style3">के निर्वाचन क्षेत्र क्रमांक.. </td>
                        <td style="width:100px;">
                            <asp:TextBox ID="txt_ZP_SNO" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                        </td>
                        <td class="auto-style2">से सदस्य का निर्वाचन* </td>
                    </tr>
                    <tr>
                        <td>मतदान केद्र का क्रमांक </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txt_PSNO" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                        </td>
                        
                        <td>खण्ड का नाम </td>
                        <td >
                                 <asp:Label ID="lblBlockName" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="विकाशखंड का नाम " />
   
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                              <div style=" background-color:#000000; height:1px;">
            <asp:Label ID="Label5" runat="server" style="   background-color:#000000; height:1px;  " Text="" />
        </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                                <div style="width:330px; float:right; margin-right:20px; margin-top:5px; ">
                     <table>
                                <tr>
                                    
                                    <td colspan="2">
                                       <p style="margin-left:20px;">
                                            अनुक्रमांक
                                       </p> 
                                    </td>
                                    <td>

                                    </td>
                                     <td>
                                        
                                             कुल संख्या
                                      
                                    </td>
                                    <td>

                                    </td>
                                  
                                </tr>
                                <tr>
                                    <td>

                                    </td>
                                    <td class="auto-style8">
                                        से
                                    </td>
                                     <td class="auto-style7" >
                                        तक
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                            </table>
                </div>

                <table class="auto-style5">
                   
                    <tr>
                        <td  style="width:10px;">
                            1.
                            </td>
                         <td class="auto-style6">
                             पीठासीन अधिकारी द्वारा प्राप्त मतपत्रों की संख्या
                            </td>
                               <td  style="width:80px;">
                                      <asp:TextBox ID="TextBox2" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                                    </td>
                                   <td  style="width:80px;">
                                         <asp:TextBox ID="TextBox3" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                                    </td>
                                     <td  style="width:80px;">
                                        <asp:TextBox ID="TextBox4" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                                    </td>
                                  <td  style="width:20px;">

                                   </td>
                    </tr>

                    <tr>
                        <td  style="width:10px;">
                            2.
                            </td>
                         <td class="auto-style6">
                              उपयोग में न लाए गए मतपत्रों की संख्या
                            </td>
                               <td  style="width:80px;">
                                      <asp:TextBox ID="TextBox5" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                                    </td>
                                   <td  style="width:80px;">
                                         <asp:TextBox ID="TextBox6" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                                    </td>
                                     <td  style="width:80px;">
                                        <asp:TextBox ID="TextBox7" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                                    </td>
                                  <td  style="width:20px;">

                                   </td>
                    </tr>

                    <tr>
                        <td  style="width:10px;">
                            3.
                            </td>
                         <td>
                             मतदान केंद्र पर उपयोग मे लाए गए मतपत्रों की संख्या
                          
                             <span>(1-2=3)</span>
                             
                            </td>
                         <td  style="width:20px;">

                                   </td>
                               <td colspan="2" style="width:80px;">
                                      <asp:TextBox ID="TextBox8" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                                  
                                       
                                    </td>
                                  <td  style="width:20px;">

                                   </td>
                    </tr>

                    <tr>
                        <td  style="width:10px;">
                            4.
                            </td>
                         <td>
                             मतदान केंद्र पर उपयोग मे लाए गए किंतु मतपेटी में मही डाले गये मतपत्रों की संख्या
                          
                           
                            </td>
                         <td  style="width:20px;">

                                   </td>
                               <td colspan="2" style="width:80px;">
                                    
                                    </td>
                                  <td  style="width:20px;">

                                   </td>
                    </tr>

                    <tr>
                        <td  style="width:10px;">
                           
                            </td>
                         <td>
                            (क) मुद्रण या लेखन की त्रुटीक के कारण रद्द किए गए मतपत्रों की संख्या
                          
                            </td>
                         <td  style="width:20px;">

                                   </td>
                               <td colspan="2" style="width:80px;">
                                      <asp:TextBox ID="txt_Print" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                                  
                                       
                                    </td>
                                  <td  style="width:20px;">

                                   </td>
                    </tr>


                    <tr>
                        <td  style="width:10px;">
                           
                            </td>
                         <td>
                            (ख) निविदत्त मतपत्रों के रूप में उपयोग में लाए गए मतपत्रों की संख्या.
                          
                            </td>
                         <td  style="width:20px;">

                                   </td>
                               <td colspan="2" style="width:80px;">
                                      <asp:TextBox ID="txt_nividatt" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                                  
                                       
                                    </td>
                                  <td  style="width:20px;">

                                   </td>
                    </tr>

                    <tr>
                        <td  style="width:10px;">
                           
                            </td>
                         <td>
                            (ग) रद्द किए गए मतपत्रों की संख्या
                          
                            </td>
                         <td  style="width:20px;">
                              योग (क+ख+ग)
                                   </td>
                     
                               <td colspan="2" style="width:80px;">
                                  
                                      <asp:TextBox ID="txt_radd" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                                  
                                       
                                    </td>
                                  <td  style="width:20px;">

                                   </td>
                    </tr>

                    <tr>
                        <td  style="width:10px;">
                           5.
                            </td>
                         <td>
                            मतपेटी में पाए जाने वाले मतपत्रों की संख्या (3-4=5)
                          
                            </td>
                         <td  style="width:20px;">

                                   </td>
                               <td colspan="2" style="width:80px;">
                                      <asp:TextBox ID="txt_matpeti" runat="server"  style=" color:#006699; font-weight: bold;  font-size:12px;"></asp:TextBox>
                                  
                                       
                                    </td>
                                  <td  style="width:20px;">

                                   </td>
                    </tr>

                   <tr>
                        <td colspan="5">
                              <div style=" background-color:#000000; height:1px;">
            <asp:Label ID="Label4" runat="server" style="   background-color:#000000; height:1px;  " Text="" />
        </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="5">
                            <table>
                     
                     <tr>
                        <td colspan="2">
                            <div id="Div1" runat="server" style=" font-size:14px;margin-top:180px; margin-left:00px;">
                    <table>
                        <tr>
                            <td>
                                <center>
                                    <asp:Label ID="Label6" runat="server" Style="text-align:center;font-size:14px;" Text="स्थान............" />
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <center>
                                    <asp:Label ID="Label8" runat="server" Style="text-align:center;font-size:14px;" Text="तारीख़............" />
                                </center>
                            </td>
                        </tr>
                        
                    </table>
                </div>
                        </td>

                        <td>

                        </td>
                          <td colspan="2">
                              <div id="topdv3" runat="server" style=" border-radius:50%; font-size:14px;margin-top:180px; margin-left:350px;">
                    <table class="circle">
                        <tr>
                            <td>
                                <center>
                                    <asp:Label ID="Label2" runat="server" Style="text-align:center;font-size:14px;" Text="मोहर " />
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               
                            </td>
                        </tr>
                        
                    </table>
                </div>
             </td>
                         <td colspan="2">
                              <div id="Div2" runat="server" style=" font-size:14px;margin-top:180px; margin-left:350px;">
                    <table>
                        <tr>
                            <td>
                                <center>
                                    <asp:Label ID="Label9" runat="server" Style="text-align:center;font-size:14px;" Text="पीठासीन अधिकारी के हस्ताक्षर " />
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Style="font-size:14px;" Text="नाम..........................." />
                            </td>
                        </tr>
                        
                    </table>
                </div>
             </td>
                    </tr>
                </table>
                        </td>
                    </tr>





                </table>
                </td>
                </tr>
             </table>
                
                
            
                
            </div>
        </center>
      
    </h4>
               
    
       </asp:Panel>   
            
</asp:Panel>
                
           </div>
    </form>
</body>
</html>
