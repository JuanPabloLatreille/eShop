using Application.Clientes.Queries;
using FluentValidation;

namespace Application.Clientes.Validators;

public class ObterClienteQueryValidator : AbstractValidator<ObterClienteQuery>
{
    public ObterClienteQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("É obrigatório informar um Id");
    }
}