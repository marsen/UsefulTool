using System;
using System.IO;
using System.Text;
using System.Web;
using System.Net;

/// <summary>
/// RemotePost 的摘要描述
/// </summary>
public class RemotePost
{
        #region　參數
            private System.Collections.Specialized.NameValueCollection Inputs
            = new System.Collections.Specialized.NameValueCollection();
            /// <summary>
            /// 目的網址URL
            /// </summary>
            public string Url = "";
            /// <summary>
            /// HTTP Method , 預設為post
            /// </summary>
            public string Method = "post";
            /// <summary>
            /// 指定表單名稱(form name)
            /// </summary>
            public string FormName = "form1";
        #endregion
        #region　方法
        /// <summary>
        /// 加入參數
        /// </summary>
        /// <param name="name">參數名</param>
        /// <param name="value">參數值</param>
        public void Add(string name, string value)
        {
            Inputs.Add(name, value);
        }
        /// <summary>
        /// POST REQUEST
        /// </summary>
        public void Post()
        {
            HttpContext.Current.Response.Clear();

            HttpContext.Current.Response.Write("<html><head>");

           HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));

           HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >",
            FormName, Method, Url));
            for (int i = 0; i < Inputs.Keys.Count; i++)
            {
                HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], HttpUtility.HtmlEncode(Inputs[Inputs.Keys[i]])));
            }
            HttpContext.Current.Response.Write("</form>");
            HttpContext.Current.Response.Write("</body></html>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 取得Response
        /// </summary>
        /// <returns></returns>
        public string GetResponseGet()
        {
            //網頁內容
            string result ;
            
            var server = HttpContext.Current.Server;
            var sb = new StringBuilder();
            for (int i = 0; i < Inputs.Keys.Count; i++)
            {
                if (sb.Length > 0) { sb.Append("&"); }
                sb.AppendFormat("{0}={1}",
                    server.UrlEncode(Inputs.Keys[i]),
                    server.UrlEncode(Inputs[Inputs.Keys[i]]));
            }
            string GetUrl;
            if (Inputs.Keys.Count > 0)
            {
                GetUrl = String.Format("{0}?{1}",Url,sb);
            }
            else
            {
                GetUrl = String.Format("{0}",Url);
            }
            
            try
            {
                var hwr =
                    (HttpWebRequest)WebRequest.Create(GetUrl);
                
                WebResponse wr = hwr.GetResponse();

                var myStreamReader =
                    new StreamReader(wr.GetResponseStream(), Encoding.UTF8);

                result = myStreamReader.ReadToEnd();

            }
            catch (Exception ex)
            {
                result = "GET ERROR";
            }
            return result;
        }

        public string GetResponsePost()
        {
            var httpWReq =
            (HttpWebRequest)WebRequest.Create(Url);

            var encoding = new ASCIIEncoding();

            var server = HttpContext.Current.Server;
            var sb = new StringBuilder();
            for (int i = 0; i < Inputs.Keys.Count; i++)
            {
                if (sb.Length > 0) { sb.Append("&"); }
                sb.AppendFormat("{0}={1}",
                    server.UrlEncode(Inputs.Keys[i]),
                    server.UrlEncode(Inputs[Inputs.Keys[i]]));
            }

            byte[] data = encoding.GetBytes(sb.ToString());

            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/x-www-form-urlencoded";
            httpWReq.ContentLength = data.Length;

            using (Stream stream = httpWReq.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)httpWReq.GetResponse();

            var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return result;
        }

    #endregion
}