using Job.Fac.Bll.Modelo.Candidato.Contato;
using Job.Fac.Bll.Servicos.EnvioEmail;

namespace Job.Fac.Bll.Nucleo.Servico.EnvioEmail
{
    public interface IEnvioEmailServico
    {
        IConfiguracaoEmail Configuracao { get; set; }

        void EnviarEmail(string nomeRemetente, string emailRemetente, Contato contatoDestinatario);
    }
}