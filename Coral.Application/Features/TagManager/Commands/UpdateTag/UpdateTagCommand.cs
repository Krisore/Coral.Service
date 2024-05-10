using Coral.Application.Commons.Repositories;
using Coral.Contract.Tag.Response;
using Coral.Domain;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.TagManager.Commands.UpdateTag;

public record UpdateTagCommand(int Id, string Name, string Description): IRequest<ErrorOr<UpdateTagResponse>>;

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, ErrorOr<UpdateTagResponse>>
{
    private readonly ITagRepository _tagRepository;

    public UpdateTagCommandHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    public async Task<ErrorOr<UpdateTagResponse>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await _tagRepository.UpdateTagAsync(new Tag()
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description
        }, cancellationToken);

        if (tag == null) return Error.NotFound($"No Tag named {request.Name} found.");
        return new UpdateTagResponse
        {
            Success = true,
            Message = $"Tag named {request.Name} updated successfully"
        };
    }
}
