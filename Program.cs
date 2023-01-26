using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using static Blade_Swapper_V1._3.MainApis;
using System.Diagnostics;
using System.Windows.Forms;

namespace Blade_Swapper_V1._3
{
    public class Program
    {
        class TurboInfo
        {
            public static String FormMessage, ConsoleTitle, WebHook, Biography;
        }
        public static List<String> RandomDiscordPec = new List<String>(new String[] { "https://c.tenor.com/rw4hnyKNq7EAAAAd/samurai-katana.gif", "https://c.tenor.com/TMKp9mFDm7sAAAAC/sword-sword-of-the-stranger.gif", "https://c.tenor.com/D_mg2RRI1VwAAAAd/anime-sword.gif", "https://c.tenor.com/Y1DDQyB1q48AAAAC/ao-no-exorcist-rin-okumura.gif", "https://c.tenor.com/XswNpbEYx0EAAAAC/zoro-lick.gif", "https://c.tenor.com/H_TTBUrOmW4AAAAC/feitan-sword.gif", "https://c.tenor.com/iAFluiuPLK0AAAAC/samurai-ronin.gif", "https://c.tenor.com/U2b2D2hU0lwAAAAC/sword-anime-sword.gif", "https://c.tenor.com/UInMbNyY65MAAAAC/anime-sword.gif", "https://c.tenor.com/f53oQizBoX0AAAAC/akame-akame-ga-k-ill.gif", "https://c.tenor.com/ImzK5FFT4VYAAAAC/rem-anime.gif", "https://c.tenor.com/FapxLQNDNxwAAAAC/anime-wind.gif", "https://c.tenor.com/X0MRKE1Uuz4AAAAC/anime-sword.gif", "https://c.tenor.com/WPMfUmW7qNgAAAAC/kaneki-ken-tokyo-ghoul.gif", "https://c.tenor.com/Nq_YQ6XmuvYAAAAC/kaneki-ken-tokyo-ghoul.gif", "https://c.tenor.com/rSNBolWKQlEAAAAd/kaneki-centipede.gif", "https://c.tenor.com/GDqH1MyfsGIAAAAC/kaneki-ken-crying.gif" });
        public static Int32 ATT = 0, RL = 0, RPS = 0, InputThreads = 0, RequestSent = 0, BadSession = 0, Catche = 0, ProxyLine = 0, SessionsLine = 0, PortProxy = 0;
        public static String InputTarget, Settings, SessionID, ChoiceModeLogin, ChoiceProxies, IpProxy, UserProxy, PasswordProxy;
        public static EventWaitHandle WaitClaimed = new EventWaitHandle(false, EventResetMode.ManualReset);
        public static List<String> ProxyList, SessionList = new List<String>();
        public static AccountInfo AccountInfo = new AccountInfo();
        public static MainApis MainApi = new MainApis();
        public static Boolean StoppedClaimer = false;
        public static Object thisLock = new Object();
        public static Random Random = new Random();

        public static string Banner =@"
██████  ██       █████  ██████  ███████ 
██   ██ ██      ██   ██ ██   ██ ██      
██████  ██      ███████ ██   ██ █████   
██   ██ ██      ██   ██ ██   ██ ██      
██████  ███████ ██   ██ ██████  ███████

VERSION v1.3
";
        public static void Main()
        {
            //Task.Run(() => { Init(); });
            Console.Title = "Blade Swapper v1.3";
            Console.SetWindowSize(120, 35);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Banner);
            Program.Input("Blade v1.3", "Welcome to blade swapper", ConsoleColor.DarkYellow, ConsoleColor.White); Console.WriteLine(); ;
            Program.ReadLists(@"Settings.txt");
            Program.ReadLists(@"Proxies.txt");
            Program.ReadLists(@"Sessions.txt");

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Banner);

        ReturnProxiesMode:
            Program.Input("Info", "[1] : Http\\s [IP:Port]", ConsoleColor.Magenta, ConsoleColor.White); Console.WriteLine();
            Program.Input("Info", "[2] : Http\\s [IP:Port:User:Pass]", ConsoleColor.Magenta, ConsoleColor.White); Console.WriteLine();
            Program.Input("Info", "[3] : Nothing", ConsoleColor.Magenta, ConsoleColor.White); Console.WriteLine();
            Program.Input("Proxies", "Enter Proxies Mode : ", ConsoleColor.DarkYellow, ConsoleColor.White);
            Program.ChoiceProxies = Console.ReadLine();
            if (Program.ChoiceProxies.Contains("1") || Program.ChoiceProxies.Contains("2") || Program.ChoiceProxies.Contains("3")) { }
            else
            {
                Program.Input("Blade v1.3", "Choice Proxies Mode !!!", ConsoleColor.Red, ConsoleColor.White); Console.WriteLine();
                Program.Input("Blade v1.3", "Press enter to try again...", ConsoleColor.DarkYellow, ConsoleColor.White); string ReturnProxiesMode = Console.ReadLine();
                goto ReturnProxiesMode;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Banner);

        ReturnHiddenMode:
            Program.Input("Info", "[1] : Print Proxies Info On The Counter", ConsoleColor.Magenta, ConsoleColor.White); Console.WriteLine();
            Program.Input("Info", "[2] : Hidden Proxies Info On The Counter", ConsoleColor.Magenta, ConsoleColor.White); Console.WriteLine();
            Program.Input("Proxies", "Enter Mode : ", ConsoleColor.DarkYellow, ConsoleColor.White);
            string HiddenProxiesInfo = Console.ReadLine();

            if (HiddenProxiesInfo.Contains("1") || HiddenProxiesInfo.Contains("2")) { }
            else
            {
                Program.Input("Blade v1.3", "Choice Hidden Mode !!!", ConsoleColor.Red, ConsoleColor.White); Console.WriteLine();
                Program.Input("Blade v1.3", "Press enter to try again...", ConsoleColor.DarkYellow, ConsoleColor.White); string ReturnHiddenMode = Console.ReadLine();
                goto ReturnHiddenMode;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Banner);

        ReturnLoginMode:
            Program.Input("Info", "[1] : Multi Session | [2] : Put SessionID", ConsoleColor.Magenta, ConsoleColor.White); Console.WriteLine();
            Program.Input("Login Insta", "Enter Login Mode : ", ConsoleColor.DarkYellow, ConsoleColor.White);
            Program.ChoiceModeLogin = Console.ReadLine();
            if (Program.ChoiceModeLogin.Contains("1")) { }
            else if (Program.ChoiceModeLogin.Contains("2"))
            {
            ReturnPutSession:
                Program.Input("Blade v1.3", "Enter Session : ", ConsoleColor.DarkYellow, ConsoleColor.White);
                Program.SessionID = Console.ReadLine();
                if (MainApi.CheckSession(Program.SessionID))
                {
                    Program.Input("CheckSession", "Valid SessionID : ", ConsoleColor.Green, ConsoleColor.White);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Program.SessionID); Console.WriteLine();
                    MainApi.GetAccountInfo(Program.SessionID);
                    Program.PrintAccountInfo();
                }
                else
                {
                    Program.Input("CheckSession", "Not Valid SessionID : ", ConsoleColor.Red, ConsoleColor.White);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Program.SessionID);
                    Program.Input("Blade v1.3", "Press enter to try again...", ConsoleColor.DarkYellow, ConsoleColor.White); string ReturnPutSession = Console.ReadLine();
                    goto ReturnPutSession;

                }
            }
            else
            {
                Program.Input("Blade v1.3", "Choice Login Mode !!!", ConsoleColor.Red, ConsoleColor.White); Console.WriteLine();
                Program.Input("Blade v1.3", "Press enter to try again...", ConsoleColor.DarkYellow, ConsoleColor.White); string ReturnLoginMode = Console.ReadLine();
                goto ReturnLoginMode;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Banner);

            Program.Input("Blade v1.3", "Enter Target : ", ConsoleColor.DarkYellow, ConsoleColor.White); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("@"); Program.InputTarget = Console.ReadLine();

            Program.Input("Info", "[Maximum=150, Minimum=20] : Threads", ConsoleColor.Magenta, ConsoleColor.White); Console.WriteLine();
            Program.Input("Blade v1.3", "Enter Threads : ", ConsoleColor.DarkYellow, ConsoleColor.White); Program.InputThreads = int.Parse(Console.ReadLine()); Console.WriteLine();

            Program.Input("Blade v1.3", "Press Enter When U Ready...", ConsoleColor.DarkYellow, ConsoleColor.White); string Started = Console.ReadLine(); Console.WriteLine();

            if (Program.ChoiceModeLogin.Contains("1"))
            {
                Program.LoopMulti(Program.InputTarget, TurboInfo.Biography);
            }
            else
            {
                Program.LoopSingle(Program.InputTarget, Program.SessionID, AccountInfo.FbIDV2, AccountInfo.UserID, AccountInfo.Email, AccountInfo.Phone_Number, TurboInfo.Biography);
            }

            Task.Run(() => { GetRPS(); });

            Task.Run(() => { PrintCounter(HiddenProxiesInfo); });
        }
        public static void Input(String LineOne, String LineTwoo, ConsoleColor ColorOne, ConsoleColor ColorTwoo)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("<");
            Console.ForegroundColor = ColorOne;
            Console.Write(LineOne);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("> ");
            Console.ForegroundColor = ColorTwoo;
            Console.Write(LineTwoo);
            Console.ForegroundColor = ColorOne;
        }
        public static void GetRPS()
        {
            while (!Program.StoppedClaimer)
            {
                Int32 SecAttempts = Program.ATT;
                Thread.Sleep(1000);
                Program.RPS = Program.ATT - SecAttempts;
                GC.Collect();
            }
        }
        public static void LoopSingle(String Target, String Session, String FbIDv2, String UserID, String Email, String PhoneNumber, String Bio)
        {
            for (Int32 i = 0; i <= Convert.ToInt32(Program.InputThreads); i++)
            {

                Thread EditAPIThread = new Thread(new ThreadStart(() =>
                {
                    while (!Program.StoppedClaimer)
                    {
                        Dictionary<String, String> StringData = new Dictionary<String, String>();
                        StringData.Add("primary_profile_link_type", "0");
                        StringData.Add("phone_number", PhoneNumber);
                        StringData.Add("username", Target);
                        StringData.Add("show_fb_link_on_profile", "false");
                        StringData.Add("_uid", UserID);
                        StringData.Add("device_id", "android-3e1f1446b9898a45");
                        StringData.Add("biography", Bio);
                        StringData.Add("_uuid", "84990e73-e663-44c1-a008-064d1f1d0f9f");
                        StringData.Add("email", Email);

                        String JSON = ConvertDataToJSON(StringData);
                        String DataBody = $"signed_body=SIGNATURE.{JSON}";

                        String UrlAPI = "https://i.instagram.com/api/v1/accounts/edit_profile/";
                        HttpStatusCode StatusCode = new HttpStatusCode();
                        String Response = RequestPacket(UrlAPI, ref StatusCode, DataBody, "EditAPI", Session);
                        if (Response.Contains(Target) || Response.Contains("\"status\":\"ok\""))
                        {
                            lock (Program.thisLock)
                            {
                                if (!Program.StoppedClaimer)
                                {
                                    Program.StoppedClaimer = true;
                                    WaitClaimed.Set();
                                    Program.DoneClaimed(Target, Session, Email);
                                }
                            }
                        }
                        else if (Response.Contains("This username isn't available") || Response.Contains("isn't") || Response.Contains("Something is wrong") || Response.Contains("\"message\":\"Try Again Later\",") || Response.Contains("Please try again later.") || StatusCode == HttpStatusCode.BadRequest)
                        {
                            Interlocked.Increment(ref ATT);
                            continue;
                        }
                        else if (Response.Contains("wait") || Response.Contains("generic") || Response.Contains("rate_limit_error") || StatusCode.ToString() == "429")
                        {
                            Interlocked.Increment(ref RL);
                            continue;
                        }
                        else if (Response.Contains("challenge_required") || Response.Contains("consent_required") || Response.Contains("login_required") || StatusCode == HttpStatusCode.Forbidden)
                        {
                            Interlocked.Increment(ref BadSession);
                            continue;
                        }
                        Thread.Sleep(new Random().Next(10, 25));
                    }

                }));
                EditAPIThread.IsBackground = false;
                EditAPIThread.Priority = ThreadPriority.Highest;
                EditAPIThread.Start();

                Thread EditWebThread = new Thread(new ThreadStart(() =>
                {
                    while (!Program.StoppedClaimer)
                    {
                        String DataBody = $"email={Email}&username={Target}&phone_number={PhoneNumber}&biography={Bio}&chaining_enabled=on";
                        String UrlAPI = "https://www.instagram.com/accounts/edit/?__d=dis";
                        HttpStatusCode StatusCode = new HttpStatusCode();
                        String Response = RequestPacket(UrlAPI, ref StatusCode, DataBody, "EditWEB", Session);
                        if (Response.Contains(Target) || Response.Contains("\"status\":\"ok\""))
                        {
                            lock (Program.thisLock)
                            {
                                if (!Program.StoppedClaimer)
                                {
                                    Program.StoppedClaimer = true;
                                    WaitClaimed.Set();
                                    Program.DoneClaimed(Target, Session, Email);
                                }
                            }
                        }
                        else if (Response.Contains("This username isn't available") || Response.Contains("isn't") || Response.Contains("Something is wrong") || Response.Contains("\"message\":\"Try Again Later\",") || Response.Contains("Please try again later.") || StatusCode == HttpStatusCode.BadRequest)
                        {
                            Interlocked.Increment(ref ATT);
                            continue;
                        }
                        else if (Response.Contains("wait") || Response.Contains("generic") || Response.Contains("rate_limit_error") || StatusCode.ToString() == "429")
                        {
                            Interlocked.Increment(ref RL);
                            continue;
                        }
                        else if (Response.Contains("challenge_required") || Response.Contains("consent_required") || Response.Contains("login_required") || StatusCode == HttpStatusCode.Forbidden)
                        {
                            Interlocked.Increment(ref BadSession);
                            continue;
                        }
                        Thread.Sleep(new Random().Next(10, 25));
                    }

                }));
                EditWebThread.IsBackground = false;
                EditWebThread.Priority = ThreadPriority.Highest;
                EditWebThread.Start();

                Thread EditWebAPIThread = new Thread(new ThreadStart(() =>
                {
                    while (!Program.StoppedClaimer)
                    {
                        String DataBody = $"email={Email}&username={Target}&phone_number={PhoneNumber}&biography={Bio}&chaining_enabled=on";
                        String UrlAPI = "https://i.instagram.com/api/v1/web/accounts/edit/";
                        HttpStatusCode StatusCode = new HttpStatusCode();
                        String Response = RequestPacket(UrlAPI, ref StatusCode, DataBody, "EditWebAPI", Session);
                        if (Response.Contains(Target) || Response.Contains("\"status\":\"ok\""))
                        {
                            lock (Program.thisLock)
                            {
                                if (!Program.StoppedClaimer)
                                {
                                    Program.StoppedClaimer = true;
                                    WaitClaimed.Set();
                                    Program.DoneClaimed(Target, Session, Email);
                                }
                            }
                        }
                        else if (Response.Contains("This username isn't available") || Response.Contains("isn't") || Response.Contains("Something is wrong") || Response.Contains("\"message\":\"Try Again Later\",") || Response.Contains("Please try again later.") || StatusCode == HttpStatusCode.BadRequest)
                        {
                            Interlocked.Increment(ref ATT);
                            continue;
                        }
                        else if (Response.Contains("wait") || Response.Contains("generic") || Response.Contains("rate_limit_error") || StatusCode.ToString() == "429")
                        {
                            Interlocked.Increment(ref RL);
                            continue;
                        }
                        else if (Response.Contains("challenge_required") || Response.Contains("consent_required") || Response.Contains("login_required") || StatusCode == HttpStatusCode.Forbidden)
                        {
                            Interlocked.Increment(ref BadSession);
                            continue;
                        }
                        Thread.Sleep(new Random().Next(10, 25));
                    }

                }));
                EditWebAPIThread.IsBackground = false;
                EditWebAPIThread.Priority = ThreadPriority.Highest;
                EditWebAPIThread.Start();

                Thread EditCenterThread = new Thread(new ThreadStart(() =>
                {
                    while (!Program.StoppedClaimer)
                    {
                        String DataBody = "params={\"client_input_params\":{\"username\":\"" + Target + "\",\"family_device_id\":\"604ed4f7-e52c-44c1-8909-1846a9e6e6e4\"},\"server_params\":{\"operation_type\":\"MUTATE\",\"identity_ids\":\"" + FbIDv2 + "\"}}&_uuid=84990e73-e663-44c1-a008-064d1f1d0f9f&bk_client_context={\"bloks_version\":\"33bf851d4ffa1459309fc7b28463c5d91ffc7aaad80d1c5f9a8a4ed728e319f7\",\"styles_id\":\"instagram\"}&bloks_versioning_id=33bf851d4ffa1459309fc7b28463c5d91ffc7aaad80d1c5f9a8a4ed728e319f7";
                        String UrlAPI = "https://i.instagram.com/api/v1/bloks/apps/com.bloks.www.fxim.settings.username.change.async/";

                        HttpStatusCode StatusCode = new HttpStatusCode();
                        String Response = RequestPacket(UrlAPI, ref StatusCode, DataBody, "EditCenterAPI", Session);
                        if (Response.Contains(Target))
                        {
                            lock (Program.thisLock)
                            {
                                if (!Program.StoppedClaimer)
                                {
                                    Program.StoppedClaimer = true;
                                    WaitClaimed.Set();
                                    Program.DoneClaimed(Target, Session, Email);
                                }
                            }
                        }
                        else if (Response.Contains("This username isn't available") || Response.Contains("isn't") || Response.Contains("Something is wrong") || Response.Contains("\"message\":\"Try Again Later\",") || Response.Contains("Please try again later.") || StatusCode == HttpStatusCode.BadRequest)
                        {
                            Interlocked.Increment(ref ATT);
                            continue;
                        }
                        else if (Response.Contains("wait") || Response.Contains("generic") || Response.Contains("rate_limit_error") || StatusCode.ToString() == "429")
                        {
                            Interlocked.Increment(ref RL);
                            continue;
                        }
                        else if (Response.Contains("challenge_required") || Response.Contains("consent_required") || Response.Contains("login_required") || StatusCode == HttpStatusCode.Forbidden)
                        {
                            Interlocked.Increment(ref BadSession);
                            continue;
                        }
                        Thread.Sleep(new Random().Next(10, 25));
                    }

                }));
                EditCenterThread.IsBackground = false;
                EditCenterThread.Priority = ThreadPriority.Highest;
                EditCenterThread.Start();
            }
        }
        public static void LoopMulti(String Target, String Bio)
        {
            for (Int32 i = 0; i <= Convert.ToInt32(Program.InputThreads); i++)
            {

                Thread EditAPIThread = new Thread(new ThreadStart(() =>
                {
                    while (!Program.StoppedClaimer)
                    {
                        Program.SessionsLine++;
                        if (Program.SessionsLine >= Program.SessionList.Count)
                        {
                            Program.SessionsLine = 0;
                        }
                        String ShowList = Program.SessionList[Program.SessionsLine];

                        if (ShowList.Contains(":"))
                        {
                            String Session = ShowList.Split(':')[0];
                            String FbIDv2 = ShowList.Split(':')[1];
                            String UserID = ShowList.Split(':')[2];
                            String Email = ShowList.Split(':')[3];
                            String PhoneNumber = ShowList.Split(':')[4];

                            Dictionary<String, String> StringData = new Dictionary<String, String>();
                            StringData.Add("primary_profile_link_type", "0");
                            StringData.Add("phone_number", PhoneNumber);
                            StringData.Add("username", Target);
                            StringData.Add("show_fb_link_on_profile", "false");
                            StringData.Add("_uid", UserID);
                            StringData.Add("device_id", "android-3e1f1446b9898a45");
                            StringData.Add("biography", Bio);
                            StringData.Add("_uuid", "84990e73-e663-44c1-a008-064d1f1d0f9f");
                            StringData.Add("email", Email);

                            String JSON = ConvertDataToJSON(StringData);
                            String DataBody = $"signed_body=SIGNATURE.{JSON}";

                            String UrlAPI = "https://i.instagram.com/api/v1/accounts/edit_profile/";
                            HttpStatusCode StatusCode = new HttpStatusCode();
                            String Response = RequestPacket(UrlAPI, ref StatusCode, DataBody, "EditAPI", Session);
                            if (Response.Contains(Target) || Response.Contains("\"status\":\"ok\""))
                            {
                                lock (Program.thisLock)
                                {
                                    if (!Program.StoppedClaimer)
                                    {
                                        Program.StoppedClaimer = true;
                                        WaitClaimed.Set();
                                        Program.DoneClaimed(Target, Session, Email);
                                    }
                                }
                            }
                            else if (Response.Contains("This username isn't available") || Response.Contains("isn't") || Response.Contains("Something is wrong") || Response.Contains("\"message\":\"Try Again Later\",") || Response.Contains("Please try again later.") || StatusCode == HttpStatusCode.BadRequest)
                            {
                                Interlocked.Increment(ref ATT);
                                continue;
                            }
                            else if (Response.Contains("wait") || Response.Contains("generic") || Response.Contains("rate_limit_error") || StatusCode.ToString() == "429")
                            {
                                Interlocked.Increment(ref RL);
                                continue;
                            }
                            else if (Response.Contains("challenge_required") || Response.Contains("consent_required") || Response.Contains("login_required") || StatusCode == HttpStatusCode.Forbidden)
                            {
                                Interlocked.Increment(ref BadSession);
                                continue;
                            }
                        }
                        else
                        {
                            ShowList = Program.SessionList[new Random().Next(Program.SessionList.Count)];
                            String Session = ShowList.Split(':')[0];
                            String FbIDv2 = ShowList.Split(':')[1];
                            String UserID = ShowList.Split(':')[2];
                            String Email = ShowList.Split(':')[3];
                            String PhoneNumber = ShowList.Split(':')[4];

                            Dictionary<String, String> StringData = new Dictionary<String, String>();
                            StringData.Add("primary_profile_link_type", "0");
                            StringData.Add("phone_number", PhoneNumber);
                            StringData.Add("username", Target);
                            StringData.Add("show_fb_link_on_profile", "false");
                            StringData.Add("_uid", UserID);
                            StringData.Add("device_id", "android-3e1f1446b9898a45");
                            StringData.Add("biography", Bio);
                            StringData.Add("_uuid", "84990e73-e663-44c1-a008-064d1f1d0f9f");
                            StringData.Add("email", Email);

                            String JSON = ConvertDataToJSON(StringData);
                            String DataBody = $"signed_body=SIGNATURE.{JSON}";

                            String UrlAPI = "https://i.instagram.com/api/v1/accounts/edit_profile/";
                            HttpStatusCode StatusCode = new HttpStatusCode();
                            String Response = RequestPacket(UrlAPI, ref StatusCode, DataBody, "EditAPI", Session);
                            if (Response.Contains(Target) || Response.Contains("\"status\":\"ok\""))
                            {
                                lock (Program.thisLock)
                                {
                                    if (!Program.StoppedClaimer)
                                    {
                                        Program.StoppedClaimer = true;
                                        WaitClaimed.Set();
                                        Program.DoneClaimed(Target, Session, Email);
                                    }
                                }
                            }
                            else if (Response.Contains("This username isn't available") || Response.Contains("isn't") || Response.Contains("Something is wrong") || Response.Contains("\"message\":\"Try Again Later\",") || Response.Contains("Please try again later.") || StatusCode == HttpStatusCode.BadRequest)
                            {
                                Interlocked.Increment(ref ATT);
                                continue;
                            }
                            else if (Response.Contains("wait") || Response.Contains("generic") || Response.Contains("rate_limit_error") || StatusCode.ToString() == "429")
                            {
                                Interlocked.Increment(ref RL);
                                continue;
                            }
                            else if (Response.Contains("challenge_required") || Response.Contains("consent_required") || Response.Contains("login_required") || StatusCode == HttpStatusCode.Forbidden)
                            {
                                Interlocked.Increment(ref BadSession);
                                continue;
                            }
                        }
                        Thread.Sleep(new Random().Next(10, 25));
                    }

                }));
                EditAPIThread.IsBackground = false;
                EditAPIThread.Priority = ThreadPriority.Highest;
                EditAPIThread.Start();

                Thread EditCenterThread = new Thread(new ThreadStart(() =>
                {
                    while (!Program.StoppedClaimer)
                    {
                        Program.SessionsLine++;
                        if (Program.SessionsLine >= Program.SessionList.Count)
                        {
                            Program.SessionsLine = 0;
                        }
                        String ShowList = Program.SessionList[Program.SessionsLine];

                        if (ShowList != null)
                        {
                            String Session = ShowList.Split(':')[0];
                            String FbIDv2 = ShowList.Split(':')[1];
                            String UserID = ShowList.Split(':')[2];
                            String Email = ShowList.Split(':')[3];
                            String PhoneNumber = ShowList.Split(':')[4];

                            String DataBody = "params={\"client_input_params\":{\"username\":\"" + Target + "\",\"family_device_id\":\"604ed4f7-e52c-44c1-8909-1846a9e6e6e4\"},\"server_params\":{\"operation_type\":\"MUTATE\",\"identity_ids\":\"" + FbIDv2 + "\"}}&_uuid=84990e73-e663-44c1-a008-064d1f1d0f9f&bk_client_context={\"bloks_version\":\"33bf851d4ffa1459309fc7b28463c5d91ffc7aaad80d1c5f9a8a4ed728e319f7\",\"styles_id\":\"instagram\"}&bloks_versioning_id=33bf851d4ffa1459309fc7b28463c5d91ffc7aaad80d1c5f9a8a4ed728e319f7";
                            String UrlAPI = "https://i.instagram.com/api/v1/bloks/apps/com.bloks.www.fxim.settings.username.change.async/";

                            HttpStatusCode StatusCode = new HttpStatusCode();
                            String Response = RequestPacket(UrlAPI, ref StatusCode, DataBody, "EditCenterAPI", Session);
                            if (Response.Contains(Target))
                            {
                                lock (Program.thisLock)
                                {
                                    if (!Program.StoppedClaimer)
                                    {
                                        Program.StoppedClaimer = true;
                                        WaitClaimed.Set();
                                        Program.DoneClaimed(Target, Session, Email);
                                    }
                                }
                            }
                            else if (Response.Contains("This username isn't available") || Response.Contains("isn't") || Response.Contains("Something is wrong") || Response.Contains("\"message\":\"Try Again Later\",") || Response.Contains("Please try again later.") || StatusCode == HttpStatusCode.BadRequest)
                            {
                                Interlocked.Increment(ref ATT);
                                continue;
                            }
                            else if (Response.Contains("wait") || Response.Contains("generic") || Response.Contains("rate_limit_error") || StatusCode.ToString() == "429")
                            {
                                Interlocked.Increment(ref RL);
                                continue;
                            }
                            else if (Response.Contains("challenge_required") || Response.Contains("consent_required") || Response.Contains("login_required") || StatusCode == HttpStatusCode.Forbidden)
                            {
                                Interlocked.Increment(ref BadSession);
                                continue;
                            }
                        }
                        else
                        {
                            ShowList = Program.SessionList[new Random().Next(Program.SessionList.Count)];

                            String Session = ShowList.Split(':')[0];
                            String FbIDv2 = ShowList.Split(':')[1];
                            String UserID = ShowList.Split(':')[2];
                            String Email = ShowList.Split(':')[3];
                            String PhoneNumber = ShowList.Split(':')[4];

                            String DataBody = "params={\"client_input_params\":{\"username\":\"" + Target + "\",\"family_device_id\":\"604ed4f7-e52c-44c1-8909-1846a9e6e6e4\"},\"server_params\":{\"operation_type\":\"MUTATE\",\"identity_ids\":\"" + FbIDv2 + "\"}}&_uuid=84990e73-e663-44c1-a008-064d1f1d0f9f&bk_client_context={\"bloks_version\":\"33bf851d4ffa1459309fc7b28463c5d91ffc7aaad80d1c5f9a8a4ed728e319f7\",\"styles_id\":\"instagram\"}&bloks_versioning_id=33bf851d4ffa1459309fc7b28463c5d91ffc7aaad80d1c5f9a8a4ed728e319f7";
                            String UrlAPI = "https://i.instagram.com/api/v1/bloks/apps/com.bloks.www.fxim.settings.username.change.async/";

                            HttpStatusCode StatusCode = new HttpStatusCode();
                            String Response = RequestPacket(UrlAPI, ref StatusCode, DataBody, "EditCenterAPI", Session);
                            if (Response.Contains(Target))
                            {
                                lock (Program.thisLock)
                                {
                                    if (!Program.StoppedClaimer)
                                    {
                                        Program.StoppedClaimer = true;
                                        WaitClaimed.Set();
                                        Program.DoneClaimed(Target, Session, Email);
                                    }
                                }
                            }
                            else if (Response.Contains("This username isn't available") || Response.Contains("isn't") || Response.Contains("Something is wrong") || Response.Contains("\"message\":\"Try Again Later\",") || Response.Contains("Please try again later.") || StatusCode == HttpStatusCode.BadRequest)
                            {
                                Interlocked.Increment(ref ATT);
                                continue;
                            }
                            else if (Response.Contains("wait") || Response.Contains("generic") || Response.Contains("rate_limit_error") || StatusCode.ToString() == "429")
                            {
                                Interlocked.Increment(ref RL);
                                continue;
                            }
                            else if (Response.Contains("challenge_required") || Response.Contains("consent_required") || Response.Contains("login_required") || StatusCode == HttpStatusCode.Forbidden)
                            {
                                Interlocked.Increment(ref BadSession);
                                continue;
                            }
                        }
                        Thread.Sleep(new Random().Next(10, 25));
                    }

                }));
                EditCenterThread.IsBackground = false;
                EditCenterThread.Priority = ThreadPriority.Highest;
                EditCenterThread.Start();
            }
        }
        public static String RequestPacket(String API, ref HttpStatusCode StatusCode, String StringData = null, String Method = null, String Session = null)
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
                if (Program.ChoiceProxies.Contains("1"))
                {
                    Program.ProxyLine++;
                    if (Program.ProxyLine >= Program.ProxyList.Count)
                    {
                        Program.ProxyLine = 0;
                    }
                    String ShowProxies = Program.ProxyList[Program.ProxyLine];
                    if (ShowProxies != null)
                    {
                        Program.IpProxy = ShowProxies.Split(':')[0];
                        Program.PortProxy = Int32.Parse(ShowProxies.Split(':')[1]);

                        string Proxies = Program.IpProxy + ":" + Program.PortProxy;
                        Requests.Proxy = new WebProxy(Proxies);
                    }
                    else
                    {
                        ShowProxies = Program.ProxyList[new Random().Next(Program.ProxyList.Count)];

                        Program.IpProxy = ShowProxies.Split(':')[0];
                        Program.PortProxy = Int32.Parse(ShowProxies.Split(':')[1]);

                        String Proxies = Program.IpProxy + ":" + Program.PortProxy;
                        Requests.Proxy = new WebProxy(Proxies);
                    }
                }
                else if (Program.ChoiceProxies.Contains("2"))
                {
                    Program.ProxyLine++;
                    if (Program.ProxyLine >= Program.ProxyList.Count)
                    {
                        Program.ProxyLine = 0;
                    }
                    String ShowProxies = Program.ProxyList[Program.ProxyLine];

                    if (ShowProxies != null)
                    {
                        Program.IpProxy = ShowProxies.Split(':')[0];
                        Program.PortProxy = Int32.Parse(ShowProxies.Split(':')[1]);
                        Program.UserProxy = ShowProxies.Split(':')[2];
                        Program.PasswordProxy = ShowProxies.Split(':')[3];

                        String Proxies = Program.IpProxy + ":" + Program.PortProxy;
                        Requests.Proxy = new WebProxy(Proxies);
                        Requests.Proxy.Credentials = new NetworkCredential(Program.UserProxy, Program.PasswordProxy);
                    }
                    else
                    {
                        ShowProxies = Program.ProxyList[new Random().Next(Program.ProxyList.Count)];

                        Program.IpProxy = ShowProxies.Split(':')[0];
                        Program.PortProxy = Int32.Parse(ShowProxies.Split(':')[1]);
                        Program.UserProxy = ShowProxies.Split(':')[2];
                        Program.PasswordProxy = ShowProxies.Split(':')[3];

                        string Proxies = Program.IpProxy + ":" + Program.PortProxy;
                        Requests.Proxy = new WebProxy(Proxies);
                        Requests.Proxy.Credentials = new NetworkCredential(Program.UserProxy, Program.PasswordProxy);
                    }
                }
                if (Method.Contains("EditAPI"))
                {
                    Requests.Accept = "*";
                    Requests.Method = "POST";
                    Requests.Host = "i.instagram.com";
                    Requests.UserAgent = $"Instagram {new Random().Next(110, 140)}.0.0.20.105 Android";
                    Requests.Headers.Add("accept-language", "en-US");
                    Requests.Headers.Add("x-mid", "YwwvwAABAAHddmpNJpZhbFA421Uz");
                    Requests.Headers.Add("x-bloks-version-id", "33bf851d4ffa1459309fc7b28463c5d91ffc7aaad80d1c5f9a8a4ed728e319f7");
                    Requests.Headers.Add("x-ig-www-claim", "hmac.AR2H0dAreCx6JfDzBXXn7CkVXQRps90cyGd68kyxClg6DNmW");
                    Requests.Headers.Add("x-ig-device-id", "84990e73-e663-44c1-a008-064d1f1d0f9f");
                    Requests.Headers.Add("x-ig-family-device-id", "7b2f7b91-7ec6-4b72-b78a-40d9d18e1c42");
                    Requests.Headers.Add("x-ig-android-id", "android-3e1f1446b9898a45");
                    Requests.Headers.Add("x-fb-connection-type", "WIFI");
                    Requests.Headers.Add("x-ig-connection-type", "WIFI");
                    Requests.Headers.Add("x-ig-capabilities", "3brTv10=");
                    Requests.Headers.Add("x-ig-app-id", "567067343352427");
                    Requests.Headers.Add("ig-u-ds-user-id", Randomizer(16));
                    Requests.Headers.Add("x-fb-http-engine", "Liger");
                    Requests.Headers.Add("x-fb-client-ip", "True");
                    Requests.Headers.Add("x-fb-server-cluster", "True");
                    Requests.Headers.Add("cookie2", "$Version=1");
                    Requests.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    Requests.ServerCertificateValidationCallback = ((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);
                    Requests.ServicePoint.ConnectionLimit = int.MaxValue;
                    Requests.UnsafeAuthenticatedConnectionSharing = true;
                    Requests.ProtocolVersion = HttpVersion.Version11;
                    Requests.ServicePoint.UseNagleAlgorithm = false;
                    Requests.ServicePoint.Expect100Continue = false;
                    Requests.MaximumAutomaticRedirections = 500;
                    Requests.CookieContainer = CookieContainer;
                    Requests.UseDefaultCredentials = true;
                    Requests.AllowAutoRedirect = false;
                    Requests.PreAuthenticate = true;
                    Requests.Pipelined = true;
                    Requests.KeepAlive = true;
                    Requests.Timeout = 5000;
                }
                else if (Method.Contains("EditWEB"))
                {
                    string Csrftoken = Randomizer(32);
                    Requests.Accept = "*";
                    Requests.Method = "POST";
                    Requests.Host = "www.instagram.com";
                    Requests.Referer = "https://www.instagram.com/accounts/edit/";
                    Requests.UserAgent = "Mozilla";
                    Requests.Headers.Add("X-IG-App-ID", "936619743392459");
                    Requests.Headers.Add("X-IG-WWW-Claim", "hmac.AR0qxW12XpVb_2Yo3HZh7QAJDEIZsz1XolVT9SZ0Bq16cbkq");
                    Requests.Headers.Add("sec-ch-ua-mobile", "?0");
                    Requests.Headers.Add("X-Instagram-AJAX", "3621cb567045");
                    Requests.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    Requests.Headers.Add("X-ASBD-ID", "198387");
                    Requests.Headers.Add("x-csrftoken", Csrftoken);
                    Requests.Headers.Add("sec-ch-ua", "\"Google Chrome\";v=\"105\", \"Not)A;Brand\";v=\"8\", \"Chromium\";v=\"105\"");
                    Requests.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
                    Requests.Headers.Add("Origin", "https://www.instagram.com");
                    Requests.Headers.Add("Sec-Fetch-Site", "same-origin");
                    Requests.Headers.Add("Sec-Fetch-Mode", "cors");
                    Requests.Headers.Add("Sec-Fetch-Dest", "empty");
                    Requests.Headers.Add("Accept-Language", "en-US");
                    Requests.Headers.Add("Cookie", $"csrftoken={Csrftoken}; mid={Randomizer(28)}; ig_did={Guid.NewGuid().ToString().ToLower()}; ig_ncrb=1; sessionid={Session};");
                    Requests.Headers.Add("IG-U-DS-USER-ID", Randomizer(16));
                    Requests.ContentType = "application/x-www-form-urlencoded";
                    Requests.ServerCertificateValidationCallback = ((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);
                    Requests.ServicePoint.ConnectionLimit = int.MaxValue;
                    Requests.UnsafeAuthenticatedConnectionSharing = true;
                    Requests.ProtocolVersion = HttpVersion.Version11;
                    Requests.ServicePoint.UseNagleAlgorithm = false;
                    Requests.ServicePoint.Expect100Continue = false;
                    Requests.MaximumAutomaticRedirections = 500;
                    //Requests.CookieContainer = CookieContainer;
                    Requests.UseDefaultCredentials = true;
                    Requests.AllowAutoRedirect = false;
                    Requests.PreAuthenticate = true;
                    Requests.Pipelined = true;
                    Requests.KeepAlive = true;
                    Requests.Timeout = 5000;
                }
                else if (Method.Contains("EditWebAPI"))
                {
                    string Csrftoken = Randomizer(32);
                    Requests.Accept = "*";
                    Requests.Method = "POST";
                    Requests.Host = "www.instagram.com";
                    Requests.Referer = "https://www.instagram.com/";
                    Requests.UserAgent = "Mozilla";
                    Requests.Headers.Add("X-IG-App-ID", "1217981644879628");
                    Requests.Headers.Add("X-IG-WWW-Claim", "hmac.AR0qxW12XpVb_2Yo3HZh7QAJDEIZsz1XolVT9SZ0Bq16cbkq");
                    Requests.Headers.Add("sec-ch-ua-mobile", "?0");
                    Requests.Headers.Add("X-Instagram-AJAX", "1006106941");
                    Requests.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    Requests.Headers.Add("X-ASBD-ID", "198387");
                    Requests.Headers.Add("x-csrftoken", Csrftoken);
                    Requests.Headers.Add("sec-ch-ua", "\"Google Chrome\";v=\"105\", \"Not)A;Brand\";v=\"8\", \"Chromium\";v=\"105\"");
                    Requests.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
                    Requests.Headers.Add("Origin", "https://www.instagram.com");
                    Requests.Headers.Add("Sec-Fetch-Site", "same-origin");
                    Requests.Headers.Add("Sec-Fetch-Mode", "cors");
                    Requests.Headers.Add("Sec-Fetch-Dest", "empty");
                    Requests.Headers.Add("Accept-Language", "en-US");
                    Requests.Headers.Add("Cookie", $"csrftoken={Csrftoken}; mid={Randomizer(28)}; ig_did={Guid.NewGuid().ToString().ToLower()}; ig_ncrb=1; sessionid={Session};");
                    Requests.Headers.Add("IG-U-DS-USER-ID", Randomizer(16));
                    Requests.ContentType = "application/x-www-form-urlencoded";
                    Requests.ServerCertificateValidationCallback = ((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);
                    Requests.ServicePoint.ConnectionLimit = int.MaxValue;
                    Requests.UnsafeAuthenticatedConnectionSharing = true;
                    Requests.ProtocolVersion = HttpVersion.Version11;
                    Requests.ServicePoint.UseNagleAlgorithm = false;
                    Requests.ServicePoint.Expect100Continue = false;
                    Requests.MaximumAutomaticRedirections = 500;
                    //Requests.CookieContainer = CookieContainer;
                    Requests.UseDefaultCredentials = true;
                    Requests.AllowAutoRedirect = false;
                    Requests.PreAuthenticate = true;
                    Requests.Pipelined = true;
                    Requests.KeepAlive = true;
                    Requests.Timeout = 5000;
                }
                else if (Method.Contains("EditCenterAPI"))
                {
                    Requests.Accept = "*/*";
                    Requests.Method = "POST";
                    Requests.Host = "i.instagram.com";
                    Requests.UserAgent = $"Instagram {new Random().Next(110, 140)}.0.0.20.105 Android";
                    Requests.Headers.Add("accept-language", "en-US");
                    Requests.Headers.Add("x-mid", "YwwvwAABAAHddmpNJpZhbFA421Uz");
                    Requests.Headers.Add("x-bloks-version-id", "33bf851d4ffa1459309fc7b28463c5d91ffc7aaad80d1c5f9a8a4ed728e319f7");
                    Requests.Headers.Add("x-ig-www-claim", "hmac.AR2H0dAreCx6JfDzBXXn7CkVXQRps90cyGd68kyxClg6DNmW");
                    Requests.Headers.Add("x-ig-device-id", "84990e73-e663-44c1-a008-064d1f1d0f9f");
                    Requests.Headers.Add("x-ig-family-device-id", "604ed4f7-e52c-44c1-8909-1846a9e6e6e4");
                    Requests.Headers.Add("x-ig-android-id", "android-3e1f1446b9898a45");
                    Requests.Headers.Add("x-fb-connection-type", "WIFI");
                    Requests.Headers.Add("x-ig-connection-type", "WIFI");
                    Requests.Headers.Add("x-ig-capabilities", "3brTv10=");
                    Requests.Headers.Add("x-ig-app-id", "567067343352427");
                    Requests.Headers.Add("ig-u-ds-user-id", Randomizer(16));
                    Requests.Headers.Add("x-fb-http-engine", "Liger");
                    Requests.Headers.Add("x-fb-client-ip", "True");
                    Requests.Headers.Add("x-fb-server-cluster", "True");
                    Requests.Headers.Add("cookie2", "$Version=1");
                    Requests.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    Requests.ServerCertificateValidationCallback = ((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);
                    Requests.ServicePoint.ConnectionLimit = int.MaxValue;
                    Requests.UnsafeAuthenticatedConnectionSharing = true;
                    Requests.ProtocolVersion = HttpVersion.Version11;
                    Requests.ServicePoint.UseNagleAlgorithm = false;
                    Requests.ServicePoint.Expect100Continue = false;
                    Requests.MaximumAutomaticRedirections = 500;
                    Requests.CookieContainer = CookieContainer;
                    Requests.UseDefaultCredentials = true;
                    Requests.AllowAutoRedirect = false;
                    Requests.PreAuthenticate = true;
                    Requests.Pipelined = true;
                    Requests.KeepAlive = true;
                    Requests.Timeout = 5000;
                }
                byte[] Bytes = Encoding.ASCII.GetBytes(StringData.ToString());
                Requests.ContentLength = (long)Bytes.Length;
                Stream Stream = Requests.GetRequestStream();
                Stream.Write(Bytes, 0, Bytes.Length);
                Stream.Flush();
                Stream.Close();
                Stream.Dispose();
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
        public static void PrintCounter(String HiddenProxiesInfo)
        {
            while (!Program.StoppedClaimer)
            {
                if (!Program.StoppedClaimer)
                    Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(Banner);

                Program.Input("Blade v1.3", $"Instagram Info", ConsoleColor.Magenta, ConsoleColor.White);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n\n");

                Console.Write("  ");
                Program.Input("Info", $"[{Program.InputTarget}]", ConsoleColor.DarkYellow, ConsoleColor.DarkYellow);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($": Your Target\r\n");

                Console.Write("  ");
                Program.Input("Counter", $"[{RequestSent.ToString("###,###")}]", ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($": Requests Sent\r\n");

                Console.Write("  ");
                Program.Input("Counter", $"[{ATT.ToString("###,###")}]", ConsoleColor.Green, ConsoleColor.Green);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($": Requests\r\n");

                Console.Write("  ");
                Program.Input("Counter", $"[{RPS.ToString("###,###")}]", ConsoleColor.Green, ConsoleColor.Green);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($": RPS\r\n");

                Console.Write("  ");
                Program.Input("Counter", $"[{RL.ToString("###,###")}]", ConsoleColor.Red, ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($": Rate Limit\r\n");

                Console.Write("  ");
                Program.Input("Counter", $"[{BadSession.ToString("###,###")}]", ConsoleColor.DarkRed, ConsoleColor.DarkRed);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($": Bad Sessions\r");

                if (HiddenProxiesInfo.Contains("1"))
                {
                    Console.Write($"\n\n");
                    Program.Input("Blade v1.3", $"Proxies Info", ConsoleColor.Magenta, ConsoleColor.White);
                    Console.Write("\n\n");

                    Console.Write("  ");
                    Program.Input("Proxies", $"[{Program.IpProxy}]", ConsoleColor.Green, ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($": IP\r\n");

                    Console.Write("  ");
                    Program.Input("Proxies", $"[{Program.PortProxy}]", ConsoleColor.Green, ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($": Port\r\n");
                    if (Program.ChoiceProxies.Contains("2"))
                    {

                        Console.Write("  ");
                        Program.Input("Proxies", $"[{Program.UserProxy}]", ConsoleColor.Green, ConsoleColor.Green);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($": Username\r\n");

                        Console.Write("  ");
                        Program.Input("Proxies", $"[{Program.PasswordProxy}]", ConsoleColor.Green, ConsoleColor.Green);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($": Password\r");
                    }
                }

                Thread.Sleep(250);
            }
        }
        public static void PrintAccountInfo()
        {
            if (AccountInfo.Email != null)
            {
                Program.Input("Info", "Account Info", ConsoleColor.Magenta, ConsoleColor.White); ; Console.WriteLine(); Console.WriteLine();

                Console.Write(" ");
                Program.Input("Info", "Username : ", ConsoleColor.Magenta, ConsoleColor.White);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(AccountInfo.Username);

                Console.Write(" ");
                Program.Input("Info", "Fb ID : ", ConsoleColor.Magenta, ConsoleColor.White);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(AccountInfo.FbIDV2);

                Console.Write(" ");
                Program.Input("Info", "User ID : ", ConsoleColor.Magenta, ConsoleColor.White);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(AccountInfo.UserID);

                Console.Write(" ");
                Program.Input("Info", "Email : ", ConsoleColor.Magenta, ConsoleColor.White);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(AccountInfo.Email);

                Console.Write(" ");
                Program.Input("Info", "Phone Number : ", ConsoleColor.Magenta, ConsoleColor.White);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(AccountInfo.Phone_Number);

                Thread.Sleep(2500);
            }
            else { Program.Input("Venx v1.0", "Error Get Account Info, Please try again...", ConsoleColor.Red, ConsoleColor.White); Console.ReadKey(); ProjectData.EndApp(); Environment.Exit(1); }
        }
        public static String DiscordRandomColor()
        {
            Random random = new Random();
            String str = String.Format("{0:X6}", random.Next(0, 1000000));
            Int32 value = Conversions.ToInteger("&H" + str);
            return Conversions.ToString(value);
        }
        public static void SendWebHookToMe(String Target)
        {
            try
            {
                bool flag = Target.Length <= 6;
                if (flag)
                {
                    ServicePointManager.CheckCertificateRevocationList = false;
                    ServicePointManager.DefaultConnectionLimit = 300;
                    ServicePointManager.UseNagleAlgorithm = false;
                    ServicePointManager.Expect100Continue = false;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    UTF8Encoding utf8Encoding = new UTF8Encoding();
                    String RandomPic = Program.RandomDiscordPec[new Random().Next(Program.RandomDiscordPec.Count)];
                    String RandomDiscordColor = Program.DiscordRandomColor();
                    Byte[] bytes = utf8Encoding.GetBytes(String.Concat(new String[] { String.Concat(new String[] { "{\"content\":null,\"embeds\":[{\"description\":\"**[[@", Target, "](https://instagram.com/", Target, ")]:** :see_no_evil: ``Blade Moved it...``\\n**[Version]: **``v1.3``\",\"color\":\"" + RandomDiscordColor + "\",\"footer\":{\"text\":\"Very nice\",\"icon_url\":\"" + RandomPic + "\"},\"thumbnail\":{\"url\":\"" + RandomPic + "\"},\"timestamp\":\"" + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ") + "\"}],\"username\":\"Blade Swapper v1.3\",\"avatar_url\":\"" + RandomPic + "\"}" }) }));
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("Url WebHook");
                    HttpWebRequest httpWebRequest2 = httpWebRequest;
                    httpWebRequest2.Method = "POST";
                    httpWebRequest2.Proxy = null;
                    httpWebRequest2.Host = "discord.com";
                    httpWebRequest2.KeepAlive = true;
                    httpWebRequest2.Headers.Add("sec-ch-ua: \"Google Chrome\";v=\"87\", \" Not;A Brand\";v=\"99\", \"Chromium\";v=\"87\"");
                    httpWebRequest2.Accept = "application/json";
                    httpWebRequest2.Headers.Add("Accept-Language: en");
                    httpWebRequest2.Headers.Add("sec-ch-ua-mobile: ?0");
                    httpWebRequest2.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36";
                    httpWebRequest2.ContentType = "application/json";
                    httpWebRequest2.Headers.Add("Origin: https://discohook.org");
                    httpWebRequest2.Headers.Add("Sec-Fetch-Site: cross-site");
                    httpWebRequest2.Headers.Add("Sec-Fetch-Mode: cors");
                    httpWebRequest2.Headers.Add("Sec-Fetch-Dest: empty");
                    httpWebRequest2.Referer = "https://discohook.org/";
                    httpWebRequest2.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
                    httpWebRequest2.ContentLength = (long)bytes.Length;
                    Stream Stream = httpWebRequest.GetRequestStream();
                    Stream.Write(bytes, 0, bytes.Length);
                    Stream.Dispose();
                    Stream.Close();
                    StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
                    String text = streamReader.ReadToEnd();
                    streamReader.Dispose();
                    streamReader.Close();
                }
            }
            catch (WebException ex)
            {
                String str = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                Interaction.MsgBox($"Error From Webhook : {str}", MsgBoxStyle.Critical, "Blade Swapper v1.3");
            }
        }
        public static void SendWebHookToZbon(String Target)
        {
            try
            {
                ServicePointManager.CheckCertificateRevocationList = false;
                ServicePointManager.DefaultConnectionLimit = 300;
                ServicePointManager.UseNagleAlgorithm = false;
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                UTF8Encoding utf8Encoding = new UTF8Encoding();
                String RandomPic = Program.RandomDiscordPec[new Random().Next(Program.RandomDiscordPec.Count)];
                String RandomDiscordColor = Program.DiscordRandomColor();
                Byte[] bytes = utf8Encoding.GetBytes(String.Concat(new String[] { String.Concat(new String[] { "{\"content\":null,\"embeds\":[{\"description\":\"**[[@", Target, "](https://instagram.com/", Target, ")]:** :see_no_evil: ``Blade Moved it...``\\n**[Version]: **``v1.3``\",\"color\":\"" + RandomDiscordColor + "\",\"footer\":{\"text\":\"Very nice\",\"icon_url\":\"" + RandomPic + "\"},\"thumbnail\":{\"url\":\"" + RandomPic + "\"},\"timestamp\":\"" + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ") + "\"}],\"username\":\"Blade Swapper v1.3\",\"avatar_url\":\"" + RandomPic + "\"}" }) }));
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(TurboInfo.WebHook.ToString());
                HttpWebRequest httpWebRequest2 = httpWebRequest;
                httpWebRequest2.Method = "POST";
                httpWebRequest2.Proxy = null;
                httpWebRequest2.Host = "discord.com";
                httpWebRequest2.KeepAlive = true;
                httpWebRequest2.Headers.Add("sec-ch-ua: \"Google Chrome\";v=\"87\", \" Not;A Brand\";v=\"99\", \"Chromium\";v=\"87\"");
                httpWebRequest2.Accept = "application/json";
                httpWebRequest2.Headers.Add("Accept-Language: en");
                httpWebRequest2.Headers.Add("sec-ch-ua-mobile: ?0");
                httpWebRequest2.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36";
                httpWebRequest2.ContentType = "application/json";
                httpWebRequest2.Headers.Add("Origin: https://discohook.org");
                httpWebRequest2.Headers.Add("Sec-Fetch-Site: cross-site");
                httpWebRequest2.Headers.Add("Sec-Fetch-Mode: cors");
                httpWebRequest2.Headers.Add("Sec-Fetch-Dest: empty");
                httpWebRequest2.Referer = "https://discohook.org/";
                httpWebRequest2.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
                httpWebRequest2.ContentLength = (long)bytes.Length;
                Stream Stream = httpWebRequest.GetRequestStream();
                Stream.Write(bytes, 0, bytes.Length);
                Stream.Dispose();
                Stream.Close();
                StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
                String Response = streamReader.ReadToEnd();
                streamReader.Dispose();
                streamReader.Close();
            }
            catch (WebException ex)
            {
                String str = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                Interaction.MsgBox($"Error From Webhook : {str}", MsgBoxStyle.Critical, "Blade Swapper v1.3");
            }
        }
        public static void DoneClaimed(String Target, String Email, String Session)
        {
            WaitClaimed.WaitOne();
            Program.StoppedClaimer = true;
            Console.WriteLine();
            Console.WriteLine();
            Program.Input("Blade v1.3", $"[@{Target}]", ConsoleColor.Green, ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($": {TurboInfo.ConsoleTitle} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{Program.ATT.ToString("###,###")}]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": After Attempts");
            Program.SendWebHookToMe(Target);
            Program.SendWebHookToZbon(Target);
            using (StreamWriter writer = new StreamWriter($"@{Target}.txt", false))
            {
                writer.WriteLine($"Blade Moved It : [@{Target}]");
                writer.WriteLine($"Email : [{Email}]");
                writer.WriteLine($"Session : [{Session}]");
                writer.Dispose();
                writer.Close();
            }
            Program.Input("Blade v1.3", "Press Enter To Show Message Box...", ConsoleColor.Magenta, ConsoleColor.White); Console.ReadLine();
            Interaction.MsgBox($"{TurboInfo.FormMessage} : [@{Target}]\nAfter Attempts : [{Program.ATT.ToString("###,###")}]", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Blade Swapper v1.3");
            ProjectData.EndApp(); Environment.Exit(1);
        }
        public static void ReadLists(String FilePath)
        {
            try
            {
                if (FilePath.Contains(@"Settings.txt"))
                {
                    Program.Settings = File.ReadAllText(FilePath);
                    if (Program.Settings.Length == 0)
                    {
                        Program.Input("Reader", $"[{FilePath}]", ConsoleColor.Red, ConsoleColor.Red);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(": Put Information, Please try again...");
                        Console.ReadKey();
                        ProjectData.EndApp();
                        Environment.Exit(1);
                    }
                    TurboInfo.FormMessage = Regex.Match(Program.Settings, "Message Box : \\[(.*?)\\]").Groups[1].Value;
                    TurboInfo.ConsoleTitle = Regex.Match(Program.Settings, "Console Title : \\[(.*?)\\]").Groups[1].Value;
                    TurboInfo.WebHook = Regex.Match(Program.Settings, "WebHook : \\[(.*?)\\]").Groups[1].Value;
                    TurboInfo.Biography = Regex.Match(Program.Settings, "Biography : \\[(.*?)\\]").Groups[1].Value;
                    Program.Input("Reader", $"[{FilePath}]", ConsoleColor.Green, ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(": Success Loaded");
                }

                else if (FilePath.Contains(@"Proxies.txt"))
                {
                    Program.ProxyList = File.ReadAllLines(FilePath).ToList();
                    if (Program.ProxyList.Count == 0)
                    {
                        Program.Input("Reader", $"[{FilePath}]", ConsoleColor.Red, ConsoleColor.Red);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(": Put Information, Please try again...");
                        Console.ReadKey();
                        ProjectData.EndApp();
                        Environment.Exit(1);
                    }
                    Program.Input("Reader", $"[{FilePath}]", ConsoleColor.Green, ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(": Success Loaded, ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"[{Program.ProxyList.Count().ToString("###,###")}]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(": Count");
                }
                else if (FilePath.Contains(@"Sessions.txt"))
                {
                    Program.SessionList = File.ReadAllLines(FilePath).ToList();
                    if (Program.SessionList.Count == 0)
                    {
                        Program.Input("Reader", $"[{FilePath}]", ConsoleColor.Red, ConsoleColor.Red);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(": Put Information, Please try again...");
                        Console.ReadKey();
                        ProjectData.EndApp();
                        Environment.Exit(1);
                    }
                    Program.Input("Reader", $"[{FilePath}]", ConsoleColor.Green, ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(": Success Loaded, ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"[{Program.SessionList.Count().ToString("###,###")}]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(": Count");
                }
            }
            catch(FileNotFoundException)
            {
                if (FilePath.Contains(@"Settings.txt"))
                {
                    using (StreamWriter writer = new StreamWriter($"Settings.txt", false))
                    {
                        writer.WriteLine("----------Claimer Settings----------");
                        writer.WriteLine("[Message Box : [Claimed It]");
                        writer.WriteLine("[Console Title : [Claimed It]");
                        writer.WriteLine("[Biography : [Claimed By > @6gzp]");
                        writer.WriteLine("----------Discord Settings----------");
                        writer.WriteLine("[WebHook : []");
                        writer.Dispose();
                        writer.Close();
                    }
                    Program.Input("Reader", $"[{FilePath}]", ConsoleColor.Red, ConsoleColor.Red);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(": File Not Found, Please try again...");
                    Console.ReadKey();
                    ProjectData.EndApp();
                    Environment.Exit(1);
                }
                else if (FilePath.Contains(@"Proxies.txt"))
                {
                    using (StreamWriter writer = new StreamWriter($"Proxies.txt", false))
                    {
                        writer.WriteLine("Proxy1");
                        writer.WriteLine("Proxy2");
                        writer.Write("Proxy3");
                        writer.Dispose();
                        writer.Close();
                    }
                }
                else if (FilePath.Contains(@"Sessions.txt"))
                {
                    using (StreamWriter writer = new StreamWriter($"Sessions.txt", false))
                    {
                        writer.WriteLine("Session:FbIDv2:UserID:Email:Phone");
                        writer.WriteLine("Session:FbIDv2:UserID:Email:Phone");
                        writer.Write("Session:FbIDv2:UserID:Email:Phone");
                        writer.Dispose();
                        writer.Close();
                    }
                }
                Program.Input("Reader", $"[{FilePath}]", ConsoleColor.Red, ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(": File Not Found, Please try again...");
                Console.ReadKey();
                ProjectData.EndApp();
                Environment.Exit(1);
            }
        }



    }
}
