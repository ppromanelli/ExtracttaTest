using FluentValidation;

namespace ExtracttaTest.Application.Features.SeguradoFeatures.Dtos
{
    internal class SeguradoCreateDtoValidator : AbstractValidator<SeguradoCreateDto>
    {
        public SeguradoCreateDtoValidator()
        {

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(5).WithMessage("O nome deve ter pelo menos 5 caracteres.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O cpf é obrigatório.")
                .MinimumLength(11).WithMessage("O documento deve ter pelo menos 11 caracteres.");

            RuleFor(x => x.Idade)
                .NotEmpty().WithMessage("A idade é obrigatória.")
                .GreaterThanOrEqualTo(18).WithMessage("A idade deve ser maior que 18.");
        }
    }
}
