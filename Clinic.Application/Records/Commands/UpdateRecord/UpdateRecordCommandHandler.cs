using Clinic.Application.Common.Exceptions;
using Clinic.Application.Interfaces;
using Clinic.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Application.Records.Commands.UpdateRecord
{
    public class UpdateRecordCommandHandler : IRequestHandler<UpdateRecordCommand>
    {
        private readonly IApplicationDbContext _db;
        public UpdateRecordCommandHandler(IApplicationDbContext db) =>
            _db = db;
        public async Task<Unit> Handle(UpdateRecordCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Records.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Record), request.Id);
            }
            entity.Title = request.Title;
            entity.Date = request.Date;
            entity.Description = request.Description;
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
