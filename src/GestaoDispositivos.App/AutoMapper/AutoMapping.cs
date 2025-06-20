using AutoMapper;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Entities.Enums;

namespace GestaoDispositivos.App.AutoMapper;

public class AutoMapping: Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestEvento, Evento>();
        CreateMap<RequestDispositivo, Dispositivo>();
        CreateMap<RequestAdmin, Admin>()
            .ForMember(dest => dest.Senha, opt => opt.Ignore());
    
    CreateMap<RequestCliente, Cliente>()
            .ForMember(dest => dest.Senha, opt => opt.Ignore());
        }

    private void EntityToResponse()
    {
        CreateMap<Evento, ResponseEvento>();

        CreateMap<Dispositivo, ResponseDispositivo>();

        CreateMap<Cliente, ResponseUser>();
        CreateMap<Admin, ResponseUser>();
        CreateMap<Admin, ResponseClientes>();
        CreateMap<Cliente, ResponseClienteProfile>();
    }
}
