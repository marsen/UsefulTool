<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Demo_PageJs_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    
</head>
<body>
    <form id="form1" runat="server">
    <div id="pager">
    
    </div>
    </form>
</body>
<link href="css/Pager.css" rel="stylesheet" />
<script src="Pager.js"></script>
<script>    
    //example
    document.getElementById("pager").Pager({ count: 48, range: 2, page: 3 });
</script>
</html>
