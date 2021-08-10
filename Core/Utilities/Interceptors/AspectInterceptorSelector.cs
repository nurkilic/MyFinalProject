using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> //git claasın attributlerini oku
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)                 //git methodun attributlerini oku(validation,log,cache ...)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);                          //ve onları bir listeye koy
           // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
           // otomatik olarak sistemdeki bütün methodları loga dahil et
            return classAttributes.OrderBy(x => x.Priority).ToArray();           //yalnız onların çalışma sırasını da priority e göre sırala
        }
    }
}
