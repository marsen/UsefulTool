using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            System.Web.HttpContext.Current.Response.Clear();

            System.Web.HttpContext.Current.Response.Write("<html><head>");

            System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));

            System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >",

            FormName, Method, Url));
            for (int i = 0; i < Inputs.Keys.Count; i++)
            {
                System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], HttpUtility.HtmlEncode(Inputs[Inputs.Keys[i]])));
            }
            System.Web.HttpContext.Current.Response.Write("</form>");
            System.Web.HttpContext.Current.Response.Write("</body></html>");
            System.Web.HttpContext.Current.Response.End();
        }
        #endregion
}