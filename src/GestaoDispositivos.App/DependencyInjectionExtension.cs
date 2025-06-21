using GestaoDispositivos.App.AutoMapper;
using GestaoDispositivos.App.Validations.Admin.Register;
using GestaoDispositivos.App.Validations.Clientes.Delete;
using GestaoDispositivos.App.Validations.Dispositivos.Delete;
using GestaoDispositivos.App.Validations.Dispositivos.GetAll;
using GestaoDispositivos.App.Validations.Dispositivos.Register;
using GestaoDispositivos.App.Validations.Dispositivos.Update;
using GestaoDispositivos.App.Validations.Eventos.Delete;
using GestaoDispositivos.App.Validations.Eventos.GetAll;
using GestaoDispositivos.App.Validations.Eventos.Register;
using GestaoDispositivos.App.Validations.Eventos.Update;
using GestaoDispositivos.App.Validations.Login;

using Microsoft.Extensions.DependencyInjection;
using GestaoDispositivos.App.Validations.Admin.GetAllClientes;
using GestaoDispositivos.App.Validations.Clientes.ChangePassword;
using GestaoDispositivos.App.Validations.Clientes.Update;
using GestaoDispositivos.App.Validations.Clientes.GetProfile;
using GestaoDispositivos.App.Validations.Clientes.Register;
using GestaoDispositivos.App.Validations.LoginAdmin;
namespace GestaoDispositivos.App;

public static class DependencyInjectionExtension
{
    public static void AddApp(this IServiceCollection services)
    {
       AddAutoMapper(services);

       AddValidations(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddValidations(IServiceCollection services)
    {
         services.AddScoped<IRegisterAdminValidation, RegisterAdminValidation>();
         services.AddScoped<IGetAllClientesValidation, GetAllClientesValidation>();
       
        services.AddScoped<IRegisterClienteValidation, RegisterClienteValidation>();
        services.AddScoped<IGetProfileValidation, GetProfileValidation>();
        services.AddScoped<IUpdateProfileValidation, UpdateProfileValidation>();

        services.AddScoped<IChangePasswordValidation, ChangePasswordValidation>();
  
        services.AddScoped<IRegisterDispositivoValidation, RegisterDispositivoValidation>();
        services.AddScoped<IGetAllDispositivosValidation, GetAllDispositivosValidation>();
        services.AddScoped<IUpdateDispositivoValidation, UpdateDispositivoValidation>();
        services.AddScoped<IDeleteDispositivoValidation, DeleteDispositivoValidation>();

        services.AddScoped<IRegisterEventoValidation, RegisterEventoValidation>();
        services.AddScoped<IGetAllEventosValidation, GetAllEventosValidation>();
        services.AddScoped<IUpdateEventoValidation, UpdateEventoValidation>();
        services.AddScoped<IDeleteEventoValidation, DeleteEventoValidation>();

        services.AddScoped<ILoginValidation, LoginValidation>();
        services.AddScoped<ILoginValidationAdmin, LoginValidationAdmin>();

    }

}
