using System;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Serialization;

public partial class Demo_XMLSerializer_default : System.Web.UI.Page
{
    private const string XML_SAMPLE1 = 
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
    private const string XML_SAMPLE2 =   @"<boolean>true</boolean>";
    private const string XML_SAMPLE3 =
@"<CandyBox xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://tempuri.org/'>
	<Items>
		<Candy>
			<Id>1</Id>
			<Name>牛奶糖</Name>
		</Candy>
		<Candy>
			<Id>11</Id>
			<Name>棒棒糖</Name>
		</Candy>
		<Candy>
			<Id>21</Id>
			<Name>牛軋糖</Name>
		</Candy>
		<Candy>
			<Id>46</Id>
			<Name>泡泡糖</Name>
		</Candy>
	</Items>
</CandyBox>";
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
        [XmlElement("Id")]
        public long Id { get; set; }
        [XmlElement("Name")]
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
            var k = XMLToObject<SubscritionList>(XML_SAMPLE1);
            Label1.Text = "OK";
        }
        catch (Exception ex)
        {
            Label1.Text = String.Format("Error:{0}",ex.Message);
        }

    }
    protected void btnXMLToObj2_Click(object sender, EventArgs e)
    {

        try
        {
            var k = XMLToObject<SubscritionList>(XML_SAMPLE2);
            Label1.Text = "OK";
        }
        catch (Exception ex)
        {
            Label1.Text = String.Format("Error:{0}", ex.Message);
        }
    }
}