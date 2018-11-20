
using FluentValidation;

namespace WebApplication3.MediatrExperiment
{
    public class PingRequestValidator : AbstractValidator<Ping>
    {
        public PingRequestValidator()
        {
            RuleFor(x => x.SomeProp).NotNull();
        }
    }
}