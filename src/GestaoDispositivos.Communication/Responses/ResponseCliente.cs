namespace GestaoDispositivos.Communication.Responses;
public class ResponseCliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public bool Status { get; set; }

    public string StatusDescricao => Status ? "Ativo" : "Inativo";

}
