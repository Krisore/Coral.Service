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

namespace Coral.Application.Features.CategoryManager.Commands.CreateCategory;

public record CreateCategoryCommand(string CategoryName) : IRequest<ErrorOr<CreateCategoryResponse>>;

public class AddCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<CreateCategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<ErrorOr<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = await _categoryRepository.Add(new Category()
        {
            Name = request.CategoryName.ToUpper()
        }, cancellationToken) ;

        if (response == null)
        {
            return Error.NotFound($"{nameof(Category)} : {request.CategoryName} is not added!");
        }

        return new CreateCategoryResponse()
        {
            Message = $"{nameof(Category)} {response.Name} is added successfully!"
        };
    }
}
