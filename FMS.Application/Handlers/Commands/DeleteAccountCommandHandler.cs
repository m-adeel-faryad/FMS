using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.Application.Dto;
using FMS.Application.Interfaces;
using FMS.Domain.Models;
using MediatR;

namespace FMS.Application.Handlers.Commands
{
    internal class DeleteAccountCommandHandler(IRepository<Account> repository) : IRequestHandler<DeleteAccountRequest, string>
    {
        public async Task<string> Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity == null)
            {
                return "not found";
            }

            await repository.Delete(entity, cancellationToken);
            return "Success";
        }
    }
}
