using AutoMapper;
using FluentValidation.Results;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Admin;
using GestaoDispositivos.Domain.Security;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Exception.ExceptionBase;

namespace GestaoDispositivos.App.Validations.Admin.Register;
public class RegisterAdminValidation(
    IMapper mapper,
    IPasswordEncripter passwordEncripter,
    IAdminRead adminReadOnly,
    IAdminCreate adminWrite,
    ITokenGenerator tokenGenerator,
    IUnitOfWork unitOfWork
        ) : IRegisterAdminValidation
{
    private readonly IMapper _mapper = mapper;
    private readonly IPasswordEncripter _passwordEncripter = passwordEncripter;
    private readonly IAdminRead _adminReadOnly = adminReadOnly;
    private readonly IAdminCreate _adminWrite = adminWrite;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

    public async Task<ResponseAdmin> Execute(RequestAdmin request)
    {
        await Validate(request);

        var admin = _mapper.Map<Domain.Entities.Admin>(request);
        admin.Senha = _passwordEncripter.Encrypt(request.Senha);
        admin.Id = Guid.NewGuid();


        await _adminWrite.Add(admin);

        await _unitOfWork.Commit();
        return new ResponseAdmin
        {
            Token = _tokenGenerator.GenerateAdmin(admin)
        };
    }

    private async Task Validate(RequestAdmin request)
    {
        var validator = new AdminValidator();
         var result = validator.Validate(request);

        var exists = await _adminReadOnly.Exists(request.Email);
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