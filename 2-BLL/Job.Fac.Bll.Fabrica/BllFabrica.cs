using System;
using Job.Fac.Bll.Modelo.Candidato.Contato;
using Job.Fac.Bll.Nucleo.Fabrica;
using Job.Fac.Bll.Nucleo.Servico.EnvioEmail;
using Job.Fac.Bll.Servicos.EnvioEmail;
using SimpleInjector;
using Job.Fac.Bll.Modulos;
using Job.Fac.Bll.Modelo.Servicos.Contexto;
using Job.Fac.Bll.Modelo.Base.Argus.Modelo.Nucleo;
using Job.Fac.Bll.Nucleo.Base;

namespace Job.Fac.Bll.Fabrica
{
    public class BllFabrica : IBllFabrica
    {
        private readonly BllRecipiente recipiente;

        public BllFabrica(BllRecipiente recipiente)
        {
            this.recipiente = recipiente;
        }

        public IServicoContexto ServicoContexto
        {
            get
            {
                return recipiente.GetInstance<IServicoContexto>();
            }
        }

        public IEnvioEmailServico EnvioDeEmailServico(IConfiguracaoEmail configSmtp)
        {
            recipiente.ConfiguraEmail(configSmtp);
            return recipiente.GetInstance<IEnvioEmailServico>();
        }

        public T Instancia<T>() where T:class
        {
            return recipiente.GetInstance<T>();
        }

        public IBaseBll<T> InstanciaBll<T>() where T : ObjetoBase
        {
            return recipiente.GetInstance<IBaseBll<T>>();
        }
    }
}
