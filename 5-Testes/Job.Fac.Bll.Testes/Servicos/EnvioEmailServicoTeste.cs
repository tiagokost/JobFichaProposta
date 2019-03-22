using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Job.Fac.Bll.Modelo.Candidato.Contato;
using Job.Fac.Bll.Nucleo.Fabrica;
using Job.Fac.Cul.EmailSmtp;
using Job.Fac.Bll.Servicos.EnvioEmail;
using Job.Fac.Bll.Fabrica;
using Job.Fac.Bll.Modulos;
using Job.Fac.Bll.Excecoes;

namespace Job.Fac.Bll.Testes.Servicos
{
    [TestClass]
    public class EnvioEmailServicoTeste
    {
        private readonly IConfiguracaoEmail configuracaoSmtp;

        public EnvioEmailServicoTeste()
        {
            this.configuracaoSmtp = new ConfiguracaoSmtp("smtp.gmail.com", "teste@email.com", "12345", 25);

        }
        [TestMethod]
        public void O_Enviador_De_Email_Deve_Possuir_Configuracao_Smtp()
        {
            var bllFabrica = obterBllFabrica();
            IConfiguracaoEmail configuracao = new ConfiguracaoSmtp("smtp.gmail.com", "tiago@email.com", "12345", 21);

            var envioDeEmail = bllFabrica.EnvioDeEmailServico(configuracao);

            Assert.AreEqual("smtp.gmail.com", envioDeEmail.Configuracao.ServidorSmtp);

            Assert.AreEqual("tiago@email.com", envioDeEmail.Configuracao.Email);

            Assert.AreEqual("12345", envioDeEmail.Configuracao.Senha);

            Assert.AreEqual(21, envioDeEmail.Configuracao.PortaSmtp);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void O_Servidor_De_Smtp_Deve_Conter_A_Palavra_Smtp()
        {
            var bllFabrica = obterBllFabrica();

            IConfiguracaoEmail configuracao = new ConfiguracaoSmtp("gmail.com", "tiago@email.com", "12345", 21);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void O_Email_Deve_Ser_Valido()
        {
            var bllFabrica = obterBllFabrica();

            IConfiguracaoEmail configuracao = new ConfiguracaoSmtp("smtp.gmail.com", "tiagoemail.com", "12345", 21);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Informar_Um_Contato_Para_Envio_De_Email()
        {
            obterBllFabrica().EnvioDeEmailServico(configuracaoSmtp).EnviarEmail(
                nomeRemetente: "NomeRemetente", 
                emailRemetente: "email@remente.com", 
                contatoDestinatario: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Informar_Um_Email_Do_Remetente_Valido_Para_Envio_De_Email()
        {
            obterBllFabrica().EnvioDeEmailServico(configuracaoSmtp).EnviarEmail(
                nomeRemetente: "NomeRemetente",
                emailRemetente: "",
                contatoDestinatario: new Contato("tiago da costa","999831108","tiagokost@gmail.com",obterBllFabrica().ServicoContexto));
        }

        [TestMethod]
        [ExpectedException(typeof(EnvioDeEmailExcecao))]
        public void Retorna_Excecao_Para_Email_Nao_Enviado()
        {
            obterBllFabrica().EnvioDeEmailServico(configuracaoSmtp).EnviarEmail(
                nomeRemetente: "NomeRemetente",
                emailRemetente: "teste@email.com",
                contatoDestinatario: new Contato("tiago da costa", "999831108", "tiagokost@gmail.com", obterBllFabrica().ServicoContexto));
        }

        private IBllFabrica obterBllFabrica()
        {
            return new BllFabrica(new BllRecipiente());
        }

        private Contato obterContatoFake()
        {
            return new Contato("TIAGO DA COSTA SILVA", "(28)99983-1108", "tiagokost@gmail.com", obterBllFabrica().ServicoContexto);
        }
    }

}
