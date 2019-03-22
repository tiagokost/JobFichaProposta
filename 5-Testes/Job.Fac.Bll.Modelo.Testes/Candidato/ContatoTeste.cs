using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Job.Fac.Bll.Nucleo.Fabrica;
using Job.Fac.Bll.Fabrica;
using Job.Fac.Bll.Modelo.Excecoes;
using Job.Fac.Bll.Modelo.Candidato.Contato;

namespace Job.Fac.Bll.Modelo.Testes
{
    [TestClass]
    public class ContatoTeste
    {
        private IBllFabrica bllFabrica;
        public ContatoTeste()
        {
            this.bllFabrica = new BllFabrica(new Modulos.BllRecipiente());
        }
        [TestMethod]
        public void O_Contato_Do_Candidato_Deve_Possuir_Email_Telefone_E_Nome()
        {
            var contato = obterContatoFake();
            Assert.IsTrue(contato.Nome.Equals("TIAGO DA COSTA SILVA"));
            Assert.IsTrue(contato.Telefone.Equals("28999831108"));
            Assert.IsTrue(contato.Email.Equals("tiagokost@gmail.com"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Valida_Se_Existe_Um_Contexto_De_Validacao_No_Contato()
        {
            var contato = new Contato(null);
        }

        [TestMethod]
        public void Remove_Formatacao_Do_Telefone()
        {
            var contato = new Contato("tiago da costa", "(28)99983-1108", "tiagokost@gmail.com", bllFabrica.ServicoContexto);
            Assert.AreEqual("28999831108", contato.Telefone);
        }

        [TestMethod]
        [ExpectedException(typeof(ModeloInvalidoExcecao))]
        public void Não_Aceitar_Um_Contato_Apenas_Com_Ò_Primeiro_Nome()
        {
            var contato = new Contato("tiago", "(28)99983-1108", "tiagokost@gmail.com", bllFabrica.ServicoContexto);
        }

        [TestMethod]
        public void Contato_Com_Numero_De_Telefone()
        {
            var contato = new Contato();
            contato.Telefone = "(28)999258710";

            Assert.AreEqual("(28)999258710", contato.Telefone);
        }
        private Contato obterContatoFake()
        {
            return new Contato("TIAGO DA COSTA SILVA", "(28)99983-1108", "tiagokost@gmail.com", bllFabrica.ServicoContexto);
        }
    }
}
