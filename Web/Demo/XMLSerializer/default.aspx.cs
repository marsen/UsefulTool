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
    protected void Button1_Click(object sender, EventArgs e)
    {
        var XML = @"<ArrayOfSubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>004481@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>2954abc@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>5199coco@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>ASE12760@GMAIL.COM</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>Chieh1025@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>Choutze@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>Doc10451@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>Guuguu185@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>Jane19780517@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>K5611@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>Newman.church@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>Nschen06@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>Vitachloe@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>Vivian29102910@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>YGK@BEST168.COM.TW</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>a0921016016@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>a09281234@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>a0928676787@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>a_long1983@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>aaa11233@Gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>ada1003@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>admset@ccu.edu.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>aj-antihero@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>alex@victorfly.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>alva103@ms14.url.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>amber12162000@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>andy9117@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>ann849@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>annie@adm.cgmh.org.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>ap9629@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>as.0002@m2k.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>asixtw123@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>atayclub1980@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>beartwohome@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>beckycheng2002@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>ben6970@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>bestvm6@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>big3232big3232@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>blanche@cmoney.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>bossawinnie@yahoo.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>c86176507@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>cake20112206@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>cathy1251@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>cctsao1969@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>chang.chungli@msa.hinet.net</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>chen6235@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>chenjo68@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>chenshin0719@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>cherngen0426@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>cherrylin13@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>chiang.puchu@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>chienliangchen@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>chingwen6@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>chiuzuei@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>chjonq@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>chochg@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>christine0229@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>chuan_kuan0206@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>chui0127@kimo.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>chungyangyu@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>circleghost99@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>cityhappy@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>ck54168@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>ckckine747@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>cklai724@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>danceaji55@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>daniel.shishi@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>darcy99@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>dcftfvgy15968@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>dclin1161@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>dofuking@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>dolina1227@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>eager113@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>eddie1205@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>eddie6111@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>emmaemma@life.fubon.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>emsm104@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>eric.office@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>ericy0801@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>escaper0402@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>esp0903@me.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>f104tang@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>fbiwbiepaper@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>fcb1428@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>fe412le55@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>firebirdbird@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>flyfish1092@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>foongoilai@yahoo.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>fr152170@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>frank.w.h.wan@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>frank8889@xuite.net</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>fubon9205@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>g.tinatao@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>g640824@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>glodenrod0508@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>godblessbala@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>gollykuo@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>grace117chen@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>gysm12@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>h550101@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>herecomesit@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>heyoyo@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>hightop1314@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>hiyesbikexpress@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>honorvip@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>hosgon99@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>hsufulong@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>hui3344@pchome.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>hunkchang.tw@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>husn88@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>iamksu228@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>iamwhatiam990909@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>ian.tarn@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>iren.wu@fubon.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>ireneyen.tw@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>irischuang@msi.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>is1023@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>isfun520@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>jackson@cmoney.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>jackson_chung@umc.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>james0204@me.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>jane88668@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>janusky28@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>jawjia@sparqnet.net</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>jaynehsu@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>jen32038@yahoo.com.hk</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>jen766260@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>jenniffer_malos@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>jenrry23@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>jessica020870@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>jjy0727kimo@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>jkiekuo@ms6.hinet.net</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>jlai168@kimo.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>jltsai@emome.net</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>john345678@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>joseph.pjh@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>justin6266@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>jx2015@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>kang20805@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>katyling06@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>kevin00161@gmail.com.</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>kevinkittydaddy8@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>kiki877@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>kikikoko0807@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>kimberyfju7290@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>king11388@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>kingsky750710@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>ky19690105@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>lan3@mail2000.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>lee.elvira@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>leolin_1980@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>leon6098@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>li9603296@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>lililalamomo@msn.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>lin.connie@inventec.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>linolinkimo@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>lintrongchyi@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>lispprologfan@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>liu12082001@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>lmiaol.lin1108@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>lucky27638@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>lv_571888@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>m205ts@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>m7270@mail.cygsh.cy.edu.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>macolyt@yahoo.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>maggie.ko68@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>maggie6709@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>mama5348@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>mandisa520@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>megan26chou@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>mei1619guy@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>mitsukake1@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>mjcheckup@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>monkey0614@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>mrabss@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>n120724@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>nanakokoh@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>nasapoc@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>neowu@msi.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>newman.church@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>newmoneytoo@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>nickywu@mail2000.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>noah@cmoney.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>nobrian2003@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>npic1000@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>oeoeoeooeo@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>ok22205981@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>oliver0935@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>opqbnq@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>ou3768@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>ou3768@pchome.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>p710826@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>panchocsm@gmail.com.</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>patsylung@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>pattyhsu@wealthgrp.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>pc008030@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>pc058061@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>peter_wang@kingston.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>peteryen@fpgcom.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>plumdoor7847@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>pluto0916@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>polo730103@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>quarter762000@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>ra345865@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>rain202taiwan@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>raychang0128@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>regankang8954@gamil.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>rita591116@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>rose66502@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>rossi46888@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>s110921@sinyi.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>s51982@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>s831132@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>safe320@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>samguo@aim.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>send_test111@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>serenawu08@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>shin.da@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>showy0616@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>simon.pu@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>simon@cmoney.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>sinasinaer@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>sindylu168@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>skylark168@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>sony19800504@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>stina_hwn@hotmail.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>t102141144@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>taihaulee@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>tatungliu@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>tc003022@ms34.hinet.net</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>tina890628@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>tntjack168@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>tonychenn@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>tpc263@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>tps_tsai.tw@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>tracy.chen@winmems.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>tracy.jw@msa.hinet.net</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>tracylu880403@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>tsengwenchao@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>tsouwenho@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>tt1.tt3@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>twfno0aoikira8aym@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>tzui.tsai@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>v75235@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>vencen.vencen@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>vincentking.t@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>vitochao168@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>w52022@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>wang535238@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>wanti1@msn.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>wenhsientseng@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>whitefly0902@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>willyu@kimo.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>winchiu1206@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>winstonl22@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>witz3549@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>worthy.wang@me.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>wu.tsungte@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>wuhucy@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>wwp12345@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>x003035@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>x831050@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>xc2020@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>xdmivolkd@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>yafeihsueh@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>yan283389@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>yanikki8811@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>ycliang0104@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>yda1124@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>yen94011@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>yhpan168@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>yichiehlin@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>yiu689@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>yolanda007037@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>yoona46@hotmail.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>ypei.tsai@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>ysl8222@hotmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>yuanyun.hsueh@gmail.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>yychen.jerry@msa.hinet.net</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>z0953196785@gmaul.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Sucess</Message>
<Account>z3278371@yahoo.com.tw</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>zc.huang@innolux.com</Account>
</SubscriptionMessage>
<SubscriptionMessage>
<Message>Not Member</Message>
<Account>zeke1469@gmail.com</Account>
</SubscriptionMessage>
</ArrayOfSubscriptionMessage>";
    }

    private class ArrayOfSubscriptionMessage
    {
         
    }
}