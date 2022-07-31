using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DutyFinder
{
    class Parser
    {
        private HtmlWeb _web;
        private HtmlDocument _document;
        private List<string> _codeList;

        public Parser()
        {
            _web = new HtmlWeb();
            _web.PreRequest += (request) =>
            {
                request.Referer = "https://www.tks.ru/";
                return true;
            };
        }

        public List<string> GetCodeList(string templateCode, int digitsCount = 10)
        {
            string url = "https://www.tks.ru/db/tnved/search?searchstr=";
            string xpath = "/html/body/div[1]/div[4]/div[1]/section/div/ul/li";

            string parsedCode = String.Empty;           

            _codeList = new List<string>();
            _document = _web.Load(url + templateCode.Substring(0, 4));

            if (_document != null)
            {
                var nodes = _document.DocumentNode.SelectNodes(xpath);

                foreach (var node in nodes)
                {
                    parsedCode = node.SelectSingleNode("a").InnerText;
                    parsedCode = Regex.Replace(parsedCode, @"\t|\n|\r| ", "");

                    if (parsedCode.Length == digitsCount)
                    {
                        _codeList.Add(parsedCode);
                    }
                }
            }
 
            return _codeList;
        }

        public int GetDutyByCode(string code)
        {
            string url = "https://www.tks.ru/db/tnved/tree/c" + code + "/show/ajax";
            string xpath = "/div/div/div[2]/p[2]";
            string parsedDuty = String.Empty;

            _document = _web.Load(url);

            if (_document != null)
            {
                parsedDuty = _document.DocumentNode.SelectSingleNode(xpath).InnerText;

                if (parsedDuty.Split(',').Count() > 1 && parsedDuty.Contains('%'))
                {
                    return Int32.Parse(parsedDuty.Split(',')[0].Trim('%'));
                }
            }

            return 0;
        }
    }
}
