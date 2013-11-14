<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Demo_RemotePost_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function fn() {
            var tb = document.getElementById("TextBox1");
            var btns = document.getElementsByClassName("btn");

            for (var i = 0; i < btns.length; i++) {
                btns[i].onclick = function () {
                    tb.textContent = "";
                };
            }
        }
    </script>
</head>
<body onload="fn();">
    <form id="form1" runat="server">
    <div>
     <b>Read Me!!</b>
    <span>This page show how to used the C# Send a POST request to other Server</span><br />
    <span>Get is easy by use a link with querystring like http://xxx.yyy.zzz/page.aspx?arg1=aaa&arg2=bbb </span><br />        
        <asp:Button ID="btnPost" runat="server" Text="Post to Page" onclick="btnPost_Click" CssClass="btn" />
        <br />
        <asp:Button ID="btnPost2" runat="server"  Text="Post"  CssClass="btn"
            onclick="btnPostWS_Click" />
        <br />
        <asp:Button ID="btnGet" CssClass="btn"  runat="server" Text="Get" onclick="btnGet_Click"  />
                <br />
        <hr />
        Result:<br />
    </div>
    <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" Height="250px" Width="600px" 
        TextMode="MultiLine"></asp:TextBox>
    </form>
</body>
</html>
