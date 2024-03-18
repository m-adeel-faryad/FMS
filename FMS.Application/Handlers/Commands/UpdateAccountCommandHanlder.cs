using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FMS.Application.Dto;
using FMS.Application.Interfaces;
using FMS.Domain.Models;
using MediatR;

namespace FMS.Application.Handlers.Commands;

internal class UpdateAccountCommandHanlder(IRepository<Account> repository, IMapper mapper) : IRequestHandler<UpdateAccount, string>
{
    public async Task<string> Handle(UpdateAccount request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<UpdateAccount, Account>(request);
        await repository.Update(mapped, cancellationToken);
        return "Success";
    }
}