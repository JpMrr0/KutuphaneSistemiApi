using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.DTOs
{
    public class TokenDTO
    {
        public string Jwtoken { get; set; }
        public DateTime ExpireDate { get; set; }    
    }
}
