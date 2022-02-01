using Clinic.Application.Interfaces;
using Clinic.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Application.Records.Commands.CreateRecord
{
    public class CreateRecordCommandHandler : IRequestHandler<CreateRecordCommand, Guid>
    {
        private readonly IApplicationDbContext _db;

        public CreateRecordCommandHandler(IApplicationDbContext db) =>
            _db = db;


        public async Task<Guid> Handle(CreateRecordCommand request,CancellationToken cancellationToken)
        {
            var record = new Record
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                Date = request.Date,
                Description = request.Description,
                Title = request.Title
            };
            await _db.Records.AddAsync(record);
            await _db.SaveChangesAsync(cancellationToken);
            return record.Id;
        }
    }
}
