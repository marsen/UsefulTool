using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demo_UriServerPath_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Write("----------Server.MapPath--------------------------------<br/>");
            Response.Write("Server.MapPath(\"~\") : " + Server.MapPath("~") + "<br />");
            //抓取 ASP.NET 網頁程式，所在的目錄
            Response.Write("Server.MapPath(\".\") : " + Server.MapPath(".") + "<br />");
            //取得 asp.net 應用程式在伺服器上虛擬應用程式根路徑
            Response.Write("Request.ApplicationPath : " + Request.ApplicationPath + "<br />");
            //取得目前要求的虛擬路徑
            Response.Write("Request.CurrentExecutionFilePath : " + Request.CurrentExecutionFilePath + "<br />");
            //取得目前要求的虛擬路徑，與 CurrentExecutionFilePath 屬性不同，FilePath 並不會反映伺服器端的傳輸。
            Response.Write("Request.FilePath : " + Request.FilePath + "<br />");
            //取得目前要求的虛擬路徑
            Response.Write("Request.Path : " + Request.Path + "<br />");
            //取得目前執行應用程式之根目錄的實體檔案系統路徑
            Response.Write("Request.PhysicalApplicationPath : " + Request.PhysicalApplicationPath + "<br />");
            //取得與要求的 URL 對應之實體檔案系統路徑
            Response.Write("Request.PhysicalPath : " + Request.PhysicalPath + "<br />");

            //http://msdn2.microsoft.com/zh-tw/library/system.uri(VS.80).aspx            
            Uri uri = Request.Url;
            Response.Write("----------Request.Url--------------------------------<br/>");
            Response.Write("Request.Url.OriginalString ： " + uri.OriginalString + "<br/>");
            Response.Write("Request.Url.AbsoluteUri ： " + uri.AbsoluteUri + "<br/>");
            Response.Write("Request.Url.Scheme ： " + uri.Scheme + "<br/>");
            Response.Write("Request.Url.Host ： " + uri.Host + "<br/>");
            Response.Write("Request.Url.Authority ： " + uri.Authority + "<br/>");
            Response.Write("Request.Url.Port ： " + uri.Port + "<br/>");
            Response.Write("Request.Url.PathAndQuery ： " + uri.PathAndQuery + "<br/>");
            Response.Write("Request.Url.AbsolutePath ： " + uri.AbsolutePath + "<br/>");
            Response.Write("Request.Url.Query ： " + uri.Query + "<br/>");
            Response.Write("Request.QueryString ： " + Request.QueryString.ToString() + "<br/>");
            Response.Write("Request.UserHostAddress ： " + Request.UserHostAddress + "<br/>");
            Response.Write("Request.UserHostName ： " + Request.UserHostName + "<br/>");
        }
    }
}