using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utility
{
    public class StringUtility
    {
        public string XMLReplaceUTF16(string str)
        {
            return Regex.Replace(str, @"[\x00-\x08]|[\x0B-\x0C]|[\x0E-\x1F]","");
        }
    }
}
