﻿namespace GestaoDispositivos.Communication.Requests;
public class RequestUpdateCliente
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
}
