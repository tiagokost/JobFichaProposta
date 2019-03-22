using Job.Fac.Bll.Modelo.Candidato.Contato;
using System.Web.Mvc;
using Job.Fac.Bll.Nucleo.Fabrica;
using Job.Fac.Ui.Web.Models;
using AutoMapper;

namespace Job.Fac.Ui.Web.Controllers
{
    public class ContatoController : Job.Fac.Ui.Nucleo.Mvc.Base.BaseControlador<Contato,ContatoModeloVisao>
    {
        public ContatoController(IBllFabrica bllFabrica,IMapper mapeador) : base(bllFabrica,mapeador)
        {
        }

        // GET: Contato
        public ActionResult Index()
        {
            return View();
        }

        protected override Contato MapearModeloVisaoParaModeloBll(ContatoModeloVisao o)
        {
            return new Contato(o.Nome, o.Telefone, o.Email, bllFabrica.ServicoContexto);
        }
    }
}