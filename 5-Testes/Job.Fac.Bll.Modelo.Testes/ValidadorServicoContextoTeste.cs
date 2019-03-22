using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Job.Fac.Bll.Modelo.Candidato.Contato;
using Job.Fac.Bll.Fabrica;
using Job.Fac.Bll.Modulos;
using Job.Fac.Bll.Modelo.Servicos;
using Job.Fac.Bll.Modelo.Servicos.Contexto;

namespace Job.Fac.Bll.Modelo.Testes
{
    [TestClass]
    public class ValidadorServicoContextoTeste
    {
        [TestMethod]
        public void Cria_Um_Contato_Contendo_Um_Validador_De_Email()
        {
            var bll = new BllFabrica(new BllRecipiente());

            var validadorContexto = bll.Instancia<IServicoContexto>();

            var contato = new Contato(validadorContexto);
        }
    }
}
