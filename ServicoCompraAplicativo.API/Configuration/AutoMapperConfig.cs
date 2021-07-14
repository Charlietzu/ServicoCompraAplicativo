using AutoMapper;
using ServicoCompraAplicativo.API.Requests;
using ServicoCompraAplicativo.Dominio.Models;

namespace ServicoCompraAplicativo.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ClienteModel, ClienteRequest>().ReverseMap();
        }
    }
}
