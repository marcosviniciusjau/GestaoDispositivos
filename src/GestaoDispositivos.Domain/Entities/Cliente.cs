namespace GestaoDispositivos.Domain.Entities;
public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;
    
    public string? Telefone { get; set; } = string.Empty;
    public bool Status { get; set; }
}
