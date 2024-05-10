using Coral.Application.Commons.Repositories;
using Coral.Application.Features.TagManager.Commands.UpdateTag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.TagManager.Validator
{
    public class UpdateTagValidator : AbstractValidator<UpdateTagCommand>
    {
        private readonly ITagRepository _tagRepository;

        public UpdateTagValidator(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
            RuleFor(x => x.Name).NotEmpty().NotNull().MustAsync(CheckTag).WithMessage("This Tag already exist");
        }
        public async Task<bool> CheckTag(string name, CancellationToken cancellation)
        {
            var tagIsExist = await _tagRepository.FindAsync(name, cancellation);
            return !tagIsExist;
        }
    }
}
