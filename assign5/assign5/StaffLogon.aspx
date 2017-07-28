<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffLogon.aspx.cs" Inherits="assign5.StaffLogon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
			<tr> 	<td>User Name:</td>      	
          	    		  	<td> <asp:TextBox ID="UserName" RunAt="server" /></td> </tr>
        		<tr> 	<td> Password: </td>
					<td><asp:TextBox ID="Password" TextMode="password" 
							RunAt="server" /> </td> </tr>	
			<tr>
				<td><asp:Button Text="Log In" OnClick="LoginFunc" 
						RunAt="server" /></td>
				<td><asp:CheckBox Text="Keep me signed in" ID="Persistent" 
						RunAt="server"/> </td>
        		</tr>
		</table>
    </form>
    <h3><asp:Label ID="Output" RunAt="server" /></h3>
</body>
</html>
