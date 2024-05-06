using Coral.Application.Commons.Repositories;
using Coral.Application.Features.TagManager.Commands.CreateTag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.TagManager.Validator
{
    public class CreateTagValidator : AbstractValidator<CreateTagCommand>
    {
        private readonly ITagRepository _tagRepository;

        public CreateTagValidator(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
            RuleFor(x => x.name).NotEmpty().NotNull();
        }


        public async Task<bool> CheckTag(string name, CancellationToken cancellation)
        {
            var tagIsExist = await _tagRepository.FindAsync(name, cancellation);
            return tagIsExist == false;
        }
    }
}
