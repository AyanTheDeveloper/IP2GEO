using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace IP2GEO
{
    public class IP2GEO
    {
        private string country(string ipAddress)
        {
            string strReturnVal;
            string ipResponse = helper("http://ip-api.com/xml/" + ipAddress);

            //return ipResponse;
            XmlDocument ipInfoXML = new XmlDocument();
            ipInfoXML.LoadXml(ipResponse);
            XmlNodeList responseXML = ipInfoXML.GetElementsByTagName("query");

            NameValueCollection dataXML = new NameValueCollection();

            dataXML.Add(responseXML.Item(0).ChildNodes[2].InnerText, responseXML.Item(0).ChildNodes[2].Value);

            strReturnVal = responseXML.Item(0).ChildNodes[1].InnerText.ToString(); // Contry both
            strReturnVal += " (" +

            responseXML.Item(0).ChildNodes[2].InnerText.ToString() + ")";  // Contry Code both
            return strReturnVal;
        }
        private string countrycode(string ipAddress)
        {
            string strReturnVal;
            string ipResponse = helper("http://ip-api.com/xml/" + ipAddress);

            //return ipResponse;
            XmlDocument ipInfoXML = new XmlDocument();
            ipInfoXML.LoadXml(ipResponse);
            XmlNodeList responseXML = ipInfoXML.GetElementsByTagName("query");

            NameValueCollection dataXML = new NameValueCollection();

            dataXML.Add(responseXML.Item(0).ChildNodes[2].InnerText, responseXML.Item(0).ChildNodes[2].Value);

            strReturnVal = responseXML.Item(0).ChildNodes[2].InnerText.ToString();  // Contry Code ONLY!!!
            return strReturnVal;
        }
        private string countryname(string ipAddress)
        {
            string strReturnVal;
            string ipResponse = helper("http://ip-api.com/xml/" + ipAddress);

            //return ipResponse;
            XmlDocument ipInfoXML = new XmlDocument();
            ipInfoXML.LoadXml(ipResponse);
            XmlNodeList responseXML = ipInfoXML.GetElementsByTagName("query");

            NameValueCollection dataXML = new NameValueCollection();

            dataXML.Add(responseXML.Item(0).ChildNodes[2].InnerText, responseXML.Item(0).ChildNodes[2].Value);

            strReturnVal = responseXML.Item(0).ChildNodes[1].InnerText.ToString(); // Contry NAME ONLY!!!
            return strReturnVal;
        }
        private string helper(string url)
        {

            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();

            StreamReader responseStream = new StreamReader(objResponse.GetResponseStream());
            string responseRead = responseStream.ReadToEnd();

            responseStream.Close();
            responseStream.Dispose();

            return responseRead;
        }
        public string Locate()
        {
            WebClient client = new WebClient();
            Debug.Write("WebClient created!");
            string ip = client.DownloadString("https://api.ipify.org");
            Debug.Write("IP received!");
            return country(ip);
        }
        public string LocateCountryCodeOnly()
        {
            WebClient client = new WebClient();
            Debug.Write("WebClient created!");
            string ip = client.DownloadString("https://api.ipify.org");
            Debug.Write("IP received!");
            return countrycode(ip);
        }
        public string LocateCountryNameOnly()
        {
            WebClient client = new WebClient();
            Debug.Write("WebClient created!");
            string ip = client.DownloadString("https://api.ipify.org");
            Debug.Write("IP received!");
            return countryname(ip);
        }
    }

}
