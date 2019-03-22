using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Job.Fac.Bll.Fabrica;
using Job.Fac.Bll.Modulos;
using Job.Fac.Bll.Modelo.Excecoes;

namespace Job.Fac.Bll.Modelo.Testes.Candidato.Servicos
{
    [TestClass]
    public class ValidadorEmailServicoTeste
    {
        [TestMethod]
        public void Testa_Email_Valido()
        {
            var validadorEmail = new BllFabrica(new BllRecipiente()).ServicoContexto.ValidacaoEmailServico;
            Assert.IsTrue(validadorEmail.Valida("tiagokost@gmail.com").Valido);
            Assert.IsTrue(validadorEmail.Valida("tiago.kost@gmail.com").Valido);
            Assert.IsTrue(validadorEmail.Valida("TIAGOKOST@gmail.com").Valido);
            Assert.IsTrue(validadorEmail.Valida("tiago-kost@gmail.com").Valido);
            Assert.IsTrue(validadorEmail.Valida("tiago_kost@gmail.com").Valido);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),AllowDerivedTypes = true)]
        public void Espera_Validacao_De_Um_Email_Incorreto()
        {
            var validadorEmail = new BllFabrica(new BllRecipiente()).ServicoContexto.ValidacaoEmailServico;

            Assert.IsTrue(!validadorEmail.Valida("@gmail.com").Valido);
            Assert.IsFalse(validadorEmail.Valida("tiagogmail.com").Valido);
            Assert.IsFalse(validadorEmail.Valida("tiago@gmail.com@").Valido);
            Assert.IsFalse(validadorEmail.Valida("@tiagogmail.com").Valido);
            Assert.IsFalse(validadorEmail.Valida("@tiago").Valido);
        }
    }
}
