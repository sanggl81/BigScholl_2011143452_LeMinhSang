using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BigScholl_2011143452_LeMinhSang.Startup))]
namespace BigScholl_2011143452_LeMinhSang
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
