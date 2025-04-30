using Application.Clientes.Commands;
using FluentValidation;

namespace Application.Clientes.Validators;

public class CriarClienteCommandValidator : AbstractValidator<CriarClienteCommand>
{
    public CriarClienteCommandValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .WithMessage("O Nome do cliente é obrigatório.");

        RuleFor(p => p.Email)
            .NotEmpty()
            .WithMessage("O Email é obrigatório.");
    }
}