<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkWIthPDF.aspx.cs" Inherits="ePoll_eUB_WorkWIthPDF" %>

<!DOCTYPE html>
<html>
<head>
   <title>Export HTML to PDF</title>
  
 <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/2.5.1/jspdf.umd.min.js "></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/1.4.1/html2canvas.min.js"></script>

</head>
    <script type="text/javascript">
    window.jsPDF = window.jspdf.jsPDF;
var docPDF = new jsPDF();

function downloadPDF(invoiceNo){
   
    var elementHTML = document.querySelector("#pnlResult");
    docPDF.html(elementHTML, {
        callback: function(docPDF) {
            docPDF.save(invoiceNo+'.pdf');
        },
        x: 15,
        y: 15,
        width: 170,
        windowWidth: 650
    });
}

</script>

<body>

    <form id="form1" runat="server">

   <div id="myBillingArea">
       <center>

       
<div   style="width:100%;  -moz-box-shadow:    inset 0 0 10px #000000;
   -webkit-box-shadow: inset 0 0 10px #000000;
   box-shadow:         inset 0 0 10px #000000;  background-color:lightsteelblue;  " >



  <asp:Button ID="btnprint"  runat="server" Text="Print/SAVE" 
        OnClientClick = "return PrintOLIN();" style="margin-top:5px; margin-left:10px; float:left;
 color:black; font-size:medium;  background-color:#e6fe0f; width:100px; height:40px;    border-radius:4px; " />
    

    <center>
       
        <asp:Panel ID="pnlResult"   style="width:90%;    border-radius: 4px; 
 " runat ="server">

             <center>
       <b>  प्ररूप - 15 </b>
              </center>
       <center>
        <b>
            (नियम 67 देखिए)
        </b>
            </center>
      <center>
        <b>
           भाग 1 - मतपत्र लेखा
        </b>
            </center>
       
  
       
        <center>
            <div style=" width:100%;  border:1px solid black;">
                <table>
                    <tr style="  border:1px solid black;">
                        <td style="padding-left:7px;" >ग्राम पंचायत  </td>
                        <td class="auto-style4">
                         
                                 <asp:Label ID="lblGP_Name" runat="server" 
                                     style=" color:black; font-weight: bold;  font-size:12px;" Text="" />
       
                        </td>
                        <td class="auto-style3">के वार्ड क्रमांक.... </td>
                        <td style="width:100px;">
                            <asp:Label ID="txt_GramWardNO" runat="server" 
                                     style=" color:black; font-weight: bold;  font-size:12px;" Text="" />
       

                        </td>
                        <td class="auto-style2">से पंच का निर्वाचन* </td>
                    </tr>
                 <tr style="  border:1px solid black;">
                         <td style="padding-left:7px;" >ग्राम पंचायत  </td>
                        <td class="auto-style4">
                           <asp:Label ID="lblGP_NameSAR" runat="server" 
                                     style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
       
                        </td>
                        <td colspan="2">से सरपंच का निर्वाचन* </td>
                    </tr>
                     <tr style="  border:1px solid black;">
                        <td style="padding-left:7px;" > जनपद पंचायत .... </td>
                        <td class="auto-style4">
                         
                             <asp:Label ID="txt_JAN" runat="server" 
                                     style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
       

                        </td>
                        <td class="auto-style3">के निर्वाचन क्षेत्र क्रमांक.. </td>
                        <td style="width:100px;">
                           
                             <asp:Label ID="txt_JAN_SNO" runat="server" 
                                     style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
       


                           
                        </td>
                        <td class="auto-style2">से सदस्य का निर्वाचन* </td>
                    </tr>
                    <tr style="  border:1px solid black;">
                         <td style="padding-left:7px;" > जिला पंचायत .... </td>
                        <td class="auto-style4">
                            
                                <asp:Label ID="txt_ZP" runat="server" 
                                     style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
       
                        </td>
                        <td class="auto-style3">के निर्वाचन क्षेत्र क्रमांक.. </td>
                        <td style="width:100px;">
                           
                             <asp:Label ID="txt_ZP_SNO" runat="server" 
                                     style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
       
                        </td>
                        <td class="auto-style2">से सदस्य का निर्वाचन* </td>
                    </tr>
                     <tr style="  border:1px solid black;">
                        <td style="padding-left:7px;" > मतदान केद्र का क्रमांक </td>
                        <td class="auto-style4">
                            <asp:Label ID="txt_PSNO" runat="server" 
                                     style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
       
                        </td>
                        
                        <td>खण्ड का नाम </td>
                        <td >
                                 <asp:Label ID="lblBlockName" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
   
                        </td>
                    </tr>
                     <tr>
                        
                        <td colspan="5">
                        
                            <hr style=" width:100%;background-color:#000000; height:2px;">

                                 </hr>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                                

                <table class="auto-style5">
                   
                    <tr>
                        <td  style="width:10px;">
                            
                            </td>
                         <td class="auto-style6">
                           
                            </td>
                               <td  style="width:80px;">
                                        अनुक्रमांक 
                                 से 
                                    </td>
                                   <td  style="width:80px;">
                                     तक
       </td>
                                     <td  style="width:80px;">
                                   कुल संख्या
                                    </td>
                                  <td  style="width:20px;">

                                   </td>
                    </tr>
                    <tr>
                        <td  style="width:10px;">
                            1.
                            </td>
                         <td class="auto-style6">
                             पीठासीन अधिकारी द्वारा प्राप्त मतपत्रों की संख्या
                            </td>
                               <td  style="width:80px;">
                                     <asp:Label ID="lbl_PO_1MATFROM" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
   
                                    </td>
                                   <td  style="width:80px;">
                                  <asp:Label ID="lbl_PO_1MATTO" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
       </td>
                                     <td  style="width:80px;">
                                    <asp:Label ID="lbl_PO_1MAT_TOtal" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
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
                                     <asp:Label ID="lbl_PO_2USE_FROM" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
   
                                    </td>
                                   <td  style="width:80px;">
                                  <asp:Label ID="lbl_PO_2USE_TO" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
       </td>
                                     <td  style="width:80px;">
                                    <asp:Label ID="lbl_PO_2USE_TOTAL" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
                                    </td>
                                  <td  style="width:20px;">

                                   </td></tr>

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
                                       <asp:Label ID="lblPO_3" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
                                    
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
                                         <asp:Label ID="lblPO_4A" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
                                    
                                       
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
                                     <asp:Label ID="lblPO_4B" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
                                    
                                       
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
                                  
                                
                                    <asp:Label ID="lblPO_4C" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
                                    
                                
                                       
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
                                      
                                    <asp:Label ID="lblPO_5" runat="server" style=" color:black; font-weight: bold;  font-size:12px;" Text="NIL" />
                                   
                                       
                                    </td>
                                  <td  style="width:20px;">

                                   </td>
                    </tr>

                  <tr>
                        <td colspan="5">
                        
                           
                                 <hr style=" width:100%;background-color:#000000; height:2px;">

                                 </hr>
          </td>
                      </tr>
                    <tr>
                        <td colspan="5">
                            <table>
                     
                     <tr>
                        <td>
                            <div id="Div1" runat="server" style=" font-size:14px;margin-top:150px; margin-left:00px;">
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
                          <td>
                              <div id="topdv3" runat="server" style=" border-radius:50%; font-size:14px;margin-top:180px; margin-left:350px;">
                    <table style="width: 50px;   height: 50px;  border: 1px solid black;    border-radius: 50%;       margin: auto;">
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
                         <td>
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
                                <asp:Label ID="Label3" runat="server" Style="font-size:14px;" Text=".............................." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Style="font-size:14px;" Text="नाम........................" />
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
      
        <h4></h4>
      
    </h4>
               
    
       </asp:Panel>
        
    </center>


    </div>
             </center>
    
       </div>


       <button type="button" onclick="downloadPDF(12)">Download PDF</button>
        </form>
</body>
</html>