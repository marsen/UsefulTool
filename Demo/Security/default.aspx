<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Demo_Security_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>DES:</p>
        <p>KEY(8碼):<asp:TextBox ID="tbDESKey" ReadOnly="true" runat="server"></asp:TextBox>IV(8碼):<asp:TextBox ID="tbDESIV" ReadOnly="true" runat="server"></asp:TextBox></p>
        <p>
        加密前:<asp:TextBox ID="tbDESInput" runat="server"></asp:TextBox>
        <asp:Button ID="btnDESenCrypt" runat="server" Text="DES加密" 
            onclick="btnDESenCrypt_Click" />
        加密後:<asp:TextBox ID="tbDESenCrypt" runat="server" ReadOnly="true" Width="280px"></asp:TextBox>
        <asp:Button ID="btnDESdeCrypt" runat="server" Text="DES解密" 
            onclick="btnDESdeCrypt_Click" />
        解密:<asp:TextBox ID="tbDESdeCrypt" runat="server" ReadOnly="true"></asp:TextBox></p>
    </div>
    </form>
</body>
</html>
