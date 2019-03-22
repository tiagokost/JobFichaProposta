namespace Job.Fac.Bll.Modelo.Servicos.Candidato
{
    public interface IValidadorServico<T>
    {
        bool Valido { get; }

        IValidadorServico<T> Valida(T o);
    }
}