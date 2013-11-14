using System;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Serialization;

public partial class Demo_XMLSerializer_default : System.Web.UI.Page
{
    private const string XML_SAMPLE = 
@"<SubscritionList xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://tempuri.org/'>
    <Items>
    <SubscritionDisplayName>
    <Id>12348</Id>
    <Name>馬克</Name>
    </SubscritionDisplayName>
    <SubscritionDisplayName>
    <Id>22814</Id>
    <Name>yooo</Name>
    </SubscritionDisplayName>
    <SubscritionDisplayName>
    <Id>30480</Id>
    <Name>迪克</Name>
    </SubscritionDisplayName>
    </Items>
    </SubscritionList>";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPost2_Click(object sender, EventArgs e)
    {

    }

    public T XMLToObject<T>(string strxml)
    {
        XmlDocument xdoc = new XmlDocument();
        xdoc.LoadXml(strxml);
        XmlNodeReader reader = new XmlNodeReader(xdoc);
        XmlSerializer ser = new XmlSerializer(typeof(T));
        object obj = ser.Deserialize(reader);
        return (T)obj;
    }
    [XmlRoot("SubscritionList", Namespace = "http://tempuri.org/")]
    public class SubscritionList
    {
        public SubscritionList() { Items = new List<SubscritionDisplayName>(); }
        [XmlArray("Items")]
        [XmlArrayItem("Items")]
        public List<SubscritionDisplayName> Items { get; set; }
    }

    public class SubscritionDisplayName
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    protected void btnXMLToObj_Click(object sender, EventArgs e)
    {
        #region　sometimes call the webservice
        //RemotePost rp = new RemotePost();
        //rp.Url = "http://dev.cmoney.tw/cm-service/CMoneyService.asmx/GetSubscriptionName";
        //rp.Add("memberPk", "7367");
        //var s = rp.GetResponsePost();
        #endregion

        try
        {
            var k = XMLToObject<SubscritionList>(XML_SAMPLE);
            Label1.Text = "OK";
        }
        catch (Exception)
        {
            Label1.Text = "Error";
        }

    }
}