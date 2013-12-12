<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Demo_UriServerPath_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <script type="text/javascript">
        //http://www.w3schools.com/htmldom/dom_obj_location.asp
        document.write("----------JavaScript location--------------------------------" + "<br/>");
        document.write("location.href ： " + location.href + "<br/>");
        document.write("location.protocol ： " + location.protocol + "<br/>");
        document.write("location.hostname ： " + location.hostname + "<br/>");
        document.write("location.host ： " + location.host + "<br/>");
        document.write("location.port ： " + location.port + "<br/>");
        document.write("location.pathname ： " + location.pathname + "<br/>");
        document.write("location.search ： " + location.search + "<br/>");
        document.write("location.hash ： " + location.hash + "<br/>");
    </script>
</body>
</html>
