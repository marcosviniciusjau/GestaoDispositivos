﻿using FluentValidation;
using FluentValidation.Validators;
using GestaoDispositivos.Exception;
using System.Text.RegularExpressions;

namespace GestaoDispositivos.App.Validations.Admin;
public class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_MESSAGE = "ErrorMessage";
    public override string Name => "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ERROR_MESSAGE}}}";
    }

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE, ResourceErrorMessages.Password_Invalid);
            return false;
        }
        if(password.Length < 8)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE, ResourceErrorMessages.Password_Invalid);
            return false;
        }
        if (Regex.IsMatch(password, @"[A-Z]") == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE, ResourceErrorMessages.Password_Invalid);
            return false;
        }
        if (Regex.IsMatch(password, @"[a-z]") == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE, ResourceErrorMessages.Password_Invalid);
            return false;
        } 
        if (Regex.IsMatch(password, @"[0-9]") == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE, ResourceErrorMessages.Password_Invalid);
            return false;
        } 
        if (Regex.IsMatch(password, @"[\!\?\*\.\@^]+") == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE, ResourceErrorMessages.Password_Invalid);
            return false;
        }
        return true;
    }
}
