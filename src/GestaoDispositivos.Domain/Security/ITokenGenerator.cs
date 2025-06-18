using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Domain.Security
{
    public interface ITokenGenerator
    {
        string Generate(Cliente cliente);
    }
}
