using Job.Fac.Bll.Modelo.Base.Argus.Modelo.Nucleo;
using Job.Fac.Bll.Modelo.Servicos.Contexto;
using Job.Fac.Bll.Nucleo.Base;
using Job.Fac.Bll.Nucleo.Servico.EnvioEmail;
using Job.Fac.Bll.Servicos.EnvioEmail;

namespace Job.Fac.Bll.Nucleo.Fabrica
{
    public interface IBllFabrica
    {
        IServicoContexto ServicoContexto { get; }

        IEnvioEmailServico EnvioDeEmailServico(IConfiguracaoEmail configSmtp);
        IBaseBll<T> InstanciaBll<T>() where T: ObjetoBase;
    }
}