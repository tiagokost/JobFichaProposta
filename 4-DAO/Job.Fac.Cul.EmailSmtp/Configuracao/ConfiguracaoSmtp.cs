using System;
using Job.Fac.Bll.Servicos.EnvioEmail;

namespace Job.Fac.Cul.EmailSmtp
{
    public class ConfiguracaoSmtp : IConfiguracaoEmail
    {
        public string ServidorSmtp { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int PortaSmtp { get; set; }

        public ConfiguracaoSmtp()
        {

        }

        public ConfiguracaoSmtp(string servidorSmtp, string email, string senha,int portaSmtp)
        {
            this.ServidorSmtp = servidorSmtp;

            if (!ServidorSmtp.Contains("smtp"))
                throw new ArgumentException($"A configuração para o servidor SMTP não está correta.\n{servidorSmtp}");

            this.Email = email;

            if (!Email.Contains("@"))
                throw new ArgumentException("O endereço de e-mail configurado para envio não é válido.");

            this.Senha = senha;
            this.PortaSmtp = portaSmtp;
        }
    }
}