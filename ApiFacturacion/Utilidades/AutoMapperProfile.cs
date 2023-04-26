using ApiFacturacion.DTOS;
using ApiFacturacion.Models;
using AutoMapper;

namespace ApiFacturacion.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteCreacionDTO,Cliente>();


        }
    }
}
