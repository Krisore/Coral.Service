using Coral.Application.Commons.DTOs;
using Coral.Application.Commons.Repositories;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.TagManager.Queries.GetTags
{
    public record GetTagsQuery : IRequest<ErrorOr<IEnumerable<TagDto>>>;


    public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, ErrorOr<IEnumerable<TagDto>>>
    {
        private readonly ITagRepository _tagRepository;

        public GetTagsQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<ErrorOr<IEnumerable<TagDto>>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            var response = await _tagRepository.GetTagsAsync(cancellationToken);
            if (!response.Any() || response.Count() <= 0) return Error.NotFound("Tags is empty");
            var tags = response.Select(x => new TagDto
            {
                Id = x.Id,
                Name = x.Name,
            });
            return tags.ToList();
        }
    }
}
