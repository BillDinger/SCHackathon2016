using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Features.Blog.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class BlogWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

        }
    }
}