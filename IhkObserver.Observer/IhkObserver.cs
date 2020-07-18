using HtmlAgilityPack;
using IhkObserver.Observer.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IhkObserver.Observer
{
    public class IhkObserver
    {
        #region [Fields]
        private Credentials _xmlConfig;
        private CookieContainer _container;

        private string _urlLanding;
        private string _urlLogin;
        private string _urlResults;

        private LoginInformation _loginInfos;
        #endregion

        #region[Properties]
        public string UrlLandingPage
        {
            get { return _urlLanding; }
            set { _urlLanding = value; }
        }

        public string UrlLoginPage
        {
            get { return _urlLogin; }
            set { _urlLogin = value; }
        }

        public string UrlResultPage
        {
            get { return _urlResults; }
            set { _urlResults = value; }
        }

        public Credentials XmlConfig
        {
            get { return _xmlConfig; }
            set { _xmlConfig = value; }
        }
        #endregion

        #region[Constructor]
        public IhkObserver()
        {
            _container = new CookieContainer();

        }

        public IhkObserver(string urlLandingPage, string urlLoginPage, string urlResultPage, Credentials credentials)
        {
            _urlLanding = urlLandingPage;
            _urlLogin = urlLoginPage;
            _urlResults = urlResultPage;
            _xmlConfig = credentials;

            _container = new CookieContainer();
        }
        #endregion

        #region [Private Methods]
        /// <summary>
        /// Necessary for inital Loading because
        /// the session starts at the Welcome Page.
        /// <see cref="https://ausbildung.ihk.de/pruefungsinfos/Peo/Willkommen.aspx?knr=155"/>
        /// </summary>
        private void AddSessionId()
        {
            var request = GenerateHttpWebRequest("GET", UrlLandingPage);
            var response = request.GetResponse() as HttpWebResponse;

            var status = response.StatusCode.ToString();
            response.Close();
        }

        /// <summary>
        /// Necessary for inital Loading because
        /// the session starts at the Welcome Page.
        /// <see cref="https://ausbildung.ihk.de/pruefungsinfos/Peo/Willkommen.aspx?knr=155"/>
        /// </summary>
        private async Task AddSessionIdAsync()
        {
            var request = GenerateHttpWebRequest("GET", UrlLandingPage);
            var response = await request.GetResponseAsync() as HttpWebResponse;
            response.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool GetLoginInformations()
        {
            bool result = false;

            try
            {
                var request = GenerateHttpWebRequest("GET", UrlLoginPage);

                var response = request.GetResponse();

                using (var webPageStream = response.GetResponseStream())
                {
                    var doc = new HtmlDocument();
                    doc.Load(webPageStream);

                    _loginInfos = new LoginInformation();

                    var nodeCaptchaUrl = doc.DocumentNode.SelectSingleNode("//img[@id='ctl00_ContentPlaceHolder1_mRadCaptcha_CaptchaImageUP']");
                    _loginInfos.CaptchaUrl = "https://" + nodeCaptchaUrl.Attributes["src"].Value.Replace("../..", "ausbildung.ihk.de").Replace("&amp;", "&");

                    var nodeViewState = doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']");
                    _loginInfos.ViewState = nodeViewState.GetAttributeValue("value", "?");

                    var nodeViewStateGenerator = doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATEGENERATOR']");
                    _loginInfos.ViewStateGenerator = nodeViewStateGenerator.GetAttributeValue("value", "?");
                }

                if (string.IsNullOrWhiteSpace(_loginInfos.CaptchaUrl))
                {
                    result = true;
                }
            }
            catch (System.Exception)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<bool> GetLoginInformationsAsync()
        {
            bool result = false;

            try
            {
                var request = GenerateHttpWebRequest("GET", UrlLoginPage);

                var response = await request.GetResponseAsync();

                using (var webPageStream = response.GetResponseStream())
                {
                    var doc = new HtmlDocument();
                    doc.Load(webPageStream);

                    _loginInfos = new LoginInformation();

                    var nodeCaptchaUrl = doc.DocumentNode.SelectSingleNode("//img[@id='ctl00_ContentPlaceHolder1_mRadCaptcha_CaptchaImageUP']");
                    _loginInfos.CaptchaUrl = "https://" + nodeCaptchaUrl.Attributes["src"].Value.Replace("../..", "ausbildung.ihk.de").Replace("&amp;", "&");

                    var nodeViewState = doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']");
                    _loginInfos.ViewState = nodeViewState.GetAttributeValue("value", "?");

                    var nodeViewStateGenerator = doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATEGENERATOR']");
                    _loginInfos.ViewStateGenerator = nodeViewStateGenerator.GetAttributeValue("value", "?");
                }

                if (string.IsNullOrWhiteSpace(_loginInfos.CaptchaUrl))
                {
                    result = true;
                }
            }
            catch (System.Exception)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private HttpWebRequest GenerateHttpWebRequest(string type, string url)
        {

            StringBuilder accept = new StringBuilder();
            accept.Append("text/html,");
            accept.Append("application / xhtml + xml,");
            accept.Append("application / xml; q = 0.9,");
            accept.Append("image / webp,image / apng,");
            accept.Append("*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");

            StringBuilder userAgent = new StringBuilder();
            userAgent.Append("Mozilla/5.0 (Windows NT 10.0; Win64; x64) ");
            userAgent.Append("AppleWebKit/537.36 (KHTML, like Gecko) ");
            userAgent.Append("Chrome/83.0.4103.116 ");
            userAgent.Append("Safari/537.36");


            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;

            request.Method = type;
            request.Accept = accept.ToString();
            request.Host = "ausbildung.ihk.de";
            request.UserAgent = userAgent.ToString();
            request.CookieContainer = _container;

            return request;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private HttpWebRequest GenerateHttpWebRequestPOST()
        {
            HttpWebRequest request = GenerateHttpWebRequest("POST", _urlLogin);

            request.ContentType = "application/x-www-form-urlencoded";
            request.Referer = "https://ausbildung.ihk.de/pruefungsinfos/peo/Login.aspx";
            request.KeepAlive = true;
            request.Headers.Add("accept-language", "de,en-US;q=0.9,en;q=0.8,tr;q=0.7");
            request.Headers.Add("cache-control", "no-cache");
            request.Headers.Add("pragma", "no-cache");
            request.Headers.Add("sec-fetch-dest", "document");
            request.Headers.Add("sec-fetch-mode", "navigate");
            request.Headers.Add("sec-fetch-site", "same-origin");
            request.Headers.Add("sec-fetch-user", "?1");
            request.Headers.Add("upgrade-insecure-request", "1");

            return request;
        }
        #endregion

        #region [Public Methods]
        public bool GetExamInformation(out List<SubjectMarks> results)
        {
            bool result = false;
            try
            {
                var request = GenerateHttpWebRequest("GET", UrlResultPage);

                var response = request.GetResponse();

                using (var webpageStream = response.GetResponseStream())
                {
                    var doc = new HtmlDocument();
                    doc.Load(webpageStream);

                    var div = doc.DocumentNode.SelectNodes("//div[@class='contentBox']")[2];
                    var body = div.Descendants().Where(d => d.Name == "tbody").First();

                    List<SubjectMarks> list = new List<SubjectMarks>();
                    SubjectMarks mark;
                    foreach (var row in body.Descendants().Where(d => d.Name == "tr"))
                    {
                        mark = new SubjectMarks();

                        mark.Subject = ($"{row.ChildNodes[0].InnerText.Replace(" &nbsp;", "")}");
                        mark.Mark = int.Parse(row.ChildNodes[1].InnerText);
                        mark.Points = int.Parse(row.ChildNodes[2].InnerText);

                        list.Add(mark);
                    }

                    results = list;
                    result = true;
                }
                response.Close();
            }
            catch
            {
                results = null;
                result = false;
                throw;
            }

            return result;
        }

        public async Task<List<SubjectMarks>> GetExamInformationAsync()
        {
            try
            {
                List<SubjectMarks> results = new List<SubjectMarks>();

                var request = GenerateHttpWebRequest("GET", UrlResultPage);

                var response = await request.GetResponseAsync();

                using (var webpageStream = response.GetResponseStream())
                {
                    var doc = new HtmlDocument();
                    doc.Load(webpageStream);

                    var div = doc.DocumentNode.SelectNodes("//div[@class='contentBox']")[2];
                    var body = div.Descendants().Where(d => d.Name == "tbody").First();

                    List<SubjectMarks> list = new List<SubjectMarks>();
                    SubjectMarks mark;
                    foreach (var row in body.Descendants().Where(d => d.Name == "tr"))
                    {
                        mark = new SubjectMarks();

                        mark.Subject = ($"{row.ChildNodes[0].InnerText.Replace(" &nbsp;", "")}");
                        mark.Mark = int.Parse(row.ChildNodes[1].InnerText);
                        mark.Points = int.Parse(row.ChildNodes[2].InnerText);

                        list.Add(mark);
                    }

                    results = list;

                }
                response.Close();

                return results;
            }
            catch
            {
                return new List<SubjectMarks>();
                throw;
            }


        }


        public Bitmap GetLoginCaptcha()
        {
            AddSessionId();
            GetLoginInformations();

            var request = GenerateHttpWebRequest("GET", _loginInfos.CaptchaUrl);

            var response = request.GetResponse();

            using (var reader = new BinaryReader(response.GetResponseStream()))
            {
                Byte[] lnByte = reader.ReadBytes(1 * 1024 * 1024 * 10);

                using (MemoryStream mStream = new MemoryStream(lnByte))
                {
                    Bitmap bm = new Bitmap(mStream);
                    return bm;
                }

            }
        }

        public async Task<Bitmap> GetLoginCaptchaAsync()
        {
            await AddSessionIdAsync().ConfigureAwait(false);
            await GetLoginInformationsAsync().ConfigureAwait(false);

            var request = GenerateHttpWebRequest("GET", _loginInfos.CaptchaUrl);

            var response = await request.GetResponseAsync();

            using (var reader = new BinaryReader(response.GetResponseStream()))
            {
                Byte[] lnByte = reader.ReadBytes(1 * 1024 * 1024 * 10);

                using (MemoryStream mStream = new MemoryStream(lnByte))
                {
                    Bitmap bm = new Bitmap(mStream);
                    return bm;
                }
            }
        }


        public bool Login(string captcha)
        {
            var request = GenerateHttpWebRequestPOST();

            string postData =
$"ctl00_ctl04_TSM=;;System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35:en-US:92dc34f5-462f-43bd-99ec-66234f705cd1:ea597d4b:b25378d2;Telerik.Web.UI, Version=2018.3.910.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4:en-US:df8a796a-503f-421d-9d40-9475fc76f21f:16e4e7cd:11e117d7" +
$"&__EVENTTARGET=ctl00$ContentPlaceHolder1$mlbSubmit" +
$"&__EVENTARGUMENT=" +
$"&__VIEWSTATE={HttpUtility.UrlEncode(_loginInfos.ViewState)}" +
$"&__VIEWSTATEGENERATOR={HttpUtility.UrlEncode(_loginInfos.ViewStateGenerator)}" +
$"&ctl00$ContentPlaceHolder1$txtAzubiNr={_xmlConfig.IdentNr}" +
$"&ctl00$ContentPlaceHolder1$txtPrueflingsNr={_xmlConfig.PrueflingsNr}" +
$"&ctl00$ContentPlaceHolder1$mRadCaptcha$CaptchaTextBox={captcha}" +
$"&ctl00_ContentPlaceHolder1_mRadCaptcha_ClientState=";
            var data = Encoding.ASCII.GetBytes(postData);

            request.ContentLength = data.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.Found && response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Fehler bei Captcha Eingabe, versuch es erneut!");
                response.Close();
                return false;
            }
            if (response.ResponseUri.AbsolutePath.Contains("Login.aspx"))
            {
                Console.WriteLine("Captcha ist falsch, versuch es nochmal.");
                response.Close();
                return false;
            }

            response.Close();
            return true;
        }

        public async Task<bool> LoginAsync(string captcha)
        {



            var request = GenerateHttpWebRequestPOST();

            string postData =
$"ctl00_ctl04_TSM=;;System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35:en-US:92dc34f5-462f-43bd-99ec-66234f705cd1:ea597d4b:b25378d2;Telerik.Web.UI, Version=2018.3.910.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4:en-US:df8a796a-503f-421d-9d40-9475fc76f21f:16e4e7cd:11e117d7" +
$"&__EVENTTARGET=ctl00$ContentPlaceHolder1$mlbSubmit" +
$"&__EVENTARGUMENT=" +
$"&__VIEWSTATE={HttpUtility.UrlEncode(_loginInfos.ViewState)}" +
$"&__VIEWSTATEGENERATOR={HttpUtility.UrlEncode(_loginInfos.ViewStateGenerator)}" +
$"&ctl00$ContentPlaceHolder1$txtAzubiNr={_xmlConfig.IdentNr}" +
$"&ctl00$ContentPlaceHolder1$txtPrueflingsNr={_xmlConfig.PrueflingsNr}" +
$"&ctl00$ContentPlaceHolder1$mRadCaptcha$CaptchaTextBox={captcha}" +
$"&ctl00_ContentPlaceHolder1_mRadCaptcha_ClientState=";
            var data = Encoding.ASCII.GetBytes(postData);

            request.ContentLength = data.Length;

            Stream requestStream = await request.GetRequestStreamAsync();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            var response = await (Task<WebResponse>)request.GetResponseAsync() as HttpWebResponse;

            if (response.StatusCode != HttpStatusCode.Found && response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Fehler bei Captcha Eingabe, versuch es erneut!");
                response.Close();
                return false;
            }
            if (response.ResponseUri.AbsolutePath.Contains("Login.aspx"))
            {
                Console.WriteLine("Captcha ist falsch, versuch es nochmal.");
                response.Close();
                return false;
            }

            response.Close();
            return true;
        }
        #endregion
    }
}
