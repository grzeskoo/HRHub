using AutoMapper;
using HRHub_API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRHub_API.Models.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        { 
        CreateMap<reg_eu_Termination, reg_eu_TerminationDTO >().ReverseMap();
        CreateMap<reg_eu_Sector, reg_eu_SectorDTO>().ReverseMap();
        CreateMap<reg_eu_Sector, reg_eu_SectorCreateDTO>().ReverseMap();
        CreateMap<reg_eu_Sector, reg_eu_SectorUpdateDTO>().ReverseMap();
        CreateMap<reg_eu_Sector, reg_eu_SectorDeleteDTO>().ReverseMap();
        }
    }
}
 