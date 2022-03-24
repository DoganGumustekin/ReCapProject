using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) //bana validatortype yi ver atribute lere tipleri type ile atıyoruz. 
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("bu bir doğrulama sınıfı değil!");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection = çalışma anında bazı şeyleri yap. örenğin bir carvalidator misalini oluştur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //carvalidator un çalışma tipini bul 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //carvalidator un parametrelerine bak 
            foreach (var entity in entities) //herbirini tek tek gez 
            {
                ValidationTool.Validate(validator, entity); //validationtool u kullanarak validation et. 
            }
        }
    }
}
