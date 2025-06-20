using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Entities.Enums;
namespace GestaoDispositivos.Communication.Responses;

public class EventosByTipo
{
    public Tipos Tipo { get; set; } = default!;
    public List<Evento> Eventos { get; set; } = new();
}

