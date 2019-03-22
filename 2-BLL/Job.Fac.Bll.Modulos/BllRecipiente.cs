using System;
using Job.Fac.Bll.Nucleo.Servico.EnvioEmail;
using Job.Fac.Bll.Servicos.EnvioEmail;
using Job.Fac.Cul.EmailSmtp;
using Job.Fac.Cul.EmailSmtp.EnvioEmail;
using SimpleInjector;
using Job.Fac.Bll.Modelo.Servicos;
using Job.Fac.Bll.Modelo.Servicos.Contexto;
using Job.Fac.Bll.Modelo.Servicos.Candidato;
using Job.Fac.Modelo.Servico.Formatacao;
using Job.Fac.Bll.Modelo.Servicos.Formatacao;
using Job.Fac.Bll.Candidato;
using Job.Fac.Dao.Candidato;
using Job.Fac.Dao.EntityFramework.Candidato;
using System.Data.Entity;
using Job.Fac.Dao.EntityFramework.Contexto;
using Job.Fac.Bll.Nucleo.Base;
using Job.Fac.Bll.Modelo.Candidato.Contato;

namespace Job.Fac.Bll.Modulos
{
    public class BllRecipiente : Container
    {
        private IConfiguracaoEmail configSmtp;

        public BllRecipiente()
        {
            Register(() => configSmtp?? new ConfiguracaoSmtp());

            // Register<IEnvioEmailServico,EnvioEmailSmtp>(()=>new EnvioEmailSmtp(configSmtp,new ValidadorEmailServico()));

            Register<IEnvioEmailServico, EnvioEmailSmtp>();

            Register<IValidadorEmailServico, ValidadorEmailServico>(Lifestyle.Singleton);

            Register<IServicoContexto, ServicoContexto>(Lifestyle.Singleton);

            Register<IFormatacaoTextoServico, FormatacaoTextoRegexServico>(Lifestyle.Singleton);

            Register<IValidadorNomeServico, ValidadorNomeServico>(Lifestyle.Singleton);

            var registro = Lifestyle.Singleton.CreateRegistration<ContatoBll>(this);

            AddRegistration(typeof(IBaseBll<Contato>), registro);

            AddRegistration(typeof(IContatoBll), registro);

            registro = Lifestyle.Singleton.CreateRegistration<ContatoDaoEf>(this);

            AddRegistration(typeof(IContatoDao), registro);

            AddRegistration(typeof(IBaseDao<Contato>), registro);

            Register<DbContext, FacContexto>(Lifestyle.Singleton);

            Verify();
        }

        public void ConfiguraEmail(IConfiguracaoEmail configSmtp)
        {
            if (configSmtp == null)
                throw new ArgumentNullException("Deve ser informada as configurações de e-mail.");
            this.configSmtp = configSmtp;
        }
    }
}
