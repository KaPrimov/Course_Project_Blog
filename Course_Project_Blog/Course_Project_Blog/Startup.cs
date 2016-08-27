using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Course_Project_Blog.Startup))]
namespace Course_Project_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
