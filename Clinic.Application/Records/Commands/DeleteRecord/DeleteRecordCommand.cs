using MediatR;
using System;

namespace Clinic.Application.Records.Commands.DeleteRecord
{
    public class DeleteRecordCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
