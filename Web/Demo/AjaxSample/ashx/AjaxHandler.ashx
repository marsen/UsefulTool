<%@ WebHandler Language="C#" Class="AjaxHandler" %>

using System;
using System.Web;

public class AjaxHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}