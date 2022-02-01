using AutoMapper;
using Clinic.Application.Common.Mapping;
using Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Records.Queries.GetRecordList
{
    public class RecordLookupDto : IMapWith<Record>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Record, RecordLookupDto>()
                .ForMember(recordDto => recordDto.Id,
                    opt => opt.MapFrom(record => record.Id))
                .ForMember(recordDto => recordDto.Title,
                    opt => opt.MapFrom(record => record.Id));
        }
    }
}
