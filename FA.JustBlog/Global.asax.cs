using Autofac;
using Autofac.Integration.Mvc;
using FA.JustBlog.AutoMapperConfig;
using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Core.Repositories.Implement;
using FA.JustBlog.Core.Services;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FA.JustBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterAutofac();
            AutoMapperRegister();
        }

        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterSource(new ViewRegistrationSource());

            // manual registration of types;
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<Repository<Category>>().As<IRepository<Category>>();
            builder.RegisterType<Repository<Comment>>().As<IRepository<Comment>>();
            builder.RegisterType<Repository<Post>>().As<IRepository<Post>>();
            builder.RegisterType<Repository<Tag>>().As<IRepository<Tag>>();
            builder.RegisterType<PostService>().As<IPostService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<TagService>().As<ITagService>();
            builder.RegisterType<JustBlogContext>();

            // For property injection using Autofac
            // builder.RegisterType<QuoteService>().PropertiesAutowired();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void AutoMapperRegister()
        {
            new AutoMapperStartupTask().Execute();
        }
    }
}
