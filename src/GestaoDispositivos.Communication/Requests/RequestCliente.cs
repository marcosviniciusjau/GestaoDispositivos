namespace GestaoDispositivos.Communication.Requests;
public class RequestCliente
{
    public required string Nome { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public required string Email { get; set; }
    public required string Senha { get; set; }
}
