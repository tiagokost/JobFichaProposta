using AutoMapper;
using Job.Fac.Bll.Excecoes;
using Job.Fac.Bll.Modelo.Base.Argus.Modelo.Nucleo;
using Job.Fac.Bll.Modelo.Excecoes;
using Job.Fac.Bll.Nucleo.Fabrica;
using System;
using System.Web.Mvc;

namespace Job.Fac.Ui.Nucleo.Mvc.Base
{
    public class BaseControlador<TObjetoBase,TModeloVisao> : Controller where TObjetoBase : ObjetoBase
    {
        protected readonly IBllFabrica bllFabrica;
        private readonly IMapper mapeador;
        private Mensagem[] mensagens;

        public BaseControlador(IBllFabrica bllFabrica,IMapper mapeador)
        {
            this.mapeador = mapeador;
            this.bllFabrica = bllFabrica;
        }

        [HttpGet]
        public virtual ActionResult ObterTodos()
        {
            try
            {
                var todos = bllFabrica.InstanciaBll<TObjetoBase>().ObterTodos();
                return View("Index",todos);
            }
            catch (Exception ex)
            {
                return View("Index", ex.Message);
            }
        }

        [HttpGet]
        public virtual ActionResult Obter(Guid id)
        {
            try
            {
                return View("Index", bllFabrica.InstanciaBll<TObjetoBase>().Obter(id));
            }
            catch (Exception ex)
            {
                return View("Index", ex.Message);
            }
        }

        [HttpPost]
        public virtual ActionResult Registrar(TModeloVisao o)
        {
            try
            {
                TObjetoBase obj = MapearModeloVisaoParaModeloBll(o);

                bllFabrica.InstanciaBll<TObjetoBase>().Registrar(obj);

                bllFabrica.InstanciaBll<TObjetoBase>().ConfirmarAtualizacoes();

                mensagens = Mensagens.Sucesso("Seu contato foi registrado. Aguarde novidades!");

                ViewBag.Mensagens = mensagens;

                return View("Index",Activator.CreateInstance<TModeloVisao>());
            }
            catch(BllExcecao ex)
            {
                mensagens = Mensagens.MontarMensagemComExcecoes(ex);

                ViewBag.Mensagens = mensagens;

                return View("Index");
            }
            catch(ModeloInvalidoExcecao ex){
                ViewBag.Mensagens = Mensagens.MontarMensagemComExcecoes(ex);
                return View("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public virtual ActionResult Modificar(TObjetoBase o)
        {
            try
            {
                bllFabrica.InstanciaBll<TObjetoBase>().Modificar(o);
                bllFabrica.InstanciaBll<TObjetoBase>().ConfirmarAtualizacoes();
                return View("Index");
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        [HttpDelete]
        public virtual ActionResult Deletar(Guid id)
        {
            try
            {
                bllFabrica.InstanciaBll<TObjetoBase>().Excluir(id);
                bllFabrica.InstanciaBll<TObjetoBase>().ConfirmarAtualizacoes();
                return View("Index");
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        protected virtual TObjetoBase MapearModeloVisaoParaModeloBll(TModeloVisao o)
        {
            return mapeador.Map<TObjetoBase>(o);
        }

        protected virtual TModeloVisao MapearModeloBllParaModeloVisao(TObjetoBase o)
        {
            return mapeador.Map<TModeloVisao>(o);
        }
    }
}
