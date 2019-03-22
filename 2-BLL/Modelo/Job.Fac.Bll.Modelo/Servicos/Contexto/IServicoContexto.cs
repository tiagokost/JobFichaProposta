using Job.Fac.Bll.Modelo.Servicos.Candidato;
using Job.Fac.Modelo.Servico.Formatacao;

namespace Job.Fac.Bll.Modelo.Servicos.Contexto
{
    public interface IServicoContexto
    {
        IFormatacaoTextoServico FormatacaoTextoServico { get; }
        IValidadorEmailServico ValidacaoEmailServico { get; }
        IValidadorNomeServico ValidacaoCompletoServico { get; }
    }
}