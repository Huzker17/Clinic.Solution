using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clinic.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Application.Records.Queries.GetRecordList
{
    public class GetRecordListQueryHandler : IRequestHandler<GetRecordListQuery, RecordListVm>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetRecordListQueryHandler(IApplicationDbContext db, IMapper mapper) => (_db, _mapper) = (db, mapper);

        public async Task<RecordListVm> Handle(GetRecordListQuery request, CancellationToken cancellationToken)
        {
            var recordsQuery = await _db.Records.Where(x => x.UserId == request.UserId)
                                                .ProjectTo<RecordLookupDto>(_mapper.ConfigurationProvider)
                                                .ToListAsync();
            return new RecordListVm { Records = recordsQuery }; 

        }
    }
}
