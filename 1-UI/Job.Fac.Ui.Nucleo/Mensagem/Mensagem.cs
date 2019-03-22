using Job.Fac.Ui.Nucleo.Enum;

namespace Job.Fac.Ui.Nucleo
{
    public struct Mensagem
    {
        public TipoDeMensagens TipoDeMensagem;
        public string Codigo;
        public string Texto;

        public Mensagem(string codigo, string message, TipoDeMensagens tipo) : this()
        {
            this.Codigo = codigo;
            this.Texto = message;
            this.TipoDeMensagem = tipo;
        }
        public override string ToString()
        {
            return Texto;
        }
    }
}
