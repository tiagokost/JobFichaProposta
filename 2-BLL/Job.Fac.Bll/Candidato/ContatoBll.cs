using System;
using Job.Fac.Bll.Modelo.Candidato.Contato;
using Job.Fac.Bll.Nucleo.Base;

namespace Job.Fac.Bll.Candidato
{
    public class ContatoBll : BaseBll<Contato>, IContatoBll
    {
        public ContatoBll(IBaseDao<Contato> dao)
            :base(dao)
        {
            AntesDeRegistrar += AntesDeRegistrarContato; 
        }

        private Contato AntesDeRegistrarContato(Contato o)
        {
            return o;
        }
    }
}
