using AutoMapper;
using CzlonkowieZespoluBackend.Application.PhotoService;
using CzlonkowieZespoluBackend.Domain.Entities;
using CzlonkowieZespoluBackend.Domain.Interfaces;
using MediatR;

namespace CzlonkowieZespoluBackend.Application.Commands.AddNewTeamMember
{
    public class AddNewTeamMemberCommandHandler : IRequestHandler<AddNewTeamMemberCommand>
    {
        private readonly IPhotoService _photoService;
        private readonly ITeamMemberRepository _repository;
        private readonly IMapper _mapper;
        private const string BASE_URL = "https://localhost:7218/TeamMember/GetPhoto?url=Images%2F";
        private const string DEFAULT_IMAGE = "defaultPhoto.png";

        public AddNewTeamMemberCommandHandler(IPhotoService photoService, 
            ITeamMemberRepository repository, IMapper mapper)
        {
            _photoService = photoService;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddNewTeamMemberCommand request, CancellationToken cancellationToken)
        {
            if (request.File != null)
            {
                var fileName = await _photoService.SavePhoto(request.File);
                request.PhotoUrl = BASE_URL + fileName;
            }
            if (request.File == null && string.IsNullOrEmpty(request.PhotoUrl))
            {
                request.PhotoUrl = BASE_URL + DEFAULT_IMAGE;
            }
            var teamMember = _mapper.Map<TeamMember>(request);
            teamMember.CreatedDate = DateTime.UtcNow;
            teamMember.IsActive = true;
            await _repository.AddTeamMember(teamMember);
            await _repository.Commit();
            return Unit.Value;
        }
    }
}
