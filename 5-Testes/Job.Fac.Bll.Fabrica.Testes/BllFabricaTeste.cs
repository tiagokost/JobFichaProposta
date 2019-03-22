using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Job.Fac.Bll.Nucleo.Fabrica;
using Job.Fac.Bll.Modulos;

namespace Job.Fac.Bll.Fabrica.Testes
{
    [TestClass]
    public class BllFabricaTeste
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Nao_Deve_Criar_Enviador_De_Email_Sem_Configuracao()
        {
            IBllFabrica bllFabrica = new BllFabrica(new BllRecipiente());
            var envio = bllFabrica.EnvioDeEmailServico(null);
        }
    }
}
