using System;

public partial class Demo_RemotePost_catch_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string dateTime = Request.Params["DateTime"];
        string content = Request.Params["Content"];
        if (!String.IsNullOrEmpty(dateTime)&&!String.IsNullOrEmpty(content))
        {
            Response.Write(String.Format("I catch the post 「{0}」from you at {1}", content, dateTime));
        }
    }
}