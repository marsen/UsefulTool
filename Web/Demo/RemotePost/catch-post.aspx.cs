using System;

public partial class Demo_RemotePost_catch_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form.Count > 0 )
        {
            string dateTime = Request.Form["DateTime"];
            string content = Request.Form["Content"];
            if (!String.IsNullOrEmpty(dateTime) && !String.IsNullOrEmpty(content))
            {
                Response.Write(String.Format("I catch the post 「{0}」from you at {1}", content, dateTime));

            }
        }
        if (Request.QueryString.Count > 0)
        {
            string dateTime = Request.QueryString["DateTime"];
            string content = Request.QueryString["Content"];
            if (!String.IsNullOrEmpty(dateTime) && !String.IsNullOrEmpty(content))
            {
                Response.Write(String.Format("I catch the get 「{0}」from you at {1}", content, dateTime));

            }
        }

        Response.End();
    }
}