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

namespace Coral.Application.Features.CategoryManager.Commands.UpdateCategory;

public record UpdateCategoryCommand(int CategoryId, string CategoryName) : IRequest<ErrorOr<UpdateCategoryResponse>>;

public class UpdateCategoryCommandHanlder : IRequestHandler<UpdateCategoryCommand, ErrorOr<UpdateCategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHanlder(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<ErrorOr<UpdateCategoryResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = await _categoryRepository.UpdateCategoryName(request.CategoryName, request.CategoryId, cancellationToken);
        if (response is null) 
            return Error.NotFound($"{nameof(Category)} : {request.CategoryName} is not found!");

        return new UpdateCategoryResponse($"{nameof(Category)} : {response.Name} is updated successfully!");
    }
}
