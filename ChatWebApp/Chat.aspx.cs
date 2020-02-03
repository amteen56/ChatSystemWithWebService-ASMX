using System;
using System.IO;
using System.Net;
using System.Xml;

namespace ChatWebApp
{
    public partial class Chat : System.Web.UI.Page
    {
        public HttpWebRequest CreateSOAPWebRequest1()
        {
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"http://localhost:59612/Chat.asmx");
            Req.Headers.Add(@"SOAPAction:http://tempuri.org/Add");
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            Req.Method = "POST";
            return Req;
        }
        public static HttpWebRequest CreateSOAPWebRequest2()
        {
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"http://localhost:59612/Chat.asmx");
            Req.Headers.Add(@"SOAPAction:http://tempuri.org/Get");
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            Req.Method = "POST";
            return Req;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            tm_Tick();
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(15);

            var timer = new System.Threading.Timer((ee) =>
            {
                tm_Tick();
            }, null, startTimeSpan, periodTimeSpan);
        }

        void tm_Tick()
        {
            HttpWebRequest request = CreateSOAPWebRequest2();

            XmlDocument SOAPReqBody = new XmlDocument();
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi = ""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd = ""http://www.w3.org/2001/XMLSchema"" xmlns:soap = ""http://schemas.xmlsoap.org/soap/envelope/"" >
  <soap:Body>
    <Get xmlns = ""http://tempuri.org/""/>
  </soap:Body>
</soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    XmlDocument xdoc = new XmlDocument();
                    var aa = rd.ReadToEnd();
                    xdoc.LoadXml(aa);
                    XmlNodeList lst = xdoc.GetElementsByTagName("string");
                    foreach (XmlNode item in lst)
                    {
                        var st = item.InnerText.Split(',');
                        maindatadiv.InnerHtml += "<b>Name: </b>" + st[0]+ "&emsp;" + "<b>Message: </b>" + st[1] + "&emsp;" +st[2]+"<br />";
                    }

                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string data = "";
            data = TextBox1.Text+","+TextBox2.Text+","+DateTime.Now.ToLocalTime();
            maindatadiv.InnerText = data;
                HttpWebRequest request = CreateSOAPWebRequest1();
            
            XmlDocument SOAPReqBody = new XmlDocument();
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi = ""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd = ""http://www.w3.org/2001/XMLSchema"" xmlns:soap = ""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <Add xmlns = ""http://tempuri.org/"">
      <data> " + data + @" </data>
    </Add>
  </soap:Body>
</soap:Envelope>");


            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    var ServiceResult = rd.ReadToEnd();
                }
            }
        }
    }
}