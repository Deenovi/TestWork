using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyFinder.Models
{
    public class CodeInfo
    {
        public CodeInfo(string code, int duty)
        {
            Code = code;
            Duty = duty;
        }

        public string Code { get; set; }
        public int Duty { get; set; }
    }
}
