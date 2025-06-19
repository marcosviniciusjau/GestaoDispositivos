using GestaoDispositivos.App.AutoMapper;
using GestaoDispositivos.App.Validations.Dispositivo.Register;
using GestaoDispositivos.App.Validations.Dispositivos.Register;
using GestaoDispositivos.App.Validations.Eventos.Register;
using GestaoDispositivos.App.Validations.Login;
using GestaoDispositivos.App.Validations.Users.ChangePassword;
using GestaoDispositivos.App.Validations.Users.Delete;
using GestaoDispositivos.App.Validations.Users.GetProfile;
using GestaoDispositivos.App.Validations.Users.Register;
using GestaoDispositivos.App.Validations.Users.Update;
using Microsoft.Extensions.DependencyInjection;

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
         services.AddScoped<IRegistrarClienteValidation, RegistrarClienteValidation>();
      

        services.AddScoped<IRegisterDispositivoValidation, RegisterDispositivoValidation>();
        services.AddScoped<IRegisterEventoValidation, RegisterEventoValidation>();

        services.AddScoped<ILoginValidation, LoginValidation>();

        services.AddScoped<IGetProfileValidation, GetProfileValidation>();
        services.AddScoped<IUpdateProfileValidation, UpdateProfileValidation>();
        services.AddScoped<IChangePasswordValidation, ChangePasswordValidation>();
        services.AddScoped<IDeleteProfileValidation, DeleteProfileValidation>();
    }
    
}
