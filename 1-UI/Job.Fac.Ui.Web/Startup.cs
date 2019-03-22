using AutoMapper;
using Job.Fac.Ui.Web.Mapeamento;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Job.Fac.Ui.Web.Startup))]
namespace Job.Fac.Ui.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
