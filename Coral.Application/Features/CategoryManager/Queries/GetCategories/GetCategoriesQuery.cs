using Coral.Application.Commons.DTOs;
using Coral.Application.Commons.Repositories;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.CategoryManager.Queries.GetCategories;

public record GetCategoriesQuery() 
    : IRequest<ErrorOr<IEnumerable<CategoryDto>>>;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, ErrorOr<IEnumerable<CategoryDto>>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<ErrorOr<IEnumerable<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var response = await _categoryRepository.GetCategoriesAsync(cancellationToken);
        if (!response.Any())
            return Error.NotFound("No Categories Found!");

        var categoryDtos = response.Select(x => new CategoryDto
        {
            Id = x.Id,
            Name = x.Name,
        });
        return categoryDtos.ToList();
    }
}
