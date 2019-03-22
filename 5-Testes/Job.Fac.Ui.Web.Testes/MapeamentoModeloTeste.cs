using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Job.Fac.Ui.Web.Models;
using Job.Fac.Bll.Modelo.Candidato.Contato;
using AutoMapper;
using Job.Fac.Ui.Web.Mapeamento;

namespace Job.Fac.Ui.Web.Testes
{
    [TestClass]
    public class MapeamentoModeloTeste
    {
        private readonly IMapper mapeador;

        public MapeamentoModeloTeste()
        {
            mapeador = criaMapeamento();
        }

        IMapper criaMapeamento()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModeloVisaModeloBllPerfil("perfil1"));
            });

            return config.CreateMapper();
        }

        [TestMethod]
        public void Converte_ContatoModeloVisao_Em_Contato()
        {
            var contatoModeloVisao = new ContatoModeloVisao
            {
                Email = "email@email.com",
                Id = Guid.NewGuid(),
                Nome = "EXEMPLO",
                Telefone = "(28)99923-9392"
            };

            Contato contato = mapeador.Map<Contato>(contatoModeloVisao);

            Assert.AreEqual(contatoModeloVisao.Id, contato.Id);

            Assert.AreEqual(contatoModeloVisao.Email, contato.Email);

            Assert.AreEqual(contatoModeloVisao.Nome, contato.Nome);

            Assert.AreEqual(contatoModeloVisao.Telefone, contato.Telefone);
        }
    }
}
