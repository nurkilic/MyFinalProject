using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services) 
            // webApi de veya Autofacde oluşturduğumuz injectionları oluşturabilmemize yarıyor
            //bundan sonra istediğimiz herhangi bir interfacein servisteki karşılığını tool ile alabiliriz

             // .netin servislerini kullanarak al ve onları build et
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
