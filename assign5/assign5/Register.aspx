<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="assign5.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr> <td> </td><td> </td></tr>
			<tr> 	<td class="auto-style1">User Name:</td>      	
          	    		  	<td> <asp:TextBox ID="UserName" RunAt="server" /></td> </tr>
        <tr> 	<td class="auto-style1">Email Id:</td>      	
          	    		  	<td> <asp:TextBox ID="Email" TextMode="Email" RunAt="server" /></td> </tr>
        		<tr> 	<td class="auto-style1"> Password: </td>
					<td><asp:TextBox ID="Password" TextMode="password" RunAt="server" /> </td> </tr>
        <tr> 	<td class="auto-style1"> Confirm Password: </td>
					<td><asp:TextBox ID="ConfirmPassword" TextMode="password" RunAt="server" /> </td> </tr>	
        <tr> 	<td > Image Verifier: </td>
					          <td>
                                  <asp:Image ID="Image1" runat="server" Width="174px" Height="48px" /> 
                                  &nbsp; 
                                  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> 
                                  &nbsp; 
                                  <asp:Button ID="Button1" runat="server" Text="RELOAD" OnClick="Button1_Click" style="height: 26px" />      
					          </td> </tr>	

			<tr>
				<td class="auto-style1">
                    <br />
                    <asp:Button Text="REGISTER" OnClick="RegisterNewUser" RunAt="server" style="height: 26px" /></td>
        		</tr>
		</table>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
