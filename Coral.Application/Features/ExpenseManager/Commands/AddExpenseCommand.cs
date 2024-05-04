using Coral.Contract.Expense.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.ExpenseManager.Commands
{
    public class AddExpenseCommand : IRequest<AddExpenseResponse>
    {

    }
    public class AddExpenseCommandHandler : IRequestHandler<AddExpenseCommand, AddExpenseResponse>
    {
        public AddExpenseCommandHandler()
        {
            
        }
        public Task<AddExpenseResponse> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
