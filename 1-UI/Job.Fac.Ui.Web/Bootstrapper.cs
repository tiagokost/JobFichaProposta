using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Job.Fac.Bll.Modulos;
using Job.Fac.Bll.Nucleo.Fabrica;
using Job.Fac.Bll.Fabrica;
using Job.Fac.Ui.Web.Mapeamento;
using AutoMapper;
using Job.Fac.Ui.Web.Models;
using Job.Fac.Bll.Modelo.Candidato.Contato;

namespace Job.Fac.Ui.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterInstance(typeof(BllRecipiente),
                new BllRecipiente());

            container.RegisterType<IBllFabrica, BllFabrica>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModeloVisaModeloBllPerfil("perfil1"));
            });

            IMapper mapeador = config.CreateMapper();

            container.RegisterInstance(typeof(IMapper), mapeador);

            return container;
        }
    }
}