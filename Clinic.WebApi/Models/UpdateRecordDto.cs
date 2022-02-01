using AutoMapper;
using Clinic.Application.Common.Mapping;
using Clinic.Application.Records.Commands.UpdateRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.WebApi.Models
{
    public class UpdateRecordDto : IMapWith<UpdateRecordCommand>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Title {get;set;}
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateRecordDto, UpdateRecordCommand>()
                .ForMember(recordCommand => recordCommand.Date,
                    opt => opt.MapFrom(recordDto => recordDto.Date))
                .ForMember(recordCommand => recordCommand.Title,
                    opt => opt.MapFrom(recordDto => recordDto.Title))
                .ForMember(recordCommand => recordCommand.Description,
                    opt => opt.MapFrom(recordDto => recordDto.Description));
        }
    }
}
