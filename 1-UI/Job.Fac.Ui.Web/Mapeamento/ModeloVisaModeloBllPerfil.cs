using AutoMapper;
using Job.Fac.Bll.Modelo.Candidato.Contato;
using Job.Fac.Ui.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.Configuration;

namespace Job.Fac.Ui.Web.Mapeamento
{

    public class ModeloVisaModeloBllPerfil : Profile
    {

        //public ModeloVisaModeloBllPerfil(Action<IMapperConfigurationExpression> action)
        //    :base(action)
        //{

        //}
        //public ModeloVisaModeloBllPerfil(MapperConfigurationExpression configurationExpression) 
        //    : base(configurationExpression)
        //{
        //    configurationExpression.CreateMap<ContatoModeloVisao, Contato>()
        //                            .ForMember(p => p.NomeInterno, x => x.Ignore())
        //                            .ForMember(p => p.Ativo, x => x.Ignore())
        //                            .ForMember(p => p.DataAlteracao, x => x.Ignore())
        //                            .ForMember(p => p.DataCadastro, x => x.Ignore())
        //                            .ForMember(p => p.Excluido, x => x.Ignore());

        //    configurationExpression.CreateMap<Contato, ContatoModeloVisao>();
        //}
        public ModeloVisaModeloBllPerfil(string profileName) : base(profileName)
        {
            CreateMap<ContatoModeloVisao, Contato>()
                                    .ForMember(p => p.NomeInterno, x => x.Ignore())
                                    .ForMember(p => p.Ativo, x => x.Ignore())
                                    .ForMember(p => p.DataAlteracao, x => x.Ignore())
                                    .ForMember(p => p.DataCadastro, x => x.Ignore())
                                    .ForMember(p => p.Excluido, x => x.Ignore());

            CreateMap<Contato, ContatoModeloVisao>();
        }
    }
}