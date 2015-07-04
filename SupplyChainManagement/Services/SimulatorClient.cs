using System;
using System.Net;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using System.IO;

using System.Net;
using System.Net.Sockets;

namespace SupplyChainManagement.Services
{
    public class SimulatorClient
    {
        private string _Username;
        public string Username
        {
            get
            {
                return _Username;
            }
        }

        private Uri _BaseUri;
        public RestClient RestClient;

        public SimulatorClient(Uri baseUri, WebProxy proxy)
        {
            _BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
            RestClient.Proxy = proxy;
        }

        public void Login(string username, string password) {
            RestClient.CookieContainer = new System.Net.CookieContainer();

            // Receive JSESSIONID
            var req = new RestRequest("scs/result/resultinfo.jsp", Method.GET);

            try
            {
                var res = RestClient.Execute(req);

                // Login
                req = new RestRequest("scs/result/j_security_check", Method.POST);
                req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                req.AddHeader("Origin", _BaseUri.ToString());
                req.AddHeader("Referer", _BaseUri.ToString() + "/scs/result/resultinfo.jsp");
                req.AddHeader("Accept", "text/html,application/xht ml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                req.AddHeader("Accept-Encoding", "gzip, deflate");
                req.AddHeader("Accept-Language", "en-US,en;q=0.8,de-DE;q=0.6,de;q=0.4,ca;q=0.2,sq;q=0.2");

                req.AddParameter("j_username", username, ParameterType.GetOrPost);
                req.AddParameter("j_password", password, ParameterType.GetOrPost);

                System.Net.ServicePointManager.Expect100Continue = false;

                res = RestClient.Execute(req);


                if (!res.Content.ToLower().Contains("result"))
                {
                    throw new SimulatorException("Login failed. Please check username, password and your internet connection");
                }

                _Username = username;
            }
            catch (SocketException exc) {
                throw new SimulatorException(exc.Message);
            }
            catch (WebException exc)
            {
                throw new SimulatorException(exc.Message);
            }
        }


        public string ReadResult(int game, int group, int period) {
            var req = new RestRequest("scs/data/output/{game}_{group}_{period}result.xml", Method.GET);
            req.AddUrlSegment("game", game.ToString());
            req.AddUrlSegment("group", group.ToString());
            req.AddUrlSegment("period", period.ToString());

            var res = RestClient.Execute(req);

            if (res.StatusCode != HttpStatusCode.OK)
            {
                throw new SimulatorException("Error fetching result. Please check your internet connection.");
            }

            return res.Content;
        }

        public void WriteInputData(string data) 
        {
            var req = new RestRequest("scs/simulate", Method.POST);

            req.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            req.AddHeader("Accept-Encoding", "gzip, deflate");
            req.AddHeader("Accept-Language", "en-US,en;q=0.8,de-DE;q=0.6,de;q=0.4,ca;q=0.2,sq;q=0.2");
            req.AddHeader("Content-Type", "multipart/form-data");

            File.WriteAllText("Input.xml", data);
            req.AddFile("Datei", "Input.xml");
            req.AlwaysMultipartFormData = true;
            
            RestClient.Execute(req);
        }
    }
}
