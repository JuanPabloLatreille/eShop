using Application.Clientes.Commands;
using FluentValidation;

namespace Application.Clientes.Validators;

public class DeletarClienteCommandValidator : AbstractValidator<DeletarClienteCommand>
{
    public DeletarClienteCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("É obrigatório informar um Id");
    }
}