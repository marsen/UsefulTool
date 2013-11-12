using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demo_RemotePost_default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        RemotePost rp = new RemotePost();
        rp.Url = "catch-post.aspx";
        rp.Add("DateTime", DateTime.Now.ToString());
        rp.Add("Content", "Hello world");
        rp.Post();
    }
    protected void btnPostWS_Click(object sender, EventArgs e)
    {
        RemotePost rp = new RemotePost();
        rp.Url = "http://dev.cmoney.tw/cm-service/CMoneyService.asmx/GetSubscriptionName";
        rp.Add("memberPk", "7367");        
        rp.Post();
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {

        RemotePost rp = new RemotePost();
        rp.Url = "http://dev.cmoney.tw/cm-service/CMoneyService.asmx/GetSubscriptionName";
        rp.Add("memberPk", "7367");
        rp.Get();
        
    }
}