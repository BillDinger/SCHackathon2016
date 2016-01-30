namespace Sitecore.Feature.Blog.Pipelines
{
    using System.Xml;
    using Castle.Windsor;
    using CMS.Installers;
    using Domain.Installers;
    using Installers;
    using Factories;
    using Sitecore.Feature.Blog.Controllers;
    using Sitecore.Pipelines;

    public class BlogStart
    {
        private static IWindsorContainer Container { get; set; }

        public void Process(PipelineArgs args)
        {
            // 1.) Create our base Windsor container for the entire application.
            Container = new WindsorContainer();

            // 2.) Add our Windsor installers to the container.
            Container.Install(new BlogWindsorInstaller(),
                new DomainWindsorInstaller(),
                new CmsWindsorInstaller());

            // 3.) Retrieve our config.
            XmlNode config = Sitecore.Configuration.Factory.GetConfigNode("cmsFactory/cmsType", true);

            // 4.) Resolve our CMS factory.
            IBlogFactory blogFactory = Sitecore.Configuration.Factory.CreateObject<IBlogFactory>(config);

            // 5.) Initialize the blog factory
            blogFactory.Initialize(Container.Kernel);

            // 6.) Init our controller.
            BlogController.Init(blogFactory);
        }
    }
}