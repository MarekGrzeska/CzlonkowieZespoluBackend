using CzlonkowieZespoluBackend.Application.Commands.AddNewTeamMember;
using CzlonkowieZespoluBackend.Application.Commands.AddRandomTeamMember;
using CzlonkowieZespoluBackend.Application.Commands.ChangeTeamMemberStatus;
using CzlonkowieZespoluBackend.Application.Commands.EditTeamMember;
using CzlonkowieZespoluBackend.Application.Dtos;
using CzlonkowieZespoluBackend.Application.Queries.GetAllTeamMembers;
using CzlonkowieZespoluBackend.Application.Queries.GetRandomTeamMemberDto;
using CzlonkowieZespoluBackend.Application.Queries.GetTeamMemberById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CzlonkowieZespoluBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamMemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddRandom")]
        public async Task<IActionResult> AddRandomTeamMember()
        {
            await _mediator.Send(new AddRandomTeamMemberCommand());
            return Ok();
        }

        [HttpPost("ChangeStatus/{id}")]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _mediator.Send(new ChangeTeamMemberStatusCommand(id));
            return Ok();
        }

        [HttpPost("AddMember")]
        public async Task<IActionResult> AddMember([FromForm] AddNewTeamMemberCommand dto)
        {
            await _mediator.Send(dto);
            return Ok();
        }

        [HttpPost("EditMember")]
        public async Task <IActionResult> EditMember(EditTeamMemberCommand dto)
        {
            await _mediator.Send(dto);
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _mediator.Send(new GetAllTeamMembersQuery());
            return Ok(dtos);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _mediator.Send(new GetTeamMemberByIdQuery(id));
            return Ok(dto);
        }

        [HttpGet("GetRandomDto")]
        public async Task<IActionResult> GetRandomDto()
        {
            var dto = await _mediator.Send(new GetRandomTeamMemberDtoQuery());
            return Ok(dto);
        }


        [HttpGet("GetPhoto")]
        public IActionResult GetPhoto(string url)
        {
            byte[] photoBytes = System.IO.File.ReadAllBytes(url);
            Response.ContentType = "image/jpeg";
            return File(photoBytes, "Image/jpeg");
        }

    }
}