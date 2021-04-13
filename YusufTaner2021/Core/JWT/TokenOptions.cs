using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JWT
{
    public class TokenOptions
    {
        public string Audince { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpirarion { get; set; }
        public string SecurityKey { get; set; }
    }
}
