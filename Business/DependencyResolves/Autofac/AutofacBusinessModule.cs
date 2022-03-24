using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();


            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();


            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();


            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();


            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();


            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); //çalışan uygulama içerisinde 

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() //inplemente edilmiş interfaceleri bul 
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector() //onlar için aspectinterceptorselector u çağır. 
                }).SingleInstance();                            //autofac bizim bütün sınıflarımız için önce bunu
                                                                //çalıştırır bu adamın aspect i varmı
        }
    }
}
