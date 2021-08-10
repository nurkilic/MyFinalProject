using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); 
            
            //Reflection-çalışma anında birşeyleri çalıştırmayı sağlıyor
            //-newleme işini çalışma anında yapmak istiyoruz mesela

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            //productvalidatorun base typeını bul onun generic çalıştığı veri tipini bul =product

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //invocation=method

            //metodun paremetlerine bak entitytypea yani producta denk geleni bul,birden fazla paremetre olabilir
            //onun paremetrelerinibul=ilgili methodun add(product)

            foreach (var entity in entities) //herbirini tek tek gez validationtool kullanarak validate et
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
