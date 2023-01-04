using AutoMapper;
using CRM.Adm.Application.DTOs;
using CRM.Adm.Domain.Entities;

namespace CRM.Adm.Application.Mappings
{
    public class DomainToDTOMappingProfile: Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
