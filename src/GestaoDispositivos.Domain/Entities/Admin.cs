using GestaoDispositivos.Domain.Entities.Enums;
using System;

namespace GestaoDispositivos.Domain.Entities;
public class Admin
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;
}
