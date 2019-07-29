using Moq;
using Ninject;
using SportStore.Data.Concrete;
using SportStore.Data.Interface;
using SportStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebClient.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();


        }


        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            // bindings will show up here

            Mock<IRepoProduct> mock = new Mock<IRepoProduct>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {Name = "Football", Price = 35},
                new Product {Name = "Surf Board", Price = 179},
                new Product {Name = "Running shoes", Price = 89}
            });
            // kernel.Bind<IRepoProduct>().ToConstant(mock.Object);
            kernel.Bind<IRepoProduct>().To<RepoProduct>();
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
            .WithConstructorArgument("settings", emailSettings);
        }
    }
}