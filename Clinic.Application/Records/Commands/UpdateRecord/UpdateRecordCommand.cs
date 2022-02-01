using MediatR;
using System;

namespace Clinic.Application.Records.Commands.UpdateRecord
{
    public class UpdateRecordCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
