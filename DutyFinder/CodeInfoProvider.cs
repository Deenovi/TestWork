using DutyFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyFinder
{
    public class CodeInfoProvider
    {
        private Parser _parser;
        private List<CodeInfo> _codeInfoList;

        public CodeInfoProvider()
        {
            _parser = new Parser();
            _codeInfoList = new List<CodeInfo>();
        }

        public List<CodeInfo> GetCodeInfoList(string templateCode)
        {
            var codeList = _parser.GetCodeList(templateCode);

            foreach (var code in codeList)
            {
                _codeInfoList.Add(new CodeInfo(code, _parser.GetDutyByCode(code)));
            }

            return _codeInfoList;
        }
    }
}
