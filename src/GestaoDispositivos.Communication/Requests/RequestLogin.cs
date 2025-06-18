namespace GestaoDispositivos.Communication.Requests
{
    public class RequestLogin
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
