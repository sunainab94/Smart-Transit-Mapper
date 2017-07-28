<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="assign5.MemberPage.Map" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=false&amp;key=AIzaSyAlxrtZR08GxHYK2MxraCZglpQQAu19fl4" type="text/javascript"></script> 
    <asp:Label ID="outputlist" runat="server"></asp:Label>
</head>
<body onload = "initialize()" onunload="GUnload()">
    <form id="form1" runat="server">
    <div id="map_canvas" style="width: 710px; height: 328px">
            &nbsp;</div>
    </form>
</body>
</html>
