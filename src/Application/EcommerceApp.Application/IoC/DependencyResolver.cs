using Autofac;
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
            base.Load(builder);
        }
    }
}
