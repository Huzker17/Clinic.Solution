using AutoMapper;
using Clinic.Application.Records.Commands.CreateRecord;
using Clinic.Application.Records.Commands.DeleteRecord;
using Clinic.Application.Records.Commands.UpdateRecord;
using Clinic.Application.Records.Queries.GetRecordDetails;
using Clinic.Application.Records.Queries.GetRecordList;
using Clinic.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Clinic.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RecordController : BaseController
    {
        private readonly IMapper _mapper;
        public RecordController(IMapper mapper) => _mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<RecordListVm>> GetAll()
        {
            var query = new GetRecordListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecordDetailsVm>> Get(Guid id)
        {
            var query = new GetRecordDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        // POST api/<RecordController>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRecordDto record)
        {
            var command = _mapper.Map<CreateRecordCommand>(record);
            command.UserId = UserId;
            var recordId = await Mediator.Send(command);
            return Ok(recordId);
        }

        // PUT api/<RecordController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateRecordDto updateRecordDto)
        {
            var command = _mapper.Map<UpdateRecordCommand>(updateRecordDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<RecordController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteRecordCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
