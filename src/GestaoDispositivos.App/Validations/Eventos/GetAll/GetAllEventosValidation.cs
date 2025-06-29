﻿using AutoMapper;
using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Repos.Eventos;
using GestaoDispositivos.Domain.Services;

namespace GestaoDispositivos.App.Validations.Eventos.GetAll;

public class GetAllEventosValidation : IGetAllEventosValidation
{
    private readonly IEventoRead _repo;
    private readonly IMapper _mapper;
    private readonly IClienteLogado _loggedUser;
    public GetAllEventosValidation(
        IEventoRead repo,
        IMapper mapper,
        IClienteLogado loggedUser
        )
    {
        _repo = repo;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }
    public async Task<List<EventosByTipo>> Execute()
    {
        var result = await _repo.GetEventsByWeek();
        return result;
    }
    
}
