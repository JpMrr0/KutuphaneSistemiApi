using KutuphaneSistemiApi.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Attributes
{
    public class AuthorizeDefinitonAttribute : Attribute
    {
        public string Menu { get; set; }
        public string Definiton { get; set; }
        public ActionType ActionType { get; set; }
    }
}
