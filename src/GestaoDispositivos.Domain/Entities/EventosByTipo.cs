using GestaoDispositivos.Domain.Entities.Enums;
namespace GestaoDispositivos.Domain.Entities;

public class EventosByTipo
{
    public Tipos Tipo { get; set; } = default!;
    public int Quantidade { get; set; }
    public List<Evento> Eventos { get; set; } = [];

}

