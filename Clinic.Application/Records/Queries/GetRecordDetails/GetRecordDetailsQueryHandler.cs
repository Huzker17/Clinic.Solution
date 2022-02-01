using AutoMapper;
using Clinic.Application.Common.Exceptions;
using Clinic.Application.Interfaces;
using Clinic.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Application.Records.Queries.GetRecordDetails
{
    public class GetRecordDetailsQueryHandler : IRequestHandler<GetRecordDetailsQuery, RecordDetailsVm>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetRecordDetailsQueryHandler(IApplicationDbContext db, IMapper mapper) => (_db,_mapper) = (db, mapper);
        public async Task<RecordDetailsVm> Handle(GetRecordDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _db.Records.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
                throw new NotFoundException(nameof(Record), request.Id);
            return _mapper.Map<RecordDetailsVm>(entity);
        }
    }
}
