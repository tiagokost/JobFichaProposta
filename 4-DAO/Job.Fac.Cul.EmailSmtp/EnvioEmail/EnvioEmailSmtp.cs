using System;
using Job.Fac.Bll.Modelo.Candidato.Contato;
using Job.Fac.Bll.Nucleo.Servico.EnvioEmail;
using Job.Fac.Bll.Servicos.EnvioEmail;
using Job.Fac.Bll.Modelo.Servicos.Candidato;
using Job.Fac.Bll.Excecoes;

namespace Job.Fac.Cul.EmailSmtp.EnvioEmail
{
    public class EnvioEmailSmtp : IEnvioEmailServico
    {
        private readonly IValidadorEmailServico validadorEmailServico;

        public EnvioEmailSmtp(IConfiguracaoEmail configuracao,IValidadorEmailServico validadorEmail)
        {
            this.validadorEmailServico = validadorEmail;
            if (configuracao == null)
                throw new ArgumentNullException("Não foram definidas as configurações 'SMTP' para envio de email.");
            this.Configuracao = configuracao;
        }
        public IConfiguracaoEmail Configuracao
        {
            get;
            set;
        }

        public void EnviarEmail(string nomeRemetente, string emailRemetente, Contato contatoDestinatario)
        {
            if (contatoDestinatario == null)
                throw new ArgumentNullException("Informe um contato para que seja enviado o e-mail.");

            validadorEmailServico.Valida(emailRemetente);

            throw new EnvioDeEmailExcecao();

        }
    }
}
