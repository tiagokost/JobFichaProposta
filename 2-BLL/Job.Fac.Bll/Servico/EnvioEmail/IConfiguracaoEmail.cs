namespace Job.Fac.Bll.Servicos.EnvioEmail
{
    public interface IConfiguracaoEmail
    {
        string ServidorSmtp { get; }
        string Email { get; set; }
        string Senha { get; set; }
        int PortaSmtp { get; set; }
    }
}