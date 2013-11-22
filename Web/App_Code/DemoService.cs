using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// 測試用webservice
/// </summary>
[WebService(Namespace = "http://marsen.demo/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
// [System.Web.Script.Services.ScriptService]
public class DemoService : System.Web.Services.WebService {

    public DemoService () {

        //如果使用設計的元件，請取消註解下行程式碼 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    #region
    [WebMethod]
    public CandyBox  GetCandyBox()
    {
        var result = new CandyBox();
        result.Sweets.Add(new Candy { Calorie = 100, Name = "棒棒糖" });        
        result.Sweets.Add(new Candy { Calorie = 948, Name = "巧克力" });
        result.Sweets.Add(new Candy { Calorie = 176, Name = "仙渣糖" });
        result.Sweets.Add(new Candy { Calorie = 235, Name = "牛奶糖" });
        return result;
    }

    public class CandyBox
    {
        public List<Candy> Sweets { get; set; }
    }

    public class Candy
    {
        public string Name { get; set; }
        public int Calorie { get; set; }
    }
    #endregion
}
