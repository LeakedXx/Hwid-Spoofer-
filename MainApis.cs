using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Net.Security;
using System.Net.Sockets;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Blade_Swapper_V1._3
{
    public class AccountInfo
    {
        public String Username;
        public String FbIDV2;
        public String UserID;
        public String Email;
        public String Phone_Number;
    }
    public class MainApis
    {
        public String RequestPacket(String API, ref HttpStatusCode StatusCode, String StringData = null, String Method = null, String Session = null)
        {
            String Response = String.Empty;
            try
            {
                HttpWebRequest Requests = (HttpWebRequest)WebRequest.Create(API);
                Uri APIuri = new Uri(API);
                Cookie Cookies = new Cookie();
                Cookies.Name = "sessionid";
                Cookies.Value = Session;
                Cookies.Domain = APIuri.Host;

                Int32 Lol = 2147483647;
                Control.CheckForIllegalCrossThreadCalls = false;
                ServicePointManager.DefaultConnectionLimit = Lol;
                ServicePointManager.UseNagleAlgorithm = false;
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.CheckCertificateRevocationList = false;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = ((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);
                ServicePoint servicePoint;
                servicePoint = ServicePointManager.FindServicePoint(APIuri);
                servicePoint.UseNagleAlgorithm = false;
                servicePoint.Expect100Continue = false;
                servicePoint.ConnectionLimit = Int32.MaxValue;
                servicePoint.SetTcpKeepAlive(false, 0, 0);

                CookieContainer CookieContainer = new CookieContainer();
                CookieContainer.Add(Cookies);

                if (Method.Contains("POST-API"))
                {
                    Requests.Method = "Post";
                    Requests.Host = "i.instagram.com";
                    Requests.Accept = "*/*";
                    Requests.UserAgent = $"Instagram {new Random().Next(110, 140)}.0.0.39.122 Android";
                    Requests.Headers.Add("Accept-Language", "en-US");
                    Requests.Headers.Add("IG-U-DS-USER-ID", Randomizer(8));
                    Requests.Headers.Add("Cookie2", "$Version=1");
                    Requests.Headers.Add("X-IG-Connection-Type", "WIFI");
                    Requests.Headers.Add("X-FB-HTTP-Engine", "Liger");
                    Requests.Headers.Add("X-IG-Capabilities", "3brTv10=");
                    Requests.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    Requests.ProtocolVersion = HttpVersion.Version11;
                    Requests.ServicePoint.UseNagleAlgorithm = false;
                    Requests.ServicePoint.Expect100Continue = false;
                    Requests.ServicePoint.ConnectionLimit = int.MaxValue;
                    Requests.CookieContainer = CookieContainer;
                    Requests.KeepAlive = false;
                }
                else if (Method.Contains("GET-API"))
                {
                    Requests.Method = "Get";
                    Requests.Host = "i.instagram.com";
                    Requests.Accept = "*/*";
                    Requests.UserAgent = $"Instagram {new Random().Next(110, 140)}.0.0.39.122 Android";
                    Requests.Headers.Add("Accept-Language", "en-US");
                    Requests.Headers.Add("IG-U-DS-USER-ID", Randomizer(8));
                    Requests.Headers.Add("Cookie2", "$Version=1");
                    Requests.Headers.Add("X-IG-Connection-Type", "WIFI");
                    Requests.Headers.Add("X-FB-HTTP-Engine", "Liger");
                    Requests.Headers.Add("X-IG-Capabilities", "3brTv10=");
                    Requests.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    Requests.ServicePoint.UseNagleAlgorithm = false;
                    Requests.ServicePoint.Expect100Continue = false;
                    Requests.ServicePoint.ConnectionLimit = int.MaxValue;
                    Requests.CookieContainer = CookieContainer;
                    Requests.KeepAlive = false;
                }
                else if (Method.Contains("POST-WEB"))
                {
                    Requests.Method = "Post";
                    Requests.Host = "www.instagram.com";
                    Requests.Accept = "*/*";
                    Requests.UserAgent = "Mozila";
                    Requests.Headers.Add("accept-language", "en-US");
                    Requests.Headers.Add("IG-U-DS-USER-ID", Randomizer(8));
                    Requests.Headers.Add("x-csrftoken", Randomizer(32));
                    Requests.ContentType = "application/x-www-form-urlencoded";
                    Requests.ProtocolVersion = HttpVersion.Version11;
                    Requests.ServicePoint.UseNagleAlgorithm = false;
                    Requests.ServicePoint.Expect100Continue = false;
                    Requests.ServicePoint.ConnectionLimit = int.MaxValue;
                    Requests.CookieContainer = CookieContainer;
                    Requests.KeepAlive = false;
                }
                else if (Method.Contains("GET-WEB"))
                {
                    Requests.Method = "Get";
                    Requests.Host = "www.instagram.com";
                    Requests.Accept = "*/*";
                    Requests.UserAgent = "Mozila";
                    Requests.Headers.Add("accept-language", "en-US");
                    Requests.Headers.Add("IG-U-DS-USER-ID", Randomizer(8));
                    Requests.Headers.Add("x-csrftoken", Randomizer(32));
                    Requests.ContentType = "application/x-www-form-urlencoded";
                    Requests.ProtocolVersion = HttpVersion.Version11;
                    Requests.ServicePoint.UseNagleAlgorithm = false;
                    Requests.ServicePoint.Expect100Continue = false;
                    Requests.ServicePoint.ConnectionLimit = int.MaxValue;
                    Requests.CookieContainer = CookieContainer;
                    Requests.KeepAlive = false;
                }
                if (StringData != null)
                {
                    byte[] Bytes = Encoding.ASCII.GetBytes(StringData.ToString());
                    Requests.ContentLength = (long)Bytes.Length;
                    Stream Stream = Requests.GetRequestStream();
                    Stream.Write(Bytes, 0, Bytes.Length);
                    Stream.Flush();
                    Stream.Close();
                    Stream.Dispose();
                }
                HttpWebResponse HttpResponse;
                try
                {
                    HttpResponse = (HttpWebResponse)Requests.GetResponse();
                }
                catch (WebException ex)
                {
                    HttpResponse = (HttpWebResponse)ex.Response;
                }
                if (HttpResponse != null)
                {
                    StreamReader StreamReader = new StreamReader(HttpResponse.GetResponseStream());
                    StatusCode = HttpResponse.StatusCode;
                    Response = StreamReader.ReadToEnd().ToString();
                    StreamReader.Dispose();
                    StreamReader.Close();
                }
                return Response;
            }
            catch
            {
            }
            return Response;
        }
        public Boolean CheckSession(String Session)
        {
            Dictionary<String, String> Data = new Dictionary<String, String>();
            Data.Add("current_screen_key", "dob");
            Data.Add("day", "1");
            Data.Add("year", "1998");
            Data.Add("month", "1");

            String JSON = ConvertDataToJSON(Data);
            String DataBody = $"SIGNATURE.{JSON}";

            String Url = "https://i.instagram.com/api/v1/consent/update_dob/";
            HttpStatusCode StatusCode = HttpStatusCode.BadRequest;
            String Response = RequestPacket(Url, ref StatusCode, DataBody, "POST-API", Session);
            if (Response.Contains("already_finished") || Response.Contains("\"status\":\"ok\"") && StatusCode == HttpStatusCode.OK) { return true; }
            else { return false; }
        }
        public AccountInfo GetAccountInfo(String Session)
        {

            String GetInfoUrl = "https://i.instagram.com/api/v1/accounts/current_user/?edit=true";
            HttpStatusCode StatusCodeGetInfo = HttpStatusCode.BadRequest;

            String Response = RequestPacket(GetInfoUrl, ref StatusCodeGetInfo, null, "GET-API", Session);
            if (Response.ToLower().Contains("ok") && StatusCodeGetInfo == HttpStatusCode.OK)
            {
                Program.AccountInfo.Username = Regex.Match(Response, "\"username\":\"(.*?)\"").Groups[1].Value;
                Program.AccountInfo.FbIDV2 = Regex.Match(Response, "\"fbid_v2\":(.*?),\"").Groups[1].Value;
                Program.AccountInfo.UserID = Regex.Match(Response, "\"pk\":(.*?),").Groups[1].Value;
                Program.AccountInfo.Email = Regex.Match(Response, "\"email\":\"(.*?)\"").Groups[1].Value;
                Program.AccountInfo.Phone_Number = Regex.Match(Response, "\"phone_number\":\"(.*?)\"").Groups[1].Value;
                return Program.AccountInfo;
            }
            return null;
        }
        public static String ConvertDataToJSON(Dictionary<String, String> Dictionary)
        {
            Int32 i = 0;
            String Json = "{";
            foreach (KeyValuePair<String, String> Entry in Dictionary)
            {
                Json = ((i != Dictionary.Count - 1) ? (Json + "\"" + Entry.Key + "\":\"" + Entry.Value + "\",") : (Json + "\"" + Entry.Key + "\":\"" + Entry.Value + "\""));
                i++;
            }
            return Json + "}";
        }
        public static String Randomizer(Int32 Length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String RealyRandom = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            checked
            {
                Int32 num = Length - 1;
                for (Int32 i = 0; i <= num; i++)
                {
                    stringBuilder.Append(RealyRandom[random.Next(RealyRandom.Length)]);
                }
                return stringBuilder.ToString();
            }
        }



    }
}