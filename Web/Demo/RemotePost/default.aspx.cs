using System;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


public partial class Demo_RemotePost_default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        RemotePost rp = new RemotePost();
        rp.Url = "catch-post.aspx";
        rp.Add("DateTime", DateTime.Now.ToString(CultureInfo.InvariantCulture));
        rp.Add("Content", "Hello world");
        rp.Post();
    }
    protected void btnPostWS_Click(object sender, EventArgs e)
    {
        RemotePost rp = new RemotePost();
        rp.Url = "http://dev.cmoney.tw/cm-service/CMoneyService.asmx/GetSubscriptionName";
        rp.Add("memberPk", "7367");
        var s = rp.GetResponsePost();
        TextBox1.Text = s;
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        RemotePost rp = new RemotePost();
        rp.Url = "http://dev.cmoney.tw/UsefulTool/Demo/RemotePost/catch-post.aspx";
        rp.Add("DateTime", DateTime.Now.ToString(CultureInfo.InvariantCulture));
        rp.Add("Content", "Hello world");
        var s = rp.GetResponseGet();
        TextBox1.Text = s;

    }

}