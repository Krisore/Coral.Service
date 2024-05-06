using Coral.Application.Commons.DTOs;
using Coral.Application.Commons.Repositories;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.CategoryManager.Queries.GetCategoryByName;

public record GetCategoryByNameQuery(string CategoryName)
    :IRequest<ErrorOr<CategoryDto>>;

public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery, ErrorOr<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByNameQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<ErrorOr<CategoryDto>> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
    {
        var response = await _categoryRepository.GetCategoryAsync(request.CategoryName, cancellationToken);
        if (response is null || string.IsNullOrEmpty(response.Name))
            return Error.NotFound("Category not found!");
        return new CategoryDto()
        {
            Id = response.Id,
            Name = response.Name
        };
    }
}
