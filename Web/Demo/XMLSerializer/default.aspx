<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Demo_XMLSerializer_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnXMLToObj" runat="server" Text="XML to Object 1" 
            onclick="btnXMLToObj_Click" /><br />
        <asp:Button ID="btnXMLToObj2" runat="server" Text="XML to Object 2" onclick="btnXMLToObj2_Click" 
            />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    </div>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
