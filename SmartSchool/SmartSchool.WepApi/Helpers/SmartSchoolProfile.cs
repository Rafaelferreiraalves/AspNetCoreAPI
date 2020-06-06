using AutoMapper;
using SmartSchool.WepApi.Dtos;
using SmartSchool.WepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WepApi.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                destino => destino.Nome, opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome }")

                ).ForMember(dest => dest.Idade,
                opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge()));

            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();
        }
    }
}
