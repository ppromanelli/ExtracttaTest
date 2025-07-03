using FluentValidation;

namespace ExtracttaTest.Application.Features.SeguroFeatures.Dtos
{
    public class SeguroCreateDtoValidator : AbstractValidator<SeguroCreateDto>
    {
        public SeguroCreateDtoValidator()
        {

            RuleFor(x => x.VeiculoId)
                .NotEmpty().WithMessage("O veiculoId é obrigatório no corpo da mensagem.");

            RuleFor(x => x.SeguradoId)
                .NotEmpty().WithMessage("O seguradoId é obrigatório no corpo da mensagem.");

        }
    }
}
