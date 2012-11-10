using Autofac;
using Autofac.Core;
using Caliburn.Micro.Autofac;
using Footprint.Printing.Services;
using Footprint.Printing.Services.Auth;
using Footprint.Printing.Services.Printing;
using Footprint.Printing.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using Caliburn.Micro;

namespace Footprint.Printing
{
    public class AppBootstrapper : AutofacBootstrapper<ShellViewModel>
    {        
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.GetType().Assembly);
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<PrintingMonitor>().As<IPrintingMonitor>();
            builder.RegisterType<PrintingNotifyService>().As<IPrintingNotifyService>();
            
            base.ConfigureContainer(builder);
        }
    }
}