using Job.Fac.Modelo.Servico.Formatacao;
using System.Text.RegularExpressions;

namespace Job.Fac.Bll.Modelo.Servicos.Formatacao
{
    public class FormatacaoTextoRegexServico : IFormatacaoTextoServico
    {
        public string RemoverCaracteresEspeciais(string str)
        {
            return Regex.Replace(str, "[^0-9a-zA-Z]+", ""); 
        }
    }
}
