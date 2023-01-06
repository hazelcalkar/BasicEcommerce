using Autofac;
using AutoMapper;
using EcommerceApp.Application.AutoMapper;
using EcommerceApp.Application.Services.AdminService;
using EcommerceApp.Domain.Repositories;
using EcommerceApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Application.IoC
{
    internal class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // IoC --> yani interface çağırdığım zaman bana onun concrete yapısını getirmesi gerektiği işlemini burada söylenmektedir. 

            // builder.RegisterType<BaseRepo>().As<IBaseRepo>().InstancePerLifeTimeScope();

            //program.cs tarafında yapacağım eklemeleri buradan yapabiliriz.

            //örnek olarak automapper eklenmesi buradan yapılabilir. 

            //Repository
            builder.RegisterType<EmployeeRepo>().As<IEmployeeRepo>().InstancePerLifetimeScope();

            //Service
            builder.RegisterType<AdminService>().As<IAdminService>().InstancePerLifetimeScope();


            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                //Mapping dosyamızıda buraya ekliyoruz gidip startup'ta eklemek zorunda kalmayalım zaten burasının görevi oraya sağlamak olacak.
                cfg.AddProfile<Mapping>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
