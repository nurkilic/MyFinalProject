using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    //JWT için
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; 
        //jwtı da göndererek istek yapıyoruz,
        //aynı anda binlerce kişi istek yapabilir her bir kişi için her istek için httpcontext oluşur herkese 1 thredd oluşur
        //

        public SecuredOperation(string roles) //bana rolleri ver,rolleri virgülle ayırarak verebiliriz
        {
            _roles = roles.Split(','); //metni virgüle göre ayırıp arraya at
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

            //autofac ile oluşturduğumuz servis mimarisine ulaş
            //servicetool bizim injection alt yapımızı aynen okuyabilmemize yarayan araç

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
