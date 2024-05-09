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

namespace Coral.Application.Features.CategoryManager.Commands.DeleteCategory;

public record DeleteCategoryCommand(string categoryName) : IRequest<ErrorOr<DeleteCategoryResponse>>;



public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ErrorOr<DeleteCategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<ErrorOr<DeleteCategoryResponse>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = await _categoryRepository.DeleteCategoryAsync(request.categoryName.ToUpper(), cancellationToken);
        if(response is false)
        {
            return Error.NotFound($"No Category Found named {request.categoryName}!");
        }
        return new DeleteCategoryResponse()
        {
            Message = $"{nameof(Category)} : {request.categoryName} is successfully removed!"
        };
    }
}
