<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PS_LIST.aspx.cs" Inherits="ePoll_eUB_PS_LIST" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   
        <center>
        <asp:Panel ID="pnlgrdvw"  style="width:96%; margin-left:2%; height: 565px;" ScrollBars="Auto"  runat="server" >	  
                 
                  
        <asp:Label ID="lblError" runat="server"  Text=" "  style="font-size:large;  border:0px;  color:maroon; " ></asp:Label>
     
               
             <asp:GridView ID="grdPS"  runat="server"  CssClass="EU_DataTable" HeaderStyle-BackColor="#49bbf4" AutoGenerateColumns="false" 
                           style="width:100%;  
                    -moz-box-shadow:    inset 0 0 10px #000000;
                    -webkit-box-shadow: inset 0 0 10px #000000;
                    box-shadow:         inset 0 0 10px #000000; font-size:12px; 
                     min-height: 200px;  margin-top:1%">

                    <Columns>

<asp:TemplateField HeaderText="क्र."  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px" >

<ItemTemplate>

	<asp:Label ID="lblSNO" runat="server" Text=" <%# Container.DataItemIndex + 1 %>"  ></asp:Label>

</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="वार्ड क्र."   ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="20px" >

<ItemTemplate>

	<asp:Label ID="lblWard_NO" runat="server" Text='<%#Eval ("Ward_NO")%>'></asp:Label>
	
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="मतदान केंद्र क्र."   ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="20px" >

<ItemTemplate>

	<asp:Label ID="lblps_id" runat="server" Text='<%#Eval ("PS_NO")%>'></asp:Label>
	
</ItemTemplate>
</asp:TemplateField>



<asp:TemplateField HeaderText="मतदान केंद्र का नाम"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="220px" >

<ItemTemplate>

 <asp:Label ID="lblps_Name" runat="server" style="text-align: left !important; float:left; color:#006699;  font-size:medium; " 
      Text='<%#Eval ("PS_Name")%>'>
 </asp:Label>
	

	
</ItemTemplate>
</asp:TemplateField>
          
     
        
</Columns>   
</asp:GridView>
</asp:Panel>
    </center>



    </form>
</body>
</html>
