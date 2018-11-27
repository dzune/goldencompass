using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(theMovieDB.Startup))]
namespace theMovieDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
