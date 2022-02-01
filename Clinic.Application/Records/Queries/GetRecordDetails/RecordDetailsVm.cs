using AutoMapper;
using Clinic.Application.Common.Mapping;
using Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Records.Queries.GetRecordDetails
{
    public class RecordDetailsVm : IMapWith<Record>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Record, RecordDetailsVm>()
                .ForMember(recordVm => recordVm.Title,
                    opt => opt.MapFrom(record => record.Title))
                .ForMember(recordVm => recordVm.Description,
                    opt => opt.MapFrom(record => record.Description))
                .ForMember(recordVm => recordVm.Date,
                    opt => opt.MapFrom(record => record.Date))
                .ForMember(recordVm => recordVm.Id,
                    opt => opt.MapFrom(record => record.Id));
        }
    }
}
