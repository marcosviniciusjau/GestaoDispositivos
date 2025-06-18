﻿namespace GestaoDispositivos.Domain.Security;
public interface IPasswordEncripter
{
    string Encrypt(string password);
    bool Verify(string password, string passwordHash);
}
