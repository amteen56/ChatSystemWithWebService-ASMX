using System.Collections.Generic;
using System.Web.Services;

namespace ChatSystermService.asmx
{
    /// <summary>
    /// Summary description for Chat
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Chat : System.Web.Services.WebService
    {

        [WebMethod]
        public void Add(string data)
        {
            Application.Lock();
            var a = (List<string>)Application["ChatData"];
            a.Add(data);
            Application["ChatData"] = a;
            Application.UnLock();
        }
        [WebMethod]
        public List<string> Get()
        {
            return (List<string>)Application["ChatData"];
        }
    }
}
