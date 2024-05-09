using Coral.Application.Commons.DTOs;
using Coral.Application.Commons.Repositories;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.TagManager.Queries.GetTag
{
    public record GetTagByNameQuery(string Name) : IRequest<ErrorOr<TagDto>>;

    public class GetTagByNameQueryHandler : IRequestHandler<GetTagByNameQuery, ErrorOr<TagDto>>
    {
        private readonly ITagRepository _tagRepository;

        public GetTagByNameQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<ErrorOr<TagDto>> Handle(GetTagByNameQuery request, CancellationToken cancellationToken)
        {
            var response = await _tagRepository.GetTagByNameAsync(request.Name, cancellationToken);
            if (response == null || string.IsNullOrEmpty(response.Name)) return Error.NotFound($"Tag named {request.Name} not found");
            return new TagDto()
            {
                Id = response.Id,
                Name = response.Name,
                Description = response.Description
            };

        }
    }


}
