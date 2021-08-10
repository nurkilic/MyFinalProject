using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions //bir kişinin claimlerini ararken
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
            //hangi claimtype mesala hangi rolleri bulmak istiyorsam ona göre result yazmamız gerekiyor
            //,kişinin rollerini bulmamız gerekiyor
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList(); 
            // ?=null olabileceğini anlatır claim oluşmamış adam token istememiş o zaman null olabilir
            //ilgili claim typea göre getiriyorken biz diyoruz ki bize çoğunlukla roller lazım
           
            //claimprincipal =bir kişinin jason ve tokenden gelen claimleri okuması için .nette olan class
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal) //rolleri döndürür
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
