using AutoMapper;
using Clinic.Application.Common.Mapping;
using Clinic.Application.Records.Commands.CreateRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.WebApi.Models
{
    public class CreateRecordDto : IMapWith<CreateRecordCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRecordDto, CreateRecordCommand>()
                .ForMember(recordCommand => recordCommand.Title,
                    opt => opt.MapFrom(recordDto => recordDto.Title))
                .ForMember(recordCommand => recordCommand.Description,
                    opt => opt.MapFrom(recordDto => recordDto.Description))
                .ForMember(recordCommand => recordCommand.Date,
                    opt => opt.MapFrom(recordDto => recordDto.Date));
        }
    }
}
