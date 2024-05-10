using Coral.Application.Commons.Repositories;
using Coral.Contract.Tag.Response;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.TagManager.Commands.DeleteTag;

public record DeleteTagCommand(string Name) : IRequest<ErrorOr<DeleteTagResponse>>;

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, ErrorOr<DeleteTagResponse>>
{
    private readonly ITagRepository _tagRepository;

    public DeleteTagCommandHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    public async Task<ErrorOr<DeleteTagResponse>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await _tagRepository.DeleteTagAsync(request.Name, cancellationToken);
        if(tag is true)
        {
            return new DeleteTagResponse
            {
                Success = true,
                Message = $"Tag named {request.Name} is successfully deleted!"
            };
        }
        return Error.NotFound($"No tag named {request.Name}");
    }
}
