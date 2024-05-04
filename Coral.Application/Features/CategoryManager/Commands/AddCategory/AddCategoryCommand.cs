using Coral.Application.Commons.Repositories;
using Coral.Contract.Category.Response;
using Coral.Domain;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.CategoryManager.Commands.AddCategory
{
    public record AddCategoryCommand(string CategoryName) : IRequest<ErrorOr<AddCategoryResponse>>;

    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, ErrorOr<AddCategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<ErrorOr<AddCategoryResponse>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = await _categoryRepository.Add(new Category()
            {
                Name = request.CategoryName
            }, cancellationToken);

            if (response == null)
            {
                return Error.NotFound($"{nameof(Category)} : {request.CategoryName} is not added!");
            }

            return new AddCategoryResponse()
            {
                Message = $"{nameof(Category)} {response.Name} is added successfully!"
            };
        }
    }
}
