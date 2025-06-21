using AutoMapper;
using FluentValidation.Results;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Clientes;
using GestaoDispositivos.Domain.Security;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Exception.ExceptionBase;

namespace GestaoDispositivos.App.Validations.Clientes.Register;
public class RegisterClienteValidation(
    IMapper mapper,
    IPasswordEncripter passwordEncripter,
    IClienteRead clienteReadOnly,
    IClienteCreate clienteWrite,
    ITokenGenerator tokenGenerator,
    IUnitOfWork unitOfWork
        ) : IRegisterClienteValidation
{
    private readonly IMapper _mapper = mapper;
    private readonly IPasswordEncripter _passwordEncripter = passwordEncripter;
    private readonly IClienteRead _clienteReadOnly = clienteReadOnly;
    private readonly IClienteCreate _clienteWrite = clienteWrite;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

    public async Task<ResponseUser> Execute(RequestCliente request)
    {
        await Validate(request);

        var cliente = _mapper.Map<Domain.Entities.Cliente>(request);
        cliente.Senha = _passwordEncripter.Encrypt(request.Senha);
        cliente.Id = Guid.NewGuid();

        await _clienteWrite.Add(cliente);

        await _unitOfWork.Commit();
        return new ResponseUser
        {
            Token = _tokenGenerator.Generate(cliente)
        };
    }

    private async Task Validate(RequestCliente request)
    {
        var validator = new ClienteValidator();
         var result = validator.Validate(request);

        var exists = await _clienteReadOnly.Exists(request.Email);
        if (exists) {
            result.Errors.Add(new ValidationFailure(string.Empty,ResourceErrorMessages.Email_Exists));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidation(errorMessages);
        }
    }
}