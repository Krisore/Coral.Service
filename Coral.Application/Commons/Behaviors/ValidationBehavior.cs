﻿using ErrorOr;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Commons.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
        {
            private readonly IValidator<TRequest>? _validator;

            public ValidationBehavior(IValidator<TRequest>? validator = null)
            {
                _validator = validator;
            }
            public async Task<TResponse> Handle(
                TRequest request,
                RequestHandlerDelegate<TResponse> next,
                CancellationToken cancellationToken
            )
            {
                if (_validator is null)
                {
                    return await next();
                }
                var validationResult = await _validator.ValidateAsync(request);
                if (validationResult.IsValid)
                {
                    return await next();
                }
                var errors = validationResult.Errors.ConvertAll(validationFailure =>
                             Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage)).ToList();
                return (dynamic)errors;
            }
        }
}
