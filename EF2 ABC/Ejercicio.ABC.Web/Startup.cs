using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ejercicio.ABC.Web.Startup))]
namespace Ejercicio.ABC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
