using Clinic.Application.Common.Exceptions;
using Clinic.Application.Interfaces;
using Clinic.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Application.Records.Commands.DeleteRecord
{
    public class DeleteRecordHandler : IRequestHandler<DeleteRecordCommand>
    {
        private readonly IApplicationDbContext _db;

        public DeleteRecordHandler(IApplicationDbContext db) =>
            _db = db;
        public async Task<Unit> Handle(DeleteRecordCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Records.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
                throw new NotFoundException(nameof(Record), request.Id);

            _db.Records.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
