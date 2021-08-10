using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions //konfigürasyon sınıfıyla okudugum değerleri atacağım nesne
    {
        public string Audience { get; set; } //seyirci
        public string Issuer { get; set; }  
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
