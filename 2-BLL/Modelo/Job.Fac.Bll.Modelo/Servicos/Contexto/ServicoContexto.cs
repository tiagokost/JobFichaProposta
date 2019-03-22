using System;
using Job.Fac.Bll.Modelo.Servicos.Candidato;
using Job.Fac.Modelo.Servico.Formatacao;

namespace Job.Fac.Bll.Modelo.Servicos.Contexto
{
    public class ServicoContexto : IServicoContexto
    {
        private readonly IValidadorEmailServico validacaoEmailServico;
        private readonly IFormatacaoTextoServico formatacaoTextoServico;
        private readonly IValidadorNomeServico validadorNomeServico;

        public ServicoContexto(
            IValidadorEmailServico validadorEmailServico,
            IFormatacaoTextoServico formatacaoTextoServico,
            IValidadorNomeServico validadorNomeServico)
        {
            this.validadorNomeServico = validadorNomeServico;
            this.formatacaoTextoServico = formatacaoTextoServico;
            this.validacaoEmailServico = validadorEmailServico;
        }
        public IValidadorEmailServico ValidacaoEmailServico
        {
            get
            {
                return validacaoEmailServico;
            }
        }

        public IFormatacaoTextoServico FormatacaoTextoServico
        {
            get
            {
                return formatacaoTextoServico;
            }
        }

        public IValidadorNomeServico ValidacaoCompletoServico
        {
            get
            {
                return validadorNomeServico;
            }
        }
    }
}
