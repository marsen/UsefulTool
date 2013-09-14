<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Demo_DataAccess_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>Original DataSource:</p>
    <asp:GridView ID="gvDataTableForSQL" runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "LastName")%> <%# DataBinder.Eval(Container.DataItem, "FirstName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "Title")%> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    <p>GetSingleValueForSQL:</p>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        <asp:Button ID="btnSingleValueForSQL" runat="server" Text="Get Title by Name" 
            onclick="btnSingleValueForSQL_Click" />>><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <p>GetDataTableForSQL:</p>
        <asp:DropDownList ID="ddlTitle" runat="server"></asp:DropDownList>
        <asp:Button ID="btnDataTableForSQL" runat="server" Text="Get Table by Title" 
            onclick="btnDataTableForSQL_Click" />>>
            <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "LastName")%> <%# DataBinder.Eval(Container.DataItem, "FirstName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "Title")%> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
