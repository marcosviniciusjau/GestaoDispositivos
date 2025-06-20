using GestaoDispositivos.App.AutoMapper;
using GestaoDispositivos.App.Validations.Admin.GetAll;
using GestaoDispositivos.App.Validations.Admin.Register;
using GestaoDispositivos.App.Validations.Cliente.Register;
using GestaoDispositivos.App.Validations.Clientes.Delete;
using GestaoDispositivos.App.Validations.Dispositivo.Register;
using GestaoDispositivos.App.Validations.Dispositivos.Delete;
using GestaoDispositivos.App.Validations.Dispositivos.GetAll;
using GestaoDispositivos.App.Validations.Dispositivos.Register;
using GestaoDispositivos.App.Validations.Dispositivos.Update;
using GestaoDispositivos.App.Validations.Eventos.GetAll;
using GestaoDispositivos.App.Validations.Eventos.Register;
using GestaoDispositivos.App.Validations.Eventos.Update;
using GestaoDispositivos.App.Validations.Login;
using GestaoDispositivos.App.Validations.Users.ChangePassword;
using GestaoDispositivos.App.Validations.Users.GetProfile;
using GestaoDispositivos.App.Validations.Users.Update;
using Microsoft.Extensions.DependencyInjection;
using IUpdateDispositivoValidation = GestaoDispositivos.App.Validations.Dispositivos.Update.IUpdateDispositivoValidation;
using UpdateDispositivoValidation = GestaoDispositivos.App.Validations.Dispositivos.Update.UpdateDispositivoValidation;

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
        services.AddScoped<IDeleteDispositivoValidation, DeleteDispositivoValidation>();

     

        services.AddScoped<IRegisterDispositivoValidation, RegisterDispositivoValidation>();
        services.AddScoped<IGetAllDispositivosValidation, GetAllDispositivosValidation>();
        services.AddScoped<IUpdateDispositivoValidation, UpdateDispositivoValidation>();
        services.AddScoped<IDeleteDispositivoValidation, DeleteDispositivoValidation>();

        services.AddScoped<IRegisterEventoValidation, RegisterEventoValidation>();
        services.AddScoped<IGetAllEventosValidation, GetAllEventosValidation>();
        services.AddScoped<IUpdateEventoValidation, UpdateEventoValidation>();
        services.AddScoped<IDeleteDispositivoValidation, DeleteDispositivoValidation>();

        services.AddScoped<ILoginValidation, LoginValidation>();

          }
    
}
