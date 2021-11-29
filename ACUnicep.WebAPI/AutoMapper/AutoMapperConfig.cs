using ACUnicep.Domain.Entities;
using ACUnicep.Domain.ViewModels;
using ACUnicep.WebAPI.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACUnicep.WebAPI.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegisterDTO, Usuario>();

            CreateMap<LoginDTO, LoginModel>();

            CreateMap<AtividadeComplementarRequest, AtividadeComplementar>();
        }
    }
}
