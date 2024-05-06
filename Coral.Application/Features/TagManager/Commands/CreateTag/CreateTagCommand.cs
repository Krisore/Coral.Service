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

namespace Coral.Application.Features.TagManager.Commands.CreateTag;

public record CreateTagCommand(string name, string description = "")
    : IRequest<ErrorOr<CreateTagResponse>>;

public class AddTagCommandHandler : IRequestHandler<CreateTagCommand, ErrorOr<CreateTagResponse>>
{
    private readonly ITagRepository _tagRepository;

    public AddTagCommandHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    public async Task<ErrorOr<CreateTagResponse>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var response = await _tagRepository.AddAsync(new Tag()
        {
            Name = request.name,
            Description = request.description

        }, cancellationToken);

        if (response is null) return Error.NotFound("Tag not added successfully");
        return new CreateTagResponse(response.Name, true, $"{nameof(Tag)} : {response.Name} added successfully");
    }
}
