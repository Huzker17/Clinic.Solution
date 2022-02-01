using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Records.Commands.CreateRecord
{
    public class CreateRecordCommandValidator : AbstractValidator<CreateRecordCommand>
    {
        public CreateRecordCommandValidator()
        {
            RuleFor(createRecordCommand =>
                createRecordCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createRecordCommand =>
                createRecordCommand.UserId).NotEqual(Guid.Empty);

        }
    }
}
